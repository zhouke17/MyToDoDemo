using MyToDoDemo.Common.Events;
using Prism.Events;
using System;

namespace MyToDoDemo.Extensions
{
    public static class EventAggregatorExtension
    {
        public static void Publish(this IEventAggregator eventAggregator, LoadingModel model)
        {
            eventAggregator.GetEvent<LoadingProgressEvent>().Publish(model);
        }
        public static void Subscribe(this IEventAggregator eventAggregator, Action<LoadingModel> action)
        {
            eventAggregator.GetEvent<LoadingProgressEvent>().Subscribe(action);
        }
    }
}
