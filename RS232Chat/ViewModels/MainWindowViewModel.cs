using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using RS232Chat.Views;

namespace RS232Chat.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IRegionManager _regionManager;
        IContainerExtension _container;
        SetupView _setupView;

        public DelegateCommand<string> NavigateCommand { get; private set; }
        
        public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _container = container;
            _setupView = container.Resolve<SetupView>();

            NavigateCommand = new DelegateCommand<string>(Navigate);
            Initialize();
        }

        private void Initialize()
        {
            // Select the initial view
            _regionManager.RegisterViewWithRegion("ActiveRegion", typeof(SetupView));
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ActiveRegion", navigatePath);
        }
    }
}
