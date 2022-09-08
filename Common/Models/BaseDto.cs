using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Common.Models
{
    public class BaseDto : BindableBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(); }
        }

        private string createDate;

        public string CreateDate
        {
            get { return createDate; }
            set { createDate = value;RaisePropertyChanged(); }
        }

    }
}
