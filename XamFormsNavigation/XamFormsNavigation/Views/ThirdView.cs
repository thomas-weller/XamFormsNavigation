using System;

using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public class ThirdView : ContentPage
	{
		public ThirdView ()
		{
			var next = new Button { Text = "Next" };
			next.Clicked += async (sender, e) => {
				await Navigation.PushAsync (new FourthView());
			};
			var prev = new Button { Text = "Prev" };
			prev.Clicked += async (sender, e) => {
				await Navigation.PopAsync();
			};

			Title = "Page 3";
			Content = new StackLayout { 
				BackgroundColor = Color.Green,
				Children = {
					new Label { Text = "Page 3", FontSize=Device.GetNamedSize(NamedSize.Large, typeof(Label)) }
					,next,prev
				}
			};
		}
	}
}


