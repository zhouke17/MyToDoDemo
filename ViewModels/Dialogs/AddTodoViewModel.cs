using MyToDoDemo.Common.Dtos;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace MyToDoDemo.ViewModels.Dialogs
{
    public class AddTodoViewModel : BindableBase, IDialogAware
    {
        private ToDoDto model;

        /// <summary>
        /// 新增或编辑的实体
        /// </summary>
        public ToDoDto Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
        }

        #region IDialogAware
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(); }
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }
        #endregion

        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }
        public AddTodoViewModel()
        {
            CancelCommand = new DelegateCommand(Cancel);
            ConfirmCommand = new DelegateCommand(Confirm);
        }

        private void Confirm()
        {
            DialogParameters pairs = new DialogParameters();
            pairs.Add("Todo", Model);

            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, pairs));
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Todo"))
            {
                Model = parameters.GetValue<ToDoDto>("Todo");
            }
            else
            {
                Model = new ToDoDto();
            }
        }
    }
}
