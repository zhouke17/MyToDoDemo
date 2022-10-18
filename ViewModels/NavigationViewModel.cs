using MyToDoDemo.Common.Events;
using MyToDoDemo.Extension;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.ViewModels
{
    public class NavigationViewModel : BindableBase, INavigationAware
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IContainerProvider containerProvider;

        public NavigationViewModel(IContainerProvider containerProvider)
        {
            this.eventAggregator = containerProvider.Resolve<IEventAggregator>();
            this.containerProvider = containerProvider;
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

        public void  ShowLoading(bool isOpen)
        {
            eventAggregator.Publish(new IsOpenMessage
            {
                IsOpen = isOpen
            });
        }

    }
}
