using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using CoreLib.Mvvm;
using Xamarin.Forms;

namespace XamFormsNavigation
{
    public class App : Application
    {
        public App()
        {
            var container = InitIoC();

            var viewFactory = container.Resolve<IViewFactory>();

            MainPage = new NavigationPage(viewFactory.ResolvePage("First"));
        }

        private static IContainer InitIoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<MvvmModule>();
            builder.RegisterModule<ViewsModule>();

            //// Views
            //builder.RegisterAssemblyTypes(ThisAssembly)
            //    .AssignableTo<Page>()
            //    .Where(v => !v.IsAssignableTo<ISingletonLifetimeScope>())
            //    .Named<Page>(t => t.Name)
            //    .SingleInstance();
            //builder.RegisterAssemblyTypes(ThisAssembly)
            //    .AssignableTo<Page>()
            //    .Where(v => v.IsAssignableTo<ISingletonLifetimeScope>())
            //    .Named<Page>(t => t.Name);

            //// ViewModels
            //builder.RegisterAssemblyTypes(ThisAssembly)
            //    .AssignableTo<ViewModelBase>()
            //    .Where(v => !v.IsAssignableTo<ISingletonLifetimeScope>())
            //    .Named<ViewModelBase>(t => t.Name)
            //    .SingleInstance();
            //builder.RegisterAssemblyTypes(ThisAssembly)
            //    .AssignableTo<ViewModelBase>()
            //    .Where(v => v.IsAssignableTo<ISingletonLifetimeScope>())
            //    .Named<ViewModelBase>(t => t.Name);

            return builder.Build();
        }
    }
}
