using System.Windows;
using System.Windows.Controls;

namespace Kakao.LayoutSupport.UI.Units
{
    public class PlaceholderPasswordBox : TextBox
    {
        public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.Register(nameof(PlaceholderText), typeof(string), typeof(PlaceholderPasswordBox), new PropertyMetadata(""));
        
        static PlaceholderPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlaceholderPasswordBox), new FrameworkPropertyMetadata(typeof(PlaceholderPasswordBox)));
        }

        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_PasswordBox") is PasswordBox pwd)
            {
                pwd.PasswordChanged += Pwd_PasswordChanged;
            }
        }

        private void Pwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox pwd)
            {
                SetValue(TextProperty, pwd.Password);
            }
        }

        private void CustomPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == this)
            {
                PasswordBox passwordBox = GetTemplateChild("PART_PasswordBox") as PasswordBox;
                if (passwordBox != null)
                {
                    passwordBox.Focus();
                }
            }
        }
    }
}
