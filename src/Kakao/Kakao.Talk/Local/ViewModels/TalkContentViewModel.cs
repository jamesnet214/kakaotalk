using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Names;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Talk.Local.ViewModels
{
    public partial class TalkContentViewModel : ObservableBase
    {
        [ObservableProperty]
        private string _sendText;

        public TalkContentViewModel()
        {
            SendText = "";
        }

        [RelayCommand]
        private void Send()
        {
            SendText = ""; 
        }
    }
}
