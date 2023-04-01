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

namespace Kakao.Talk.TextMessage.UI.Units
{
    public class TextMessageItem : Control
    {
        static TextMessageItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextMessageItem), new FrameworkPropertyMetadata(typeof(TextMessageItem)));
        }
    }
}
