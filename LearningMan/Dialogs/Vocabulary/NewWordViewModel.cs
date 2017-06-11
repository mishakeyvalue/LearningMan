using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningMan.Dialogs.Vocabulary
{
    [Serializable]
    public class NewWordViewModel
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public static IForm<NewWordViewModel> BuildForm()
        {
            return new FormBuilder<NewWordViewModel>()
                    .Message("Adding new word..")
                    .Build();
        }
    }
}