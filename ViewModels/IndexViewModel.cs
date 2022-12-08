using MyToDoDemo.Common;
using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Models;
using MyToDoDemo.Service;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using MemoDto = MyToDoDemo.Common.Dtos.MemoDto;
using ToDoDto = MyToDoDemo.Common.Dtos.ToDoDto;

namespace MyToDoDemo.ViewModels
{
    public class IndexViewModel : NavigationViewModel
    {
        private SummaryDto summary;

        /// <summary>
        /// 首页统计
        /// </summary>
        public SummaryDto Summary
        {
            get { return summary; }
            set { summary = value; RaisePropertyChanged(); }
        }
        private DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; RaisePropertyChanged(); }
        }

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
        private readonly IDialogHostService dialogService;
        private readonly ITodoService todoService;
        private readonly IMemoService memoService;

        public ObservableCollection<Common.Dtos.MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }


        public DelegateCommand<string> ExecuteCommand { get; set; }
        public DelegateCommand EditTodoCommand { get; set; }
        public DelegateCommand EditMemoCommand { get; set; }

        public IndexViewModel(IDialogHostService dialogService, ITodoService todoService, IMemoService memoService, IContainerProvider containerProvider) : base(containerProvider)
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
            EditTodoCommand = new DelegateCommand(OperateTodo);
            EditMemoCommand = new DelegateCommand(OperateMemo);
            InitTaskBars();
            this.dialogService = dialogService;
            this.todoService = todoService;
            this.memoService = memoService;
            InitTimer();
            taskBars = new ObservableCollection<TaskBar>();
            doDtos = new ObservableCollection<ToDoDto>();
            memoDtos = new ObservableCollection<MemoDto>();
        }

        private void Execute(string commandName)
        {
            switch (commandName)
            {
                case "新增待办":
                    OperateTodo();
                    break;
                case "新增备忘录":
                    OperateMemo();
                    break;
            }
        }

        private async void OperateMemo()
        {
            ToDoDto toDoDto = new ToDoDto();
            DialogParameters pairs = new DialogParameters();
            pairs.Add("Memo", toDoDto);
            var diaResult = await dialogService.ShowDialog("AddMemoView", pairs);
            if (diaResult.Result == ButtonResult.OK)
            {
                var memo = diaResult.Parameters.GetValue<MemoDto>("Memo");
                if (memo.Id > 0)
                {
                    var res = await memoService.UpdateAsync(memo);
                    if (res.Status)
                    {
                        var memoModel = Summary.MemoList.FirstOrDefault(s => s.Id.Equals(memo.Id));
                        if (memoModel != null)
                        {
                            memoModel.Title = memoModel.Title;
                            memoModel.Content = memoModel.Content;
                        }
                    }
                }
                else
                {
                    var res = await memoService.AddAsync(memo);
                    if (res.Status)
                    {
                        Summary.MemoList.Add(res.Data);
                    }
                }
            }
        }

        private async void OperateTodo()
        {
            ToDoDto toDoDto = new ToDoDto();
            DialogParameters pairs = new DialogParameters();
            pairs.Add("Todo", toDoDto);
            var diaResult = await dialogService.ShowDialog("AddTodoView", pairs);
            if (diaResult.Result == ButtonResult.OK)
            {
                var todo = diaResult.Parameters.GetValue<ToDoDto>("Todo");
                if (todo.Id > 0)
                {
                    var res = await todoService.UpdateAsync(todo);
                    if (res.Status)
                    {
                        var todoModel = Summary.ToDoList.FirstOrDefault(s => s.Id.Equals(todo.Id));
                        if (todoModel != null)
                        {
                            todoModel.Title = todo.Title;
                            todoModel.Content = todo.Content;
                        }
                    }
                }
                else
                {
                    var res = await todoService.AddAsync(todo);
                    if (res.Status)
                    {
                        Summary.ToDoList.Add(res.Data);
                    }
                }
            }
        }

        private void InitTaskBars()
        {
            taskBars.Add(new TaskBar() { Icon = "ClockFast", Title = "汇总", Data = "10", Color = "#aa00ff", Target = "ToDoView" });
            taskBars.Add(new TaskBar() { Icon = "ClockCheckOutline", Title = "已完成", Data = "8", Color = "#00afc2", Target = "ToDoView" });
            taskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "完成率", Data = "80%", Color = "#00b844", Target = "" });
            taskBars.Add(new TaskBar() { Icon = "PlaylistStar", Title = "备忘录", Data = "20", Color = "#e41e00", Target = "MemoView" });
        }
        private void CreateTestData()
        {
            doDtos = new ObservableCollection<ToDoDto>();
            memoDtos = new ObservableCollection<MemoDto>();
        }

        private void InitTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.DateTime = DateTime.Now;
            //System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);获取星期
        }
        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var summaryList = await todoService.GetSummaryAsync();
            if (summaryList.Status)
            {
                Summary = summaryList.Data;
                Refresh();
            }
            base.OnNavigatedTo(navigationContext);
        }
        void Refresh()
        {
            TaskBars[0].Data = summary.Sum.ToString();
            TaskBars[1].Data = summary.CompletedCount.ToString();
            TaskBars[2].Data = summary.CompletedRatio;
            TaskBars[3].Data = summary.MemoeCount.ToString();
        }
    }
}
