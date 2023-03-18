using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Ioc;
using Prism.Regions;

namespace Kakao.Login.Local.ViewModels
{
    public partial class LoginContentViewModel : ObservableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;

        public LoginContentViewModel(IRegionManager regionManager, IContainerProvider containerProvider) 
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
        }

        [RelayCommand]
        private void Login()
        {
            IRegion mainRegion = _regionManager.Regions["MainRegion"];
            IViewable friendsConttent = _containerProvider.Resolve<IViewable>("FriendsContent");

            if (!mainRegion.Views.Contains(friendsConttent))
            {
                mainRegion.Add(friendsConttent);
            }
            mainRegion.Activate(friendsConttent);
        }
    }
}
