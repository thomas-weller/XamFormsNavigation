using Autofac;
using CoreLib.Mvvm;
using Xamarin.Forms;

namespace XamFormsNavigation
{
    public class App : Application
    {
        public App()
        {
            IContainer container = InitIoC();

            var viewFactory = container.Resolve<IViewFactory>();

            Page firstPage = viewFactory.ResolvePage("First");

            MainPage = new NavigationPage(firstPage);
        }

        private static IContainer InitIoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<MvvmModule>();
            builder.RegisterModule<ViewsModule>();

            return builder.Build();
        }
    }
}
