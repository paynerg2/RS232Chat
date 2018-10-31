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
        
        public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _container = container;
            _setupView = container.Resolve<SetupView>();

            Initialize();
        }

        private void Initialize()
        {
            // Select the initial view
            _regionManager.RegisterViewWithRegion("ActiveRegion", typeof(SetupView));
        }
    }
}
