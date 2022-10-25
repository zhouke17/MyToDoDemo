using MyToDoDemo.Common;
using Prism.Services.Dialogs;
using System.Threading.Tasks;

namespace MyToDoDemo.Extension
{
    public static class DialogEx
    {
        public static async Task<IDialogResult> ShowDialog(this IDialogHostAware dialogHost, string name, IDialogParameters dialogParameters, string windowName = "Root")
        {
            return await dialogHost.ShowDialog(name, dialogParameters, windowName);
        }
    }
}
