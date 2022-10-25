using MyToDoDemo.Common;
using MyToDoDemo.Extension;
using Prism.Events;
using Prism.Services.Dialogs;
using System.Windows;

namespace MyToDoDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private readonly IDialogService dialog;

        public MainView(IEventAggregator eventAggregator, IDialogHostService dialog)
        {
            InitializeComponent();

            //注册加载中事件消息窗口
            eventAggregator.Subscribe((flag) =>
            {
                this.dialogHost.IsOpen = flag.IsOpen;
                if (flag.IsOpen)
                {
                    dialogHost.DialogContent = new LoadingView();
                }
            });

            this.menuList.SelectionChanged += (s, e) =>
            {
                this.leftDrawer.IsLeftDrawerOpen = false;
            };
            this.minimumButton.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };
            this.maximumButton.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            };
            this.closeButton.Click += async (s, e) =>
            {
                DialogParameters pairs = new DialogParameters();
                pairs.Add("Title", "温馨提示");
                pairs.Add("Content", "是否关闭系统？");

                var diaResult = await dialog.ShowDialog("ToolTipView", pairs);
                if (diaResult.Result != ButtonResult.OK) return;
                this.Close();
            };
            //this.RibbonBar.MouseMove += (s, e) =>
            //{
            //    if (e.LeftButton == MouseButtonState.Pressed)
            //    {
            //        this.DragMove();
            //    }
            //};
            this.RibbonBar.MouseDoubleClick += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            };
            this.dialog = dialog;
        }
    }
}
