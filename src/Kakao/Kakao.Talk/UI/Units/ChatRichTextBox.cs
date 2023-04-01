using Kakao.LayoutSupport.UI.Units;
using Kakao.Talk.TextMessage.UI.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kakao.Talk.UI.Units
{
    public class ChatRichTextBox : CustomRichTextBox
    {
        protected override Control GetTextContainerItemForOverride()
        {
            return new TextMessageItem();
        }
    }
}
