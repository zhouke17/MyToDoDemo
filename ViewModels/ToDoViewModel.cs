using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using MyToDoDemo.Service;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace MyToDoDemo.ViewModels
{
    public class ToDoViewModel : NavigationViewModel
    {
        private ObservableCollection<ToDoDto> toDoDtos;
        private readonly ITodoService todoService;
        private readonly IContainerProvider containerProvider;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        public ToDoViewModel(ITodoService todoService, IContainerProvider containerProvider) : base(containerProvider)
        {
            toDoDtos = new ObservableCollection<ToDoDto>();
            this.todoService = todoService;
            this.containerProvider = containerProvider;
        }

        private async void GetAllAsync()
        {
            ShowLoading(true);
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
            ShowLoading(false);
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            GetAllAsync();
        }
    }
}
