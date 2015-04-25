using System;

namespace CoreLib.Mvvm
{
    public class DefaultNamingConventions : INamingConventions
    {
        #region Properties

        public string ViewEnding
        {
            get { return "View"; }
        }

        public string ViewModelEnding
        {
            get { return "ViewModel"; }
        }

        #endregion // Properties

        #region Operations


        public string GetViewName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            return name.EndsWith(ViewEnding)
                ? name
                : name + ViewEnding;
        }

        public string GetViewModelName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            return name.EndsWith(ViewModelEnding)
                ? name
                : name + ViewModelEnding;
        }

        public string GetViewModelTitle(string name)
        {
            return name;
        }

        public string StripViewOrViewModelEnding(string className)
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