using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kakao.Friends.Favorites.UI.Units
{
    public class FavoriteBoxItem : ListBoxItem
    {
        static FavoriteBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FavoriteBoxItem), new FrameworkPropertyMetadata(typeof(FavoriteBoxItem)));
        }
    }
}
