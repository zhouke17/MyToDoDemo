using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Common.Models
{
    public class ToDoDto : BaseDto
    {
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; RaisePropertyChanged(); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value;RaisePropertyChanged(); }
        }

    }
}
