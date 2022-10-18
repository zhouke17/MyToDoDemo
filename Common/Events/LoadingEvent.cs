using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Common.Events
{
    public class LoadingEvent : PubSubEvent<IsOpenMessage>
    {
    }
    public class IsOpenMessage
    {
        public bool IsOpen { get; set; }
    }
}
