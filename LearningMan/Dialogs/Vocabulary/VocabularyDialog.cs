using BLL;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace LearningMan.Dialogs.Vocabulary
{
    [Serializable]
    public class VocabularyDialog : IDialog<object>
    {
        #region Menu options

        private const string ADD_WORD_MENU_OPT = "Add new word";
        private const string VOC_LIST_MENU_OPT = "List of words";
        private const string HELP_MENU_OPT = "How do I work?";
        private const string MAIN_MENU_OPT = "Main menu";


        static List<string> MENU_OPTS = new List<string>()
        {
            ADD_WORD_MENU_OPT,
            VOC_LIST_MENU_OPT,
            HELP_MENU_OPT,
            MAIN_MENU_OPT
        };
        #endregion

        private static readonly LearnersService _service = LearnersService.Instance;
        private readonly string _learnerId;

        public VocabularyDialog(string learnerId)
        {
            _learnerId = learnerId;
        }

        public async Task StartAsync(IDialogContext context)
        {
            mainMenuPrompt(context);
        }

        private void mainMenuPrompt(IDialogContext context)
        {
            PromptDialog.Choice(context, resumeAfterMenuSelection, MENU_OPTS, "Awailable options: ");
        }

        private async Task resumeAfterMenuSelection(IDialogContext context, IAwaitable<object> result)
        {
            var answer = await result;

            switch (answer)
            {
                case ADD_WORD_MENU_OPT:
                    addWordFunc(context);
                    break;
                case VOC_LIST_MENU_OPT:
                    await context.PostAsync(printAllWords());
                    mainMenuPrompt(context);
                    break;
                case HELP_MENU_OPT:
                    context.Call(new HelpDialog(), resumeAfterOptionDialog);
                    break;
                case MAIN_MENU_OPT:
                    context.Reset();
                    break;
                default:
                    await context.PostAsync("No such option =(");
                    break;
            }
        }

        private string printAllWords()
        {
            return _service.PrintAll(_learnerId);

        }

        private void addWordFunc(IDialogContext context)
        {
            IDialog<NewWordViewModel> addingDialog = FormDialog.FromForm(NewWordViewModel.BuildForm, FormOptions.PromptInStart);
            context.Call( addingDialog, resumeAfterAddingAsync);
        }

        // ReSharper disable once InconsistentNaming
        private async Task resumeAfterAddingAsync(IDialogContext context, IAwaitable<NewWordViewModel> result)
        {
            
            NewWordViewModel word = await result;
            await context.PostAsync($"Trying to add your word..");
            try
            {
                _service.AddCard(word.Key, word.Value, _learnerId);
            }
            catch (Exception e)
            {
                await context.PostAsync($"{e.Message}");
                await context.PostAsync($"{e.StackTrace}");

                throw;
            }
            await context.PostAsync($"New word added! Now your vocabulary consists of {_service.CountCards(_learnerId)} words!");
            mainMenuPrompt(context);

        }

        private async Task resumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {

            //This means  MessageRecievedAsync function of this dialog (PromptButtonsDialog) will receive users' messeges
            mainMenuPrompt(context);

        }
    }
}
