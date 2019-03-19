using System;
using System.Collections.Generic;
using System.Windows;

namespace AppController.Core.Activation
{
    public interface IViewFactory
    {
        Window GetWindow<TView>() 
            where TView : FrameworkElement;
        Window GetWindow<TView, TViewModel>(IEnumerable<Action<TView>> viewActions, IEnumerable<Action<TViewModel>> viewModelActions)
            where TView : FrameworkElement where TViewModel : class;
        TView GetView<TView>() 
            where TView : FrameworkElement;
        TView GetView<TView>(Action<TView> viewAction) 
            where TView : FrameworkElement;
        TView GetView<TView>(Action<TView> viewAction, params object[] viewArgs)
            where TView : FrameworkElement;
        TView GetView<TView, TViewModel>(Action<TViewModel> viewModelAction) 
            where TView : FrameworkElement where TViewModel : class;
        TView GetView<TView, TViewModel>(Action<TViewModel> viewModelAction, params object[] viewModelArgs) 
            where TView : FrameworkElement where TViewModel : class;
    }
}
