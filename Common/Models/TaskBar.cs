using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Common.Models
{
    public class TaskBar : BindableBase
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
        private string data;

        public string Data
        {
            get { return data; }
            set { data = value;RaisePropertyChanged(); }
        }
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value;RaisePropertyChanged(); }
        }
        private string target;

        public string Target
        {
            get { return target; }
            set { target = value;RaisePropertyChanged(); }
        }

    }
}
