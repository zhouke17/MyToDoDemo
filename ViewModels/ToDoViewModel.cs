using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using MyToDoDemo.Service;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyToDoDemo.ViewModels
{
    public class ToDoViewModel : NavigationViewModel
    {
        #region 字段属性  
        private ObservableCollection<ToDoDto> toDoDtos;
        private readonly ITodoService todoService;
        private readonly IContainerProvider containerProvider;
        public DelegateCommand<ToDoDto> SelectedCommand { get; set; }
        public DelegateCommand<string> ExecuteCommand { get; set; }
        public DelegateCommand<ToDoDto> DeleteCommand { get; set; }
        private int status;
        /// <summary>
        /// 待办事项的状态
        /// </summary>
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                GetAllAsync();
                RaisePropertyChanged();
            }
        }

        private string searchText;
        /// <summary>
        /// 查询字符串
        /// </summary>
        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; GetAllAsync(); RaisePropertyChanged(); }
        }
        private bool isRightDrawerOpen;
        /// <summary>
        /// 右侧弹窗是否开启
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        private ToDoDto currentDto;
        /// <summary>
        /// 新增/修改实体类
        /// </summary>
        public ToDoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Todo集合
        /// </summary>
        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }
        #endregion

        public ToDoViewModel(ITodoService todoService, IContainerProvider containerProvider) : base(containerProvider)
        {
            toDoDtos = new ObservableCollection<ToDoDto>();
            this.todoService = todoService;
            this.containerProvider = containerProvider;
            SelectedCommand = new DelegateCommand<ToDoDto>(Selected);
            ExecuteCommand = new DelegateCommand<string>(Execute);
            DeleteCommand = new DelegateCommand<ToDoDto>(Delete);
        }

        private async void Delete(ToDoDto obj)
        {
            var deleteRes = await todoService.DeleteAsyc(obj.Id);
            if (deleteRes.Status)
            {
                var delTodo = ToDoDtos.FirstOrDefault(s => s.Id == obj.Id);
                if (delTodo != null)
                {
                    ToDoDtos.Remove(delTodo);
                }
            }
        }

        #region 方法
        private void Execute(string param)
        {
            switch (param)
            {
                case "新增":
                    Add();
                    break;
                case "查询":
                    GetAllAsync();
                    break;
                case "保存":
                    Save();
                    break;
            }
        }

        private void Add()
        {
            CurrentDto = new ToDoDto();
            IsRightDrawerOpen = true;
        }

        private async void Save()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CurrentDto.Title) ||
               string.IsNullOrWhiteSpace(CurrentDto.Content))
                    return;

                ShowLoading(true);
                if (CurrentDto.Id > 0)//修改
                {
                    var updateRes = await todoService.UpdateAsync(CurrentDto);
                    if (updateRes.Status)
                    {
                        var toDoDto = ToDoDtos.FirstOrDefault(S => S.Id.Equals(CurrentDto.Id));
                        toDoDto.Title = CurrentDto.Title; //将当前保存的数据赋与历史数据，以实现即时更新
                        toDoDto.Content = CurrentDto.Content;
                        toDoDto.Status = CurrentDto.Status;
                        IsRightDrawerOpen = false;
                    }
                }
                else //新增
                {
                    var insertRes = await todoService.AddAsync(CurrentDto);
                    if (insertRes.Status)
                    {
                        ToDoDtos.Add(insertRes.Data);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ShowLoading(false);
            }
        }

        private async void Selected(ToDoDto dto)
        {
            try
            {
                ShowLoading(true);
                var selectResult = await todoService.GetFirstOrDefaultAsync(dto.Id);
                if (selectResult != null)
                {
                    CurrentDto = selectResult.Data;
                    IsRightDrawerOpen = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ShowLoading(false);
            }
        }

        private async void GetAllAsync()
        {
            ShowLoading(true);
            int? status = Status == 0 ? null : Status == 1 ? 0 : 1;
            var res = await todoService.GetAllFilterAsync(new ToDoParameter
            {
                PageIndex = 0,
                PageSize = 100,
                Search = SearchText,
                Status = status
            });
            toDoDtos.Clear();
            if (res.Status)
            {
                foreach (var item in res.Data.Items)
                {
                    toDoDtos.Add(item);
                }
            }
            ShowLoading(false);
        }
        #endregion

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            GetAllAsync();
        }
    }
}
