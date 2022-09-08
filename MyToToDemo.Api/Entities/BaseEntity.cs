using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Entities
{
    public class BaseEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime createTime;

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        private DateTime updateTime;

        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }

    }
}
