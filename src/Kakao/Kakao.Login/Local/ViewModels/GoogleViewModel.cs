using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Names;
using Kakao.Login.UI.Views;
using Prism.Ioc;
using Prism.Regions;

namespace Kakao.Login.Local.ViewModels
{
    public partial class GoogleViewModel : ObservableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;
        private readonly IEventHub _eventHub;

        public GoogleViewModel(IEventHub eventHub) 
        {
            _eventHub = eventHub;
        }

        [RelayCommand]
        private void Completed(string email)
        {
            OauthCompletedArgs args = new();
            args.Email = email;
            _eventHub.Publish<OAuthCompletedPubSub, OauthCompletedArgs>(args);
        }
    }
}
