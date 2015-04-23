using Autofac;
using Xamarin.Forms;
using CoreLib.Mvvm;

namespace XamFormsNavigation
{
    public class ViewsModule : Module
    {
        /// <summary>
        /// Registers all Views (Pages) and ViewModels that reside in this
        /// assembly such that that they are resolvable by name
        /// </summary>
        /// <remarks>
        /// Views must derive from <see cref="Page"/>, ViewModels must derive from <see cref="ViewModelBase"/>.<br/>
        /// Per default, all classes are registered with transient lifetime scope. However, if the class should be
        /// registered as a singleton, you can use the <see cref="ISingletonLifetimeScope"/> marker interface.
        /// </remarks>
        /// <param name="builder">The Autofac ContainerBuilder which registers the module on app startup.</param>
        protected override void Load(ContainerBuilder builder)
        {
            // Views
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<Page>()
                .Where(v => !v.IsAssignableTo<ISingletonLifetimeScope>())
                .Named<Page>(t => t.Name);
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<Page>()
                .Where(v => v.IsAssignableTo<ISingletonLifetimeScope>())
                .Named<Page>(t => t.Name)
                .SingleInstance();

            // ViewModels
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<ViewModelBase>()
                .Where(v => !v.IsAssignableTo<ISingletonLifetimeScope>())
                .Named<ViewModelBase>(t => t.Name);
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<ViewModelBase>()
                .Where(v => v.IsAssignableTo<ISingletonLifetimeScope>())
                .Named<ViewModelBase>(t => t.Name)
                .SingleInstance();
        }
    }
}