using Xamarin.Forms;

namespace CoreLib.Mvvm
{
    public interface IViewFactory
    {
        Page ResolvePage(string name);
    }
}