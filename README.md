# kakaotalk

Colors
- #fee500: 시그니쳐 노랑
- #423630: 시그니쳐 카카오
- #ececed: 메인메뉴 배경
- #acadb1: 메인메뉴 아이콘
- #343740: 메인메뉴 아이콘 선택
- #f2f2f2: 아이템 선택 배경

CI Geometry
> M76.01 89.49 L87.99 89.49 L87.99 89.49 L82 72.47 L76.01 89.49 Z M104,0C46.56,0,0,36.71,0,82c0,29.28,19.47,55,48.75,69.48-1.59,5.49-10.24,35.34-10.58,37.69,0,0-.21,1.76.93,2.43a3.14,3.14,0,0,0,2.48.15c3.28-.46,38-24.81,44-29A131.56,131.56,0,0,0,104,164c57.44,0,104-36.71,104-82S161.44,0,104,0ZM52.53,69.27c-.13,11.6.1,23.8-.09,35.22-.06,3.65-2.16,4.74-5,5.78a1.88,1.88,0,0,1-1,.07c-3.25-.64-5.84-1.8-5.92-5.84-.23-11.41.07-23.63-.09-35.23-2.75-.11-6.67.11-9.22,0-3.54-.23-6-2.48-5.85-5.83s1.94-5.76,5.91-5.82c9.38-.14,21-.14,30.38,0,4,.06,5.78,2.48,5.9,5.82s-2.3,5.6-5.83,5.83C59.2,69.38,55.29,69.16,52.53,69.27Zm50.4,40.45a9.24,9.24,0,0,1-3.82.83c-2.5,0-4.41-1-5-2.65l-3-7.78H72.85l-3,7.78c-.58,1.63-2.49,2.65-5,2.65a9.16,9.16,0,0,1-3.81-.83c-1.66-.76-3.25-2.86-1.43-8.52L74,63.42a9,9,0,0,1,8-5.92,9.07,9.07,0,0,1,8,5.93l14.34,37.76C106.17,106.86,104.58,109,102.93,109.72Zm30.32,0H114a5.64,5.64,0,0,1-5.75-5.5V63.5a6.13,6.13,0,0,1,12.25,0V98.75h12.75a5.51,5.51,0,1,1,0,11Zm47-4.52A6,6,0,0,1,169.49,108L155.42,89.37l-2.08,2.08v13.09a6,6,0,0,1-12,0v-41a6,6,0,0,1,12,0V76.4l16.74-16.74a4.64,4.64,0,0,1,3.33-1.34,6.08,6.08,0,0,1,5.9,5.58A4.7,4.7,0,0,1,178,67.55L164.3,81.22l14.77,19.57A6,6,0,0,1,180.22,105.23Z


## Friends

- Profile
- My Multi-Profile
- Friends With Birthdays
- Friends With Updates
- Favorites
- Channel
- Friends


<img width="325" alt="image" src="https://user-images.githubusercontent.com/52397976/227625862-4d45ad44-a6ba-40d0-953f-7faa6a98a753.png">

## 작업 순서
1. Friends 메뉴 기본 선택
2. ExapndButton 추가
3. VerticalMenuListItem 수정  
    - Path 수집
    - Trigger 추가  
4. FriendsBox 
    - FriendsModel 대체
      - Id, Name
    - DoubleClick Command 추가
4. Kakao.Talk 프로젝트 추가
    - TalkWindow 추가
    - TalkContent 추가
    - TalkTaskBarButton 추가
    - SendTextBox : TextBox 추가
    - ChatRichTextBox : CustomRichTextBox 추가    
5. RichTextBox 추가
    - Kakao.LayoutSupport.CustomRichTextBox : RichTextBox
    - ItemsSource(IEnumerable) DependencyProperty 추가
    - Changed 콜백 추가
    - Paragraph 로직 추가
6. Kakao.Talk.TextMessage 프로젝트 추가
    - TextMessageItem : Control 추가
    - 메시지타입 Send/Received
    - 말풍선 구현
    - Tail 패스 생성 (Blend)
    - override GetTextContainerItemForOverride 생성 (ChatRichTextBox)
