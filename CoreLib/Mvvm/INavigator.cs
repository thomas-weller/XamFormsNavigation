using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLib.Mvvm
{
    public interface INavigator
    {
        IReadOnlyList<string> NavigationStack { get; }
        IReadOnlyList<string> ModalStack { get; }

        void RemovePage(string pageName);
        void InsertPageBefore(string pageName, string pageNameBefore);

        Task PushAsync(string pageName, bool animated);
        Task PopAsync (bool animated);
        Task PopToRootAsync (bool animated);

        Task PushModalAsync(string pageName, bool animated);
        Task PopModalAsync (bool animated);
    }
}

/*
public interface INavigation
{
 * 
}
*/