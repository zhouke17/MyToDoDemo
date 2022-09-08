using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Common.Models
{
    public class MenuBar : BindableBase
    {
        private string icon;

        public string Icon
        {
            get { return icon; }
            set { icon = value;RaisePropertyChanged(); }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value;RaisePropertyChanged(); }
        }
        private string menuPage;

        public string MenuPage
        {
            get { return menuPage; }
            set { menuPage = value;RaisePropertyChanged(); }
        }

    }
}
