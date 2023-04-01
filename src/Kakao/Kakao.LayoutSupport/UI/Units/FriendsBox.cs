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

namespace Kakao.LayoutSupport.UI.Units
{
    public class FriendsBox : ListBox
    {
        public static readonly DependencyProperty DoubleClickCommandProperty =
        DependencyProperty.Register(
            "DoubleClickCommand",
            typeof(ICommand),
            typeof(FriendsBox),
            new PropertyMetadata(null));

        public ICommand DoubleClickCommand
        {
            get { return (ICommand)GetValue(DoubleClickCommandProperty); }
            set { SetValue(DoubleClickCommandProperty, value); }
        }

        static FriendsBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FriendsBox), new FrameworkPropertyMetadata(typeof(FriendsBox)));
        }

        public FriendsBox()
        { 
            
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if(e.OriginalSource is FrameworkElement fe && fe.DataContext != null)
            {
                DoubleClickCommand?.Execute(fe.DataContext);
            }
        }
    }
}
