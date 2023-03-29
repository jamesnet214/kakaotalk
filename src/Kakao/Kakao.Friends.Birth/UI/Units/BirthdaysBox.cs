using Kakao.LayoutSupport.UI.Units;
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

namespace Kakao.Friends.Birth.UI.Units
{
    public class BirthdaysBox : FriendsBox
    {
        public static readonly DependencyProperty DoubleClickCommandProperty =
        DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(BirthdaysBox), new PropertyMetadata(null));

        public ICommand DoubleClickCommand
        {
            get => (ICommand)GetValue(DoubleClickCommandProperty);
            set => SetValue(DoubleClickCommandProperty, value);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new BirthdaysBoxItem();
        }

        public BirthdaysBox()
        {
            MouseDoubleClick += BirthdaysBox_MouseDoubleClick;
        }

        private void BirthdaysBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement fe)
            {
                DoubleClickCommand?.Execute(fe.DataContext);
            }
        }
    }
}