7. TalkWindowManager 추가 (Core.Talkings), IoC
    - Dictionary<int, JamesWindow> _windows 
    - GetWindow(key) 메서드 추가
    - GetAllWindows() 메서드 추가 (List<keyValuePier>)
    - ResolveWindow 메서드 추가
      - 리플렉션 (Activator.CreateInstance<T>())
    - UnregisterWindow(key) 메서드 추가 (TalkWindow Clsoed 일때 목록 제거 관리)
    - event EventHandler WindowCountChanged 구현 (윈도우 관리목록이 변경될 때 이벤트)
      - 실행 (WindowCountChanged?.Invoke(this, EventArgs.Empty);
8. Kakao.Tests 추가 (Simulator)
    - SimulationWindow/SimulationViewModel 추가
    - Refresh Command 추가
    - Send Command 추가
    - Windows ListBox 추가
    - Send Form 추가
    - EventHub Subscribe => Refresh 연결
    - TalkWindowRefreshEvent : PubSubEvent 추가
    - TalkWindowRefreshArgs : EventArgs 추가
    
9. ChatStorage 추가, IoC
    - MessageModel 추가
      - Type, Message
    - Dic<FriendsModel, List<MessageModel>> Chats 데이터 저장소 선언
    - GetChats 데이터 로드하기 위한 메서드 구현
    - Send/Received 데이터 저장 메서드 구현
    
    
10. Models
- FriendsModel
- MessageModel

11. Interfaces
- IMessage
- IReceiveMessage
- ITalkInitializable

12. Add files

```
 create mode 100644 src/Kakao/Kakao.Core/Args/TalkWindowRefreshArgs.cs
 create mode 100644 src/Kakao/Kakao.Core/Events/TalkWindowRefreshPubSub.cs
 create mode 100644 src/Kakao/Kakao.Core/Interfaces/IMessage.cs
 create mode 100644 src/Kakao/Kakao.Core/Interfaces/IReceiveMessage.cs
 create mode 100644 src/Kakao/Kakao.Core/Interfaces/ITalkInitializable.cs
 create mode 100644 src/Kakao/Kakao.Core/Models/FriendsModel.cs
 create mode 100644 src/Kakao/Kakao.Core/Models/MessageModel.cs
 create mode 100644 src/Kakao/Kakao.Core/Talkings/ChatStorage.cs
 create mode 100644 src/Kakao/Kakao.Core/Talkings/TalkWindowManager.cs
 create mode 100644 src/Kakao/Kakao.LayoutSupport/Themes/Units/SendTextBox.xaml
 create mode 100644 src/Kakao/Kakao.LayoutSupport/Themes/Units/TalkTaskBarButton.xaml
 create mode 100644 src/Kakao/Kakao.LayoutSupport/UI/Units/CustomRichTextBox.cs
 create mode 100644 src/Kakao/Kakao.LayoutSupport/UI/Units/SendTextBox.cs
 create mode 100644 src/Kakao/Kakao.LayoutSupport/UI/Units/TalkTaskBarButton.cs
 create mode 100644 src/Kakao/Kakao.Talk.TextMessage/Kakao.Talk.TextMessage.csproj
 create mode 100644 src/Kakao/Kakao.Talk.TextMessage/Properties/AssemblyInfo.cs
 create mode 100644 src/Kakao/Kakao.Talk.TextMessage/Themes/Generic.xaml
 create mode 100644 src/Kakao/Kakao.Talk.TextMessage/Themes/Units/TextMessageItem.xaml
 create mode 100644 src/Kakao/Kakao.Talk.TextMessage/UI/Units/TextMessageItem.cs
 create mode 100644 src/Kakao/Kakao.Talk/Local/ViewModels/TalkContentViewModel.cs
 create mode 100644 src/Kakao/Kakao.Talk/UI/Units/ChatRichTextBox.cs
 create mode 100644 src/Kakao/Kakao.Talk/UI/Views/TalkWindow.cs
 create mode 100644 src/Kakao/Kakao.Tests/Kakao.Tests.csproj
 create mode 100644 src/Kakao/Kakao.Tests/Local/ViewModels/SimulationViewModel.cs
 create mode 100644 src/Kakao/Kakao.Tests/Properties/AssemblyInfo.cs
 create mode 100644 src/Kakao/Kakao.Tests/Themes/Generic.xaml
 create mode 100644 src/Kakao/Kakao.Tests/Themes/Views/SimulationWindow.xaml
 create mode 100644 src/Kakao/Kakao.Tests/UI/Views/SimulationWindow.cs
 rename src/Kakao/Kakao/{Settings => Properties}/DirectModules.cs (90%)
 rename src/Kakao/Kakao/{Settings => Properties}/ViewModules.cs (85%)
 rename src/Kakao/Kakao/{Settings => Properties}/WireDataContext.cs (77%)
```

13. DependencyProperties

```csharp
public static readonly DependencyProperty DoubleClickCommandProperty =
DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(BirthdaysBox), new PropertyMetadata(null));

public ICommand DoubleClickCommand
{
    get => (ICommand)GetValue(DoubleClickCommandProperty);
    set => SetValue(DoubleClickCommandProperty, value);
}
```

```csharp
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
        // 로직
    }
}
```

```csharp
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
```
