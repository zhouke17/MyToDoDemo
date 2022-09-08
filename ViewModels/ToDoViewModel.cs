using MyToDoDemo.Common.Models;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace MyToDoDemo.ViewModels
{
    public class ToDoViewModel:BindableBase
    {
        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        public ToDoViewModel()
        {
            toDoDtos = new ObservableCollection<ToDoDto>();
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < 20; i++)
            {
                toDoDtos.Add(new ToDoDto()
                { 
                    Title = "标题" + i,
                    Content = "测试数据..."
                });
            }
        }
    }
}
