using CommunityToolkit.Mvvm.ComponentModel;
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
        private readonly IEventHub _eventHub;
        [ObservableProperty]
        private string _loginUrl;

        public GoogleViewModel(IEventHub eventHub) 
        {
            _eventHub = eventHub;
            LoginUrl = "https://localhost:7151/Identity/Account/Login?returnUrl=%2Fauthentication%2Flogin";
        }

        [RelayCommand]
        private void LoginCompleted(string email)
        {
            LoginCompletedArgs args = new();
            args.Email = email;
            _eventHub.Publish<LoginCompletedPubSub, LoginCompletedArgs>(args);
        }
    }
}
