using MaterialDesignThemes.Wpf;
using MyToDoDemo.Common;
using MyToDoDemo.Common.Dtos;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace MyToDoDemo.ViewModels.Dialogs
{
    public class AddMemoViewModel : BindableBase, IDialogHostAware
    {
        private MemoDto model;

        /// <summary>
        /// 新增或编辑的实体
        /// </summary>
        public MemoDto Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
        }

        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }
        public string DialogHostName { get; set; }

        public AddMemoViewModel()
        {
            CancelCommand = new DelegateCommand(Cancel);
            ConfirmCommand = new DelegateCommand(Confirm);
        }

        private void Confirm()
        {
            DialogParameters pairs = new DialogParameters();
            pairs.Add("Todo", Model);

            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, pairs));
        }

        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.Cancel));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Memo"))
            {
                Model = parameters.GetValue<MemoDto>("Memo");
            }
            else
            {
                Model = new MemoDto();
            }
        }
    }
}
