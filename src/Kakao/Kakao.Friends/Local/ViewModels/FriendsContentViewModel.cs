using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Names;
using Kakao.Talk.UI.Views;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;

namespace Kakao.Friends.Local.ViewModels
{
    public partial class FriendsContentViewModel : ObservableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;

        public FriendsContentViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
        }

        [RelayCommand]
        private void DoubleClick(object data)
        {
            Window window = new();
            window.Content = new TalkContent();
            window.ShowDialog();
        }

        [RelayCommand]
        private void Logout()
        {
            IRegion mainRegion = _regionManager.Regions[RegionNameManager.MainRegion];
            IViewable loginContent = _containerProvider.Resolve<IViewable>(ContentNameManager.Login);

            if (!mainRegion.Views.Contains(loginContent)) 
            {
                mainRegion.Add(loginContent);
            }
            mainRegion.Activate(loginContent);
        }
    }
}
