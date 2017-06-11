using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Text.RegularExpressions;
using Microsoft.Bot.Builder.FormFlow;
using System.Collections.Generic;
using BLL;
using LearningMan.Dialogs.Vocabulary;

namespace LearningMan.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        #region Menu options

        private const string VOCABULARY_MENU_OPT = "Vocabulary";
        private const string TRAINING_MENU_OPT = "Training";
        private const string HELP_MENU_OPT = "How do I work?";
        private const string AUTHOR_MENU_OPT = "Author";


        static List<string> MAIN_MENU_OPTS = new List<string>()
        {
            VOCABULARY_MENU_OPT,
            TRAINING_MENU_OPT,
            HELP_MENU_OPT,
            AUTHOR_MENU_OPT
        };
        #endregion

        private static LearnersManager _manager = LearnersManager.Instance;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            PromptDialog.Choice(context, resumeAfterMenuSelection, MAIN_MENU_OPTS, "Here is my main menu!");
        }

        private async Task resumeAfterMenuSelection(IDialogContext context, IAwaitable<object> result)
        {
            var answer = await result;

            switch (answer)
            {
                case VOCABULARY_MENU_OPT:
                    context.Call(new VocabularyDialog(), resumeAfterOptionDialog);
                    break;
                case TRAINING_MENU_OPT:
                    context.Call(new TrainingDialog(), resumeAfterOptionDialog);
                    break;
                case HELP_MENU_OPT:
                    context.Call(new HelpDialog(), resumeAfterOptionDialog);
                    break;
                case AUTHOR_MENU_OPT:
                    context.Call(new AuthorDialog(), resumeAfterOptionDialog);
                    break;
                default:
                    await context.PostAsync("No such option =(");
                    break;
            }
        }

        private async Task resumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {

            //This means  MessageRecievedAsync function of this dialog (PromptButtonsDialog) will receive users' messeges
            context.Wait(MessageReceivedAsync);
            
        }

        private async Task Greetings (IDialogContext context)
        {
            await context.PostAsync("Hi! I can assist you in your learning process =)");
        }


    }
}