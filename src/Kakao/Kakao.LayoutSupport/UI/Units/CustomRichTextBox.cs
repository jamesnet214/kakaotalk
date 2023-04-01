using Kakao.Core.Interfaces;
using Kakao.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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
            FlowDocument document = new();

            // 로직
            if(ItemsSource != null) 
            {
                foreach (var item in ItemsSource)
                {
                    var control = GetTextContainerItemForOverride();
                    control.DataContext = item;
                    
                    InlineUIContainer buc = new();
                    buc.Child = control;

                    Paragraph p = new();
                    p.Margin = new(0);

                    if (item is IMessage message)
                    {
                        p.TextAlignment = message.Type == "Send" ? TextAlignment.Right : TextAlignment.Left;
                    }
                    p.Inlines.Add(buc);
                    document.Blocks.Add(p);
                }
            }

            Document = document;

            ScrollToEnd();
        }

        protected virtual Control GetTextContainerItemForOverride()
        {
            Control control = new();
            return control;
        }
    }
}
