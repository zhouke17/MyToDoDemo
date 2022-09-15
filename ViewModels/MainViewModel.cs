using MyToDoDemo.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows;

namespace MyToDoDemo.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal navigationJournal;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public MainViewModel(IRegionManager regionManager, IRegionNavigationJournal navigationJournal)
        {
            this.regionManager = regionManager;
            this.navigationJournal = navigationJournal;
            menuBars = new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            Init();
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.MenuPage))
                return;

            this.regionManager.Regions[Extension.RegionManager.MainViewRegionName].RequestNavigate(obj.MenuPage, (Journal) =>
            {
                MessageBox.Show(Journal.Error.Message);
                this.navigationJournal = Journal.Context.NavigationService.Journal;
            });
        }

        private void Init()
        {
            menuBars.Add(new MenuBar()
            {
                Icon = "Home",
                Title = "首页",
                MenuPage = "IndexView"
            });
            menuBars.Add(new MenuBar()
            {
                Icon = "NotebookOutline",
                Title = "待办事项",
                MenuPage = "ToDoView"
            });
            menuBars.Add(new MenuBar()
            {
                Icon = "NotebookPlus",
                Title = "备忘录",
                MenuPage = "MemoView"
            });
            menuBars.Add(new MenuBar()
            {
                Icon = "Cog",
                Title = "设置",
                MenuPage = "SettingView"
            });
        }
    }
}
