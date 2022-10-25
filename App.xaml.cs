using DryIoc;
using MyToDoDemo.Common;
using MyToDoDemo.Service;
using MyToDoDemo.ViewModels;
using MyToDoDemo.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace MyToDoDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void OnInitialized()
        {
            var mainWindow = App.Current.MainWindow.DataContext as IConfigService;
            if (mainWindow != null)
            {
                mainWindow.Config();
            }
            base.OnInitialized();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.GetContainer().Register<HttpClient>(made: Parameters.Of.Type<string>(serviceKey: "Url"));
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:5000/", serviceKey: "Url");

            containerRegistry.Register<ITodoService, TodoService>();
            containerRegistry.Register<IMemoService, MemoService>();
            containerRegistry.Register<ILoginService, LoginService>();

            containerRegistry.Register<IDialogHostService>();

            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
        }
    }
}
