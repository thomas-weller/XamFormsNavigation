using Autofac;
using Xamarin.Forms;

namespace CoreLib.Mvvm
{
    public class ViewFactory : IViewFactory
    {
        #region Fields

        private readonly IComponentContext _componentContext;
        private readonly INamingConventions _namingConventions;

        #endregion // Fields

        #region Construction

        public ViewFactory(IComponentContext componentContext, INamingConventions namingConventions)
        {
            _componentContext = componentContext;
            _namingConventions = namingConventions;
        }

        #endregion // Construction

        #region Operations

        public Page ResolvePage(string name)
        {
            string viewName = _namingConventions.GetViewName(name);
            if (!_componentContext.IsRegisteredWithName<Page>(viewName))
            {
                return null;
            }

            var page = _componentContext.ResolveNamed<Page>(viewName);

            string viewModelName = _namingConventions.GetViewModelName(name);
            if (_componentContext.IsRegisteredWithName<ViewModelBase>(viewModelName))
            {
                var viewModel = _componentContext.ResolveNamed<ViewModelBase>(viewModelName);
                viewModel.Navigator = _componentContext.Resolve<INavigator>();
                viewModel.Title = _namingConventions.GetViewModelTitle(name);

                page.BindingContext = viewModel;
            }

            return page;
        }

        #endregion // Operations

    }
}