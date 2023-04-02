using Kakao.LayoutSupport.UI.Units;
using Kakao.Talk.TextMessage.UI.Units;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Kakao.Talk.UI.Units
{
    internal class ChatRichTextBox : CustomRichTextBox
    {
        protected override Control GetContainerForItemOverride()
        {
            return new TextMessageItem();
        }
    }
}
