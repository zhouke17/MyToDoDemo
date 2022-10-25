using Prism.Commands;
using Prism.Services.Dialogs;

namespace MyToDoDemo.Common
{
    public interface IDialogHostAware
    {
        /// <summary>
        /// DialoHost名称
        /// </summary>
        string DialogHostName { get; set; }
        /// <summary>
        /// 打开后执行
        /// </summary>
        /// <param name="parameters"></param>
        void OnDialogOpened(IDialogParameters parameters);
        /// <summary>
        /// 取消命令
        /// </summary>
        DelegateCommand CancelCommand { get; set; }
        /// <summary>
        /// 确认命令
        /// </summary>
        DelegateCommand ConfirmCommand { get; set; }
    }
}
