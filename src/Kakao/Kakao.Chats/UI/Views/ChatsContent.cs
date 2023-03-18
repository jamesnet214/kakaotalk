using Jamesnet.Wpf.Controls;
using System.Windows;

namespace Kakao.Chats.UI.Views
{
    public class ChatsContent : JamesContent
    {
        static ChatsContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChatsContent), new FrameworkPropertyMetadata(typeof(ChatsContent)));
        }

        public ChatsContent()
        {

        }
    }
}
