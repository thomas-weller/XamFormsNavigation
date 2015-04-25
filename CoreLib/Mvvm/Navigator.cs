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
        private readonly INamingConventions _namingConventions;

        #endregion // Fields

        #region Construction

        public Navigator(Lazy<INavigation> lazyNavigation, INamingConventions namingConventions, IViewFactory viewFactory)
        {
            _lazyNavigation = lazyNavigation;
            _namingConventions = namingConventions;
            _viewFactory = viewFactory;
        }

        #endregion // Construction

        #region Properties

        public IReadOnlyList<string> NavigationStack
        {
            get
            {
                return _lazyNavigation.Value.NavigationStack
                                            .Select(page => _namingConventions.StripViewOrViewModelEnding(page.GetType().Name))
                                            .ToList();
            }
        }

        public IReadOnlyList<string> ModalStack
        {
            get
            {
                return _lazyNavigation.Value.ModalStack
                                            .Select(page => _namingConventions.StripViewOrViewModelEnding(page.GetType().Name))
                                            .ToList();
            }
        }

        #endregion // Properties

        #region Operations

        public void RemovePage(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            string pageName = _namingConventions.GetViewName(name);
            Page page = _lazyNavigation.Value.NavigationStack
                                             .FirstOrDefault(pg => pg.GetType().Name == pageName);

            if (page != null)
            {
                _lazyNavigation.Value.RemovePage(page);
            }
        }

        public void InsertPageBefore(string name, string nameBefore)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (nameBefore == null)
            {
                throw new ArgumentNullException("nameBefore");
            }

            string pageNameBefore = _namingConventions.GetViewName(nameBefore);
            Page page = _viewFactory.ResolvePage(name);
            Page pageBefore = _lazyNavigation.Value.NavigationStack
                                                   .FirstOrDefault(pg => pg.GetType().Name == pageNameBefore);

            if (page == null || pageBefore == null)
            {
                return;
            }

            _lazyNavigation.Value.InsertPageBefore(page, pageBefore);
        }

        public async Task PushAsync(string name, bool animated)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            Page page = _viewFactory.ResolvePage(name);

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

        public async Task PushModalAsync(string name, bool animated)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            Page page = _viewFactory.ResolvePage(name);

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