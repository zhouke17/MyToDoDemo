using MyToDoDemo.Common.Models;
using Prism.Mvvm;
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

        public ObservableCollection<MemoDto> MemoDtos   
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }


        public IndexViewModel()
        {
            taskBars = new ObservableCollection<TaskBar>();
            InitTaskBars();
            CreateTestData();
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
                doDtos.Add(new ToDoDto() { Title = "提醒" + i,Content = "要做。。。" });
                memoDtos.Add(new MemoDto() { Title = "备忘" + i, Content = "密码是。。。" });
            }
        }
    }
}
