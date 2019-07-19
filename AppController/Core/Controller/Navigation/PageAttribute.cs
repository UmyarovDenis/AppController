using System;
using System.Collections.Generic;

namespace AppController.Core.Controller.Navigation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ControllerPageAttribute : Attribute
    {
        private readonly Type _pageType;

        public ControllerPageAttribute(Type pageType)
        {
            _pageType = pageType;
        }
        public Type PageType
        {
            get { return _pageType; }
        }
    }
}
