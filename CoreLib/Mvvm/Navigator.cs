using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Properties

        public IReadOnlyList<string> NavigationStack
        {
            get
            {
                return _lazyNavigation.Value.NavigationStack
                                            .Select(page => NamingConventions.RemoveViewOrViewModelEnding(page.GetType().Name))
                                            .ToList();
            }
        }

        public IReadOnlyList<string> ModalStack
        {
            get
            {
                return _lazyNavigation.Value.ModalStack
                                            .Select(page => NamingConventions.RemoveViewOrViewModelEnding(page.GetType().Name))
                                            .ToList();
            }
        }

        #endregion // Properties

        #region Operations

        public void RemovePage(string pageName)
        {
            Page page = _lazyNavigation.Value.NavigationStack
                                             .FirstOrDefault(pg => pg.GetType().Name == pageName + NamingConventions.ViewEnding);

            if (page != null)
            {
                _lazyNavigation.Value.RemovePage(page);
            }
        }

        public void InsertPageBefore(string pageName, string pageNameBefore)
        {
            Page page = _viewFactory.ResolvePage(pageName);
            Page pageBefore = _lazyNavigation.Value.NavigationStack
                                                   .FirstOrDefault(pg => pg.GetType().Name == pageNameBefore + NamingConventions.ViewEnding);

            if (page == null || pageBefore == null)
            {
                return;
            }

            _lazyNavigation.Value.InsertPageBefore(page, pageBefore);
        }

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

        public async Task PopToRootAsync(bool animated)
        {
            await _lazyNavigation.Value.PopToRootAsync(animated);
        }

        public async Task PushModalAsync(string pageName, bool animated)
        {
            Page page = _viewFactory.ResolvePage(pageName);

            if (page == null)
            {
                return;
            }

            await _lazyNavigation.Value.PushModalAsync(page, animated);
        }

        public async Task PopModalAsync(bool animated)
        {
            await _lazyNavigation.Value.PopModalAsync(animated);
        }

        #endregion // Operations

    }
}