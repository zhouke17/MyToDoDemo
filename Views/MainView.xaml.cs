using System;
using System.Windows;
using System.Windows.Input;

namespace MyToDoDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {

        public MainView()
        {
            InitializeComponent();
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
            this.closeButton.Click += (s, e) =>
            {
                this.Close();
            };
            this.RibbonBar.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
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

        }
    }
}
