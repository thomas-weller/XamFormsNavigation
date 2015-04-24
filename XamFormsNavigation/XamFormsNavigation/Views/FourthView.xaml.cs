using System;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamFormsNavigation.ViewModels;

namespace XamFormsNavigation.Views
{
    public partial class FourthView : ContentPage
    {
        public FourthView()
        {
            InitializeComponent();
        }

        private async void ViewNavigationStack_Clicked(object sender, EventArgs e)
        {
            var viewModel = (FourthViewModel)BindingContext;

            var stringBuilder = new StringBuilder(viewModel.Navigator.NavigationStack[0]);

            foreach (string s in viewModel.Navigator.NavigationStack.Skip(1))
            {
                stringBuilder.Append("\n" + s);
            }

            await DisplayAlert("Navigation Stack", stringBuilder.ToString(), "OK");
        }

    }
}
