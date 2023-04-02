using System.Windows;
using System.Windows.Controls;

namespace Kakao.Main.UI.Units
{
    public class VerticalMenuListItem : ListBoxItem
    {
        static VerticalMenuListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VerticalMenuListItem), new FrameworkPropertyMetadata(typeof(VerticalMenuListItem)));
        }
    }
}
