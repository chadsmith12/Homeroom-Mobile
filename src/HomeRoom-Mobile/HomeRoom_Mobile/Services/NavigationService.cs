using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Services;
using HomeRoom_Mobile.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(NavigationService))]
namespace HomeRoom_Mobile.Services
{
    /// <summary>
    /// NavigationService class that implements the INavigationService interface for navigation
    /// Defines and exposes the navigation service
    /// </summary>
    /// <seealso cref="HomeRoom_Mobile.Interfaces.INavigationService" />
    public class NavigationService : INavigationService
    {
        #region Private Fields
        /// <summary>
        /// The view model map
        /// holds a mapping between a view model (key) and a view (value)
        /// </summary>
        private readonly IDictionary<Type, Type> _viewModelMap = new Dictionary<Type, Type>();
        #endregion

        /// <summary>
        /// Gets or sets a reference to the current INavigation instance in Xamarin.Forms
        /// </summary>
        /// <value>
        /// The xamarin navigation.
        /// </value>
        public INavigation XamarinNavigation { get; set; }

        /// <summary>
        /// Gets a value indicating whether we can go back in the navigation stack.
        /// Can go back when more than one view on the stack
        /// </summary>
        /// <value>
        ///   <c>true</c> if we can go back; otherwise, <c>false</c>.
        /// </value>
        public bool CanGoBack => XamarinNavigation.NavigationStack != null && XamarinNavigation.NavigationStack.Count > 0;

        /// <summary>
        /// Registers the view mapping.
        /// Registers a mapping from a ViewModel to a View
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="view">The view.</param>
        public void RegisterViewMapping(Type viewModel, Type view)
        {
            _viewModelMap.Add(viewModel, view);
        }

        /// <summary>
        /// Goes back to the previous page in the navigation stack.
        /// This calls the OnCanGoBackchanged to update if we can go back in the navigation service
        /// </summary>
        /// <returns></returns>
        public async Task GoBack()
        {
            if (CanGoBack)
                await XamarinNavigation.PopAsync(true);

            OnCanGoBackChanged();
        }

        /// <summary>
        /// Navigates to the view model type.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns></returns>
        public async Task NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            await NavigateToView(typeof (TViewModel));

            // get the binding context of last view is of type BaseViewModel
            // we automatically call it's init method then
            var viewModel = XamarinNavigation.NavigationStack.Last().BindingContext as BaseViewModel;
            if (viewModel != null)
            {
                await viewModel.Init();
            }
        }

        public async Task NavigateTo<TViewModel, TParameter>(TParameter parameter) where TViewModel : BaseViewModel
        {
            await NavigateToView(typeof(TViewModel));

            // get the binding context of last view is of type BaseViewModel
            // we automatically call it's init method then
            var viewModel = XamarinNavigation.NavigationStack.Last().BindingContext as BaseViewModel<TParameter>;
            if (viewModel != null)
            {
                await viewModel.Init(parameter);
            }
        }

        /// <summary>
        /// Removes the last view from the stack.
        /// </summary>
        /// <returns></returns>
        public async Task RemoveLastView()
        {
            if (XamarinNavigation.NavigationStack.Any())
            {
                var lastView = XamarinNavigation.NavigationStack[XamarinNavigation.NavigationStack.Count - 2];
                XamarinNavigation.RemovePage(lastView);
            }
        }

        /// <summary>
        /// Clears the back stack.
        /// </summary>
        /// <returns></returns>
        public async Task ClearBackStack()
        {
            if (XamarinNavigation.NavigationStack.Count <= 1)
                return;

            for (var i = 0; i < XamarinNavigation.NavigationStack.Count - 1; i++)
            {
                XamarinNavigation.RemovePage(XamarinNavigation.NavigationStack[i]);
            }
        }

        /// <summary>
        /// Navigates to the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Invalid URI</exception>
        public async Task NavigateToUri(Uri uri)
        {
            if(uri == null)
                throw new ArgumentException("Invalid URI");

            Device.OpenUri(uri);
        }

        public event PropertyChangedEventHandler CanGoBackChanged;

        #region Private Methods

        /// <summary>
        /// Called when [can go back changed].
        /// </summary>
        private void OnCanGoBackChanged()
        {
            // when their is an event handler attatched we need to automatically invoke this event
            var handler = CanGoBackChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(nameof(CanGoBack)));
        }

        /// <summary>
        /// Navigates to the view that is mapped to the specified view model.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">No view found in View Mapping for the specified View Model.</exception>
        private async Task NavigateToView(Type viewModelType)
        {
            Type viewType;

            // we attempt to try to find this view model in the registered mappings we have
            // can't find the mapping then throw an exception as something is wrong
            if(!_viewModelMap.TryGetValue(viewModelType, out viewType))
                throw new ArgumentException("No view found in View Mapping for " + viewModelType.FullName + ".");

            // find the empty constructor for this view and invoke it to initialize this page
            var constructor = viewType.GetTypeInfo().DeclaredConstructors.FirstOrDefault(x => !x.GetParameters().Any());
            var view = constructor.Invoke(null) as Page;
            
            // ToDo: see if their is a way to modify this so the views binding context can automatically be set??

            await XamarinNavigation.PushAsync(view, true);
        }
        #endregion
    }
}
