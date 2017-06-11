using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace BLL.Dialogs
{
    [Serializable]
    internal class TrainingDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }
    }
}