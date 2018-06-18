using Autofac;
using HSPackTracker.DataAccess;
using HSPackTracker.UI.Data;
using HSPackTracker.UI.ViewModel;
using Prism.Events;

namespace HSPackTracker.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<HSPackTrackerDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<PackDetailViewModel>().As<IPackDetailViewModel>();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<PackDataService>().As<IPackDataService>();

            return builder.Build();
        }
    }
}
