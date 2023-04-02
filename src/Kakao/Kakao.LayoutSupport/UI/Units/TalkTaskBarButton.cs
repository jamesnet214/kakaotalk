using System.Windows;
using System.Windows.Controls;

namespace Kakao.LayoutSupport.UI.Units
{
    public class TalkTaskBarButton : Button
    {
        static TalkTaskBarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TalkTaskBarButton), new FrameworkPropertyMetadata(typeof(TalkTaskBarButton)));
        }
    }
}
