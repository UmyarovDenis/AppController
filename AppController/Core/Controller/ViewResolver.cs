using AppController.Core.Activation;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AppController.Core.Controller
{
    public class ViewResolver<TView, TViewModel> : IView<TView, TViewModel> 
        where TView : FrameworkElement where TViewModel : class
    {
        protected readonly List<Action<TView>> _viewActions;
        protected readonly List<Action<TViewModel>> _viewModelActions;

        private readonly IViewFactory _viewFactory;

        public ViewResolver(IViewFactory viewFactory)
        {
            _viewActions = new List<Action<TView>>();
            _viewModelActions = new List<Action<TViewModel>>();

            _viewFactory = viewFactory;
        }
        public void Run()
        {
            try
            {
                Window window = _viewFactory.GetWindow<TView, TViewModel>(_viewActions, _viewModelActions);

                window.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RunDialog()
        {
            try
            {
                Window window = _viewFactory.GetWindow<TView, TViewModel>(_viewActions, _viewModelActions);

                window.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public TResult RunDialogWithResult<TResult>(Func<TViewModel, TResult> executor)
        {
            try
            {
                Window window = _viewFactory.GetWindow<TView, TViewModel>(_viewActions, _viewModelActions);

                if (window.ShowDialog() == true)
                {
                    return executor(window.DataContext as TViewModel);
                }

                return default(TResult);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
