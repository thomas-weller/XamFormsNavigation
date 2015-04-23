using System.Threading.Tasks;

namespace CoreLib.Mvvm
{
    public interface INavigator
    {
        Task PushAsync(string pageName, bool animated);
    }
}

/*
public interface INavigation
{
    IReadOnlyList NavigationStack { get; }
    IReadOnlyList ModalStack { get; }
    void RemovePage (Page page);
    void InsertPageBefore (Page page, Page before);
    Task PushAsync (Page page);
    Task PopAsync ();
    Task PopToRootAsync ();
    Task PushModalAsync (Page page);
    Task PopModalAsync ();
    Task PushAsync (Page page, bool animated);
    Task PopAsync (bool animated);
    Task PopToRootAsync (bool animated);
    Task PushModalAsync (Page page, bool animated);
    Task PopModalAsync (bool animated);
}
*/