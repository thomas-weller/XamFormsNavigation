namespace CoreLib.Mvvm
{
    public interface INamingConventions
    {
        string ViewEnding { get; }
        string ViewModelEnding { get; }

        string GetViewName(string name);
        string GetViewModelName(string name);
        string GetViewModelTitle(string name);

        string StripViewOrViewModelEnding(string className);
    }
}