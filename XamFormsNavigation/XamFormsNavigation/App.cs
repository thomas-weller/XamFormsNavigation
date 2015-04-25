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

            // Note that this page does not get resolved via the ViewFactory, but directly
            // via the container. This is because the standard naming conventions allow
            // the ViewFactory to resolve pages only when they are named 'xxx'View.
            var startPage = container.ResolveNamed<Page>("StartPage");

            MainPage = new NavigationPage(startPage);
        }

        private static IContainer InitIoC()
        {
            var builder = new ContainerBuilder();

            // Register MVVM framework.
            builder.RegisterModule<MvvmModule>();

            // Register all views/pages and viewmodels that reside in this assembly.
            builder.RegisterModule<ViewsModule>();

            return builder.Build();
        }
    }
}
