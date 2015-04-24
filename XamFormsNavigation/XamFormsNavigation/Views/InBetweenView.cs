using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public class InBetweenView : ContentPage
	{
		public InBetweenView ()
		{
			Title = "Page 3a";
			Content = new StackLayout { 
				BackgroundColor = Color.Blue,
				Children = {
					new Label { Text = "Page 3a", FontSize=Device.GetNamedSize(NamedSize.Large, typeof(Label)) }
				}
			};
		}
	}
}


