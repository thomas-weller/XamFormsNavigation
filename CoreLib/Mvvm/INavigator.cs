using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLib.Mvvm
{
    public interface INavigator
    {
        IReadOnlyList<string> NavigationStack { get; }
        IReadOnlyList<string> ModalStack { get; }

        void RemovePage(string name);
        void InsertPageBefore(string name, string nameBefore);

        Task PushAsync(string name, bool animated);
        Task PopAsync (bool animated);
        Task PopToRootAsync (bool animated);

        Task PushModalAsync(string name, bool animated);
        Task PopModalAsync (bool animated);
    }
}
