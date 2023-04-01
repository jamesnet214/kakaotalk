using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Kakao.LayoutSupport.UI.Units
{
    public class SendTextBox : TextBox
    {
        public static readonly DependencyProperty EnterCommandProperty = DependencyProperty.Register("EnterCommand", typeof(ICommand), typeof(SendTextBox));

        static SendTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SendTextBox), new FrameworkPropertyMetadata(typeof(SendTextBox)));
        }

        public ICommand EnterCommand
        {
            get => (ICommand)GetValue(EnterCommandProperty);
            set => SetValue(EnterCommandProperty, value);
        }

        public SendTextBox()
        {
            PreviewKeyDown += SendTextBox_PreviewKeyDown;
        }

        private void SendTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.IsKeyDown(Key.LeftShift))
            {
                // Alt + Enter 키 조합이 눌렸을 때 개행 처리를 합니다.
                int caretIndex = this.CaretIndex;
                SetValue(TextProperty, this.Text.Insert(caretIndex, Environment.NewLine));
                this.CaretIndex = caretIndex + Environment.NewLine.Length;
                e.Handled = true;
            }
            else if (e.Key == Key.Enter && EnterCommand != null && EnterCommand.CanExecute(null))
            {
                EnterCommand.Execute(null);
            }
        }
    }
}
