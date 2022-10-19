using Prism.Events;

namespace MyToDoDemo.Common.Events
{
    public class LoadingProgressEvent : PubSubEvent<LoadingModel>
    {

    }

    public class LoadingModel
    {
        public bool IsOpen { get; set; }
    }
}
