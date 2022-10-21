using MyToDoDemo.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace MyToDoDemo.ViewModels
{
    public class IndexViewModel : BindableBase
    {

        private ObservableCollection<TaskBar> taskBars;
        public ObservableCollection<TaskBar> TaskBars
        {
            get
            {
                return taskBars;
            }
            set
            {
                taskBars = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<ToDoDto> doDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return doDtos; }
            set { doDtos = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<MemoDto> memoDtos;
        private readonly IDialogService dialogService;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }


        public DelegateCommand<string> ExecuteCommand { get; set; }

        public IndexViewModel(IDialogService dialogService)
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
            taskBars = new ObservableCollection<TaskBar>();
            InitTaskBars();
            CreateTestData();
            this.dialogService = dialogService;
        }

        private void Execute(string commandName)
        {
            switch (commandName)
            {
                case "新增待办":
                    AddTodo();
                    break;
                case "新增备忘录":
                    AddMemo();
                    break;
            }
        }

        private void AddMemo()
        {
            ToDoDto toDoDto = new ToDoDto();
            DialogParameters pairs = new DialogParameters();
            pairs.Add("Memo", toDoDto);
            dialogService.ShowDialog("Memo", pairs, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {

                }
                else
                {

                }
            });
        }

        private void AddTodo()
        {
            ToDoDto toDoDto = new ToDoDto();
            DialogParameters pairs = new DialogParameters();
            pairs.Add("Todo", toDoDto);
            dialogService.ShowDialog("Todo", pairs, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {

                }
                else
                {

                }
            });
        }

        private void InitTaskBars()
        {
            taskBars.Add(new TaskBar() { Icon = "ClockFast", Title = "汇总", Data = "10", Color = "#aa00ff", Target = "" });
            taskBars.Add(new TaskBar() { Icon = "ClockCheckOutline", Title = "已完成", Data = "8", Color = "#00afc2", Target = "" });
            taskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "完成率", Data = "80%", Color = "#00b844", Target = "" });
            taskBars.Add(new TaskBar() { Icon = "PlaylistStar", Title = "备忘录", Data = "20", Color = "#e41e00", Target = "" });
        }
        private void CreateTestData()
        {
            doDtos = new ObservableCollection<ToDoDto>();
            memoDtos = new ObservableCollection<MemoDto>();
            for (int i = 0; i < 10; i++)
            {
                doDtos.Add(new ToDoDto() { Title = "提醒" + i, Content = "要做。。。" });
                memoDtos.Add(new MemoDto() { Title = "备忘" + i, Content = "密码是。。。" });
            }
        }
    }
}
