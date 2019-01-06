using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace BoardGameStats.Core.Helpers
{
    public static class DialogHelper
    {
        public static async Task<bool> ConfirmationDialogAsync(
            string title,
            string yesButtonText,
            string noButtonText)
        {
            var dialog = new MessageDialog(title);
            dialog.Commands.Add(new UICommand(yesButtonText, null, 1));
            dialog.Commands.Add(new UICommand(noButtonText, null, 2));

            IUICommand result = await dialog.ShowAsync();

            if (result == null)
                return false;

            switch ((int) result.Id)
            {
                case 1:
                    return true;
                default:
                    return false;
            }
        }
    }
}
