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
            string viewName = GetViewName(pageName);
            if (!_componentContext.IsRegisteredWithName<Page>(viewName))
            {
                return null;
            }

            var page = _componentContext.ResolveNamed<Page>(viewName);

            string viewModelName = GetViewModelName(pageName);
            if (_componentContext.IsRegisteredWithName<ViewModelBase>(viewModelName))
            {
                var viewModel = _componentContext.ResolveNamed<ViewModelBase>(viewModelName);
                viewModel.Navigator = _componentContext.Resolve<INavigator>();
                viewModel.Title = GetViewModelTitle(pageName);

                page.BindingContext = viewModel;
            }

            return page;
        }

        #endregion // Operations

        #region Implementation

        private static string GetViewName(string pageName)
        {
            return pageName + "View";
        }

        private static string GetViewModelName(string pageName)
        {
            return pageName + "ViewModel";
        }

        private static string GetViewModelTitle(string pageName)
        {
            return pageName;
        }

        #endregion // Implementation

    }
}