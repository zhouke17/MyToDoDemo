using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using MyToDoDemo.Service;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace MyToDoDemo.ViewModels
{
    public class ToDoViewModel:BindableBase
    {
        private ObservableCollection<ToDoDto> toDoDtos;
        private readonly ITodoService todoService;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        public ToDoViewModel(ITodoService todoService)
        {
            toDoDtos = new ObservableCollection<ToDoDto>();
            this.todoService = todoService;
            Init();
        }

        private async void Init()
        {
            var res = await todoService.GetAllFilterAsync(new ToDoParameter
            {
                PageIndex = 0,
                PageSize = 100,
                Search = "",
                Status = null
            });
            if (res.Status)
            {
                foreach (var item in res.Data.Items)
                {
                    toDoDtos.Add(item);
                }
            }
        }
    }
}
