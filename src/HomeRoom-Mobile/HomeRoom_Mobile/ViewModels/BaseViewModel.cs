using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;

namespace HomeRoom_Mobile.ViewModels
{
    /// <summary>
    /// BaseViewModel that all ViewModels inherit from
    /// Defines all properties that a view model may need
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Private Fields
        private bool _isBusy;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>
        /// The navigation service.
        /// </value>
        protected INavigationService NavigationService { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating that we are busy.
        /// This could be because data is being loaded or some other lengthy processing
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is busy; otherwise, <c>false</c>.
        /// </value>
        public bool IsBusy
        {
            get { return _isBusy;}
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                OnIsBusyChanged();
            }
        }
        #endregion

        #region Property Changed        
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Called when [is busy changed].
        /// </summary>
        protected virtual void OnIsBusyChanged()
        {
            
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance of a view model without using a constructor.
        /// This is useful when a ViewModel needs to be refreshed
        /// </summary>
        /// <returns></returns>
        public abstract Task Init();

        #endregion
    }

    /// <summary>
    /// A generic typed BaseViewModel class that is used when a ViewModel pass a strongly typed parameter in
    /// </summary>
    /// <typeparam name="TParameter">The type of the parameter.</typeparam>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class BaseViewModel<TParameter> : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel{TParameter}"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        protected BaseViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance of a view model without using a constructor.
        /// This is useful when a ViewModel needs to be refreshed
        /// </summary>
        /// <returns></returns>
        public override async Task Init()
        {
            await Init(default(TParameter));
        }

        /// <summary>
        /// Initializes the view model with the specified strongly typed parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public abstract Task Init(TParameter parameter);

        #endregion
    }
}
