using MyToDoDemo.Common.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Extension
{
    public static class EventAggregatorEx
    {
        public static void Publish(this IEventAggregator eventAggregator, IsOpenMessage openMessage)
        {
            eventAggregator.GetEvent<LoadingEvent>().Publish(openMessage);
        }

        public static void Subscribe(this IEventAggregator eventAggregator,Action<IsOpenMessage> action)
        {
            eventAggregator.GetEvent<LoadingEvent>().Subscribe(action);
        }
    }
}
