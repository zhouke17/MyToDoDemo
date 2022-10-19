using MyToDoDemo.Extensions;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace MyToDoDemo.ViewModels
{
    public class NavigationViewModel : BindableBase, INavigationAware
    {
        private readonly IContainerProvider container;
        private readonly IEventAggregator eventAggregator;

        public NavigationViewModel(IContainerProvider container)
        {
            this.container = container;
            this.eventAggregator = container.Resolve<IEventAggregator>();
        }
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
        public void ShowLoading(bool IsOpen)
        {
            this.eventAggregator.Publish(new Common.Events.LoadingModel { IsOpen = IsOpen });
        }
    }
}