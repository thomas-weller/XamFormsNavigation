using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoreLib.Mvvm
{
    class Navigator : INavigator
    {
        #region Fields

        private readonly Lazy<INavigation> _lazyNavigation;
        private readonly IViewFactory _viewFactory;

        #endregion // Fields

        #region Construction

        public Navigator(Lazy<INavigation> lazyNavigation, IViewFactory viewFactory)
        {
            _lazyNavigation = lazyNavigation;
            _viewFactory = viewFactory;
        }

        #endregion // Construction

        #region Operations (INavigator)

        public async Task PushAsync(string pageName, bool animated)
        {
            Page page = _viewFactory.ResolvePage(pageName);

            if (page == null)
            {
                return;
            }

            await _lazyNavigation.Value.PushAsync(page, animated);
        }

        public async Task PopAsync(bool animated)
        {
            await _lazyNavigation.Value.PopAsync(animated);
        }

        #endregion // Operations (INavigator)

    }
}