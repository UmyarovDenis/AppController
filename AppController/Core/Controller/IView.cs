using System;
using System.Windows;

namespace AppController.Core.Controller
{
    public interface IView<TView, TViewModel> where TView : FrameworkElement where TViewModel : class
    {
        void Run();
        bool? RunDialog();
        TResult RunDialogWithResult<TResult>(Func<TViewModel, TResult> executor);
    }
}
