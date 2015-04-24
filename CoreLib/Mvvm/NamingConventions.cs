using System;

namespace CoreLib.Mvvm
{
    internal static class NamingConventions
    {
        #region Constants

        public const string ViewEnding = "View";
        public const string ViewModelEnding = "ViewModel";

        #endregion // Constants

        #region Operations

        public static string GetViewName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            return name.EndsWith(ViewEnding)
                ? name
                : name + "View";
        }

        public static string GetViewModelName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            return name.EndsWith(ViewModelEnding)
                ? name
                : name + "ViewModel";
        }

        public static string GetViewModelTitle(string name)
        {
            return name;
        }

        public static string RemoveViewOrViewModelEnding(string className)
        {
            if (className == null)
            {
                throw new ArgumentNullException("className");
            }

            if (className.EndsWith(ViewModelEnding))
            {
                return className.Substring(0, className.Length - ViewModelEnding.Length);
            }
            
            if (className.EndsWith(ViewEnding))
            {
                return className.Substring(0, className.Length - ViewEnding.Length);
            }

            return className;
        }

        #endregion // Operations

    }
}