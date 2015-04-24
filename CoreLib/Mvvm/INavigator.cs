using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLib.Mvvm
{
    public interface INavigator
    {
        IReadOnlyList<string> NavigationStack { get; }
        IReadOnlyList<string> ModalStack { get; }

        Task PushAsync(string pageName, bool animated);
        Task PopAsync (bool animated);
        Task PopToRootAsync (bool animated);
    }
}

/*
public interface INavigation
{
 * 
    void RemovePage (Page page);
    void InsertPageBefore (Page page, Page before);

    Task PushModalAsync (Page page, bool animated);
    Task PopModalAsync (bool animated);
}
*/