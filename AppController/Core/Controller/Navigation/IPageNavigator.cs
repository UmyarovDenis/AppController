using System.Collections.Generic;
using System.Windows;

namespace AppController.Core.Controller.Navigation
{
    public interface IPageNavigator
    {
        IEnumerable<FrameworkElement> Pages { get; }
        bool CanGetNextPage { get; }
        bool CanGetPreviousPage { get; }
        FrameworkElement this[int index] { get; }
        FrameworkElement NextPage();
        FrameworkElement PrevPage();
    }
}
