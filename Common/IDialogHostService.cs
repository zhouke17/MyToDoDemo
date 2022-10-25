using Prism.Services.Dialogs;
using System.Threading.Tasks;

namespace MyToDoDemo.Common
{
    public interface IDialogHostService : IDialogService
    {
        Task<IDialogResult> ShowDialog(string name, IDialogParameters dialogParameters, string windowName = "Root");
    }
}
