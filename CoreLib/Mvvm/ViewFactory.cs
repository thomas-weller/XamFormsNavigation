using Autofac;
using Xamarin.Forms;

namespace CoreLib.Mvvm
{
    public class ViewFactory : IViewFactory
    {
        #region Fields

        private readonly IComponentContext _componentContext;

        #endregion // Fields

        #region Construction

        public ViewFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        #endregion // Construction

        #region Operations

        public Page ResolvePage(string pageName)
        {
            string viewName = NamingConventions.GetViewName(pageName);
            if (!_componentContext.IsRegisteredWithName<Page>(viewName))
            {
                return null;
            }

            var page = _componentContext.ResolveNamed<Page>(viewName);

            string viewModelName = NamingConventions.GetViewModelName(pageName);
            if (_componentContext.IsRegisteredWithName<ViewModelBase>(viewModelName))
            {
                var viewModel = _componentContext.ResolveNamed<ViewModelBase>(viewModelName);
                viewModel.Navigator = _componentContext.Resolve<INavigator>();
                viewModel.Title = NamingConventions.GetViewModelTitle(pageName);

                page.BindingContext = viewModel;
            }

            return page;
        }

        #endregion // Operations

    }
}