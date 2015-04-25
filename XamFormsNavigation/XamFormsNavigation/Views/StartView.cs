using Autofac;
using CoreLib.Mvvm;
using Xamarin.Forms;

namespace XamFormsNavigation.Views
{
    public class StartView : ContentPage
    {
        private readonly IComponentContext _componentContext;

        public StartView(IComponentContext componentContext)
        {
            _componentContext = componentContext;

            var button = new Button
            {
                Text = "Start",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            button.Clicked += async (sender, e) =>
            {
                var navigator = _componentContext.Resolve<INavigator>();

                await navigator.PushAsync("First", true);
            };

            Content = new StackLayout { Children = { button } };
        }
    }
}