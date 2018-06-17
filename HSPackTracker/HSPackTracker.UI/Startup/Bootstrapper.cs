using Autofac;
using HSPackTracker.DataAccess;
using HSPackTracker.UI.Data;
using HSPackTracker.UI.ViewModel;

namespace HSPackTracker.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HSPackTrackerDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<PackDataService>().As<IPackDataService>();

            return builder.Build();
        }
    }
}
