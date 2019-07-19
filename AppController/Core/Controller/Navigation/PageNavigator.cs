using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AppController.Core.Controller.Navigation
{
    public class PageNavigator : IPageNavigator
    {
        private LinkedList<FrameworkElement> _pages;
        private LinkedListNode<FrameworkElement> _currentPage;

        public PageNavigator(IEnumerable<FrameworkElement> pages)
        {
            if (pages == null || pages.Count() == 0)
                throw new ArgumentException("Pages collection was null or elements is missing");

            _pages = new LinkedList<FrameworkElement>(pages);
            _currentPage = _pages.First;
        }

        public IEnumerable<FrameworkElement> Pages
        {
            get
            {
                return _pages.ToList();
            }
        }
        public FrameworkElement this[int index]
        {
            get
            {
                return _pages.ElementAt(index);
            }
        }
        public bool CanGetNextPage
        {
            get
            {
                return _currentPage.Next != null;
            }
        }
        public bool CanGetPreviousPage
        {
            get
            {
                return _currentPage.Previous != null;
            }
        }
        public FrameworkElement NextPage()
        {
            if(_currentPage.Next != null)
            {
                _currentPage = _currentPage.Next;
                return _currentPage.Value;
            }
            else
            {
                return null;
            } 
        }
        public FrameworkElement PrevPage()
        {
            if (_currentPage.Previous != null)
            {
                _currentPage = _currentPage.Previous;
                return _currentPage.Value;
            }
            else
            {
                return null;
            }
        }
    }
}
