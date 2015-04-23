using System;

using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public class SecondView : ContentPage
	{
		public SecondView ()
		{
			var next = new Button { Text = "Next" };
			next.Clicked += async (sender, e) => {
				await Navigation.PushAsync (new ThirdView());
			};
			var prev = new Button { Text = "Prev" };
			prev.Clicked += async (sender, e) => {
				await Navigation.PopAsync();
			};

			Title = "Page 2";
			Content = new StackLayout { 
				BackgroundColor = Color.Yellow,
				Children = {
					new Label { Text = "Page 2", FontSize=Device.GetNamedSize(NamedSize.Large, typeof(Label)) },
					next, prev
				}
			};
		}
	}
}


