using System.Collections;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using Kakao.Core.Interfaces;

namespace Kakao.LayoutSupport.UI.Units
{
    public class CustomRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CustomRichTextBox), new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public CustomRichTextBox()
        {
            Document = new FlowDocument();
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomRichTextBox richTextBox = d as CustomRichTextBox;

            if (e.OldValue is INotifyCollectionChanged oldCollection)
            {
                oldCollection.CollectionChanged -= richTextBox.OnCollectionChanged;
            }

            if (e.NewValue is INotifyCollectionChanged newCollection)
            {
                newCollection.CollectionChanged += richTextBox.OnCollectionChanged;
            }

            richTextBox.UpdateFlowDocument();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateFlowDocument();
        }

        private void UpdateFlowDocument()
        {
            FlowDocument document = new FlowDocument();

            if (ItemsSource != null)
            {
                foreach (var item in ItemsSource)
                {
                    var control = GetContainerForItemOverride();
                    control.DataContext = item;
                    Paragraph paragraph = new();

                    if (item is IMessage message)
                    { 
                        paragraph.TextAlignment = message.Type == "Send" ? TextAlignment.Right : TextAlignment.Left;
                    }

                    paragraph.Margin = new(0);
                    paragraph.Inlines.Add(control);
                    document.Blocks.Add(paragraph);
                }
            }
            Document = document;
            ScrollToEnd();
        }

        protected virtual Control GetContainerForItemOverride()
        {
            Control control = new();

            return control;
        }
    }
}
