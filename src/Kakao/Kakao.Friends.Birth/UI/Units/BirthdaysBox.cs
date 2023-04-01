using Kakao.LayoutSupport.UI.Units;
using System.Windows;
using System.Windows.Input;

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
