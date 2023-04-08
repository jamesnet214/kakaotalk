1. SSMS 설치
2. BlazorWebAssembly 프로젝트 생성 (Id, Hosted)
3. Database 마이그레이션
4. 로컬DB 확인
5. OAuth Google Nuget
```
builder.Services.AddAuthentication()
    .AddGoogle(o =>
    {
        o.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        o.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    })
    .AddIdentityServerJwt();
```

6. appsettings.json
```
  "Authentication": {
    "Google": {
      "ClientId": "...",
      "ClientSecret": "..."
    }
  },
```

8. Google Cloud Platform OAuth API 생성
9. index.html WPF 호출 스크립트 추가
```
window.sendAuthInfoToWpf = function (email) {
    window.chrome.webview.postMessage(email);
};
```
9. 인증 성공시 스크립트 호출
```
@page "/"
@using Microsoft.AspNetCore.Components.Authorization
@using System.Security.Claims;
@inject IJSRuntime JSRuntime
@inject AuthenticationStateProvider AuthenticationStateProvider

<PageTitle>Index</PageTitle>

<h1>Hello, world!</h1>

Welcome to your new app.

<SurveyPrompt Title="How is Blazor working for you?" />

<AuthorizeView>
    <Authorized>
        @{
            var name = @context.User.Identity?.Name;
            if (name != null)
            {
                string userEmail = name;
                JSRuntime.InvokeVoidAsync("sendAuthInfoToWpf", name);
            }
        }
    </Authorized>
</AuthorizeView>
```
10. Kakao.Login GoogleWindow 파일 추가
11. KakaoWebView2 : WebView2 클래스 추가
12. LoginCompletedCommand ICommand 추가
12. WebMessageReceived 이벤트 추가
```
private void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
{
    string userEmail = e.TryGetWebMessageAsString();
    LoginCompletedCommand.Execute(userEmail);
}
```
13. GoogleViewModel LoginCompletedCommand 추가
14. EventHub Publish 처리
15. OAuthCompletedPubSub : PubSub<OauthCompletedArgs> 추가
16. LoginContentViewModel EventHub Subscribe OauthCompleted 생성
17. GoogleWindow Close
18. with GPT
19. Hubs/ChatHub : Hub 생성
20. SyncFriends 생성
```
public async Task SyncFriends(MessageModel request)
{
    List<FriendsModel> friends = new();
    foreach (var user in _contenxt.Users.ToList()) 
    {
        friends.Add(new FriendsModel() { Id = user.Id, Email = user.Email, Name = user.UserName });       
    }

    ResponseFriendsPack pack = new();
    pack.Friends = friends;

    await Clients.Caller.SendAsync(pack);
}
    
public class ResponseFriendsPack : IClientMethod
{
    public List<FriendsModel> Friends { get; set; }
}

public class FriendsModel
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}
```

21. Service 추가
```
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<ChatService>();

builder.Services.AddSignalR(options =>
{
    options.MaximumReceiveMessageSize = 1024 * 1024 * 10; // 1 MB
});

...

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/chathub");
});

```
22. Kakao.Receiver 프로젝트 추가
```
public class HubManager
{
    public HubConnection Connection;
    private IEventHub _ea;

    public int Test { get; private set; }

    public static HubManager Create()
    {
        HubManager hubManager = new();
        hubManager.Connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7287/chathub")
            .Build();

        return hubManager;
    }

    public async void Start(IEventHub ea)
    {
        _ea = ea;

        Connection.On<List<FriendsModel>>("ResponseFriendsPack", (message) =>
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                SyncFriendsArgs args = new();
                args.Friends = message;
                _ea.Publish<SyncFriendsPubSub, SyncFriendsArgs>(args);
            });
        });

        try
        {
            await Connection.StartAsync();
        }
        catch (Exception ex)
        {
        }
    }
}
```

23. HubManager 등록
```
HubManager conn = HubManager.Create();

conn.Connection.Closed += async (error) =>
{
    await Task.Delay(new Random().Next(1, 5) * 1000);
    await conn.Connection.StartAsync();
};

containerRegistry.RegisterInstance(conn);
```
    
24. SignalR 호출
```
await _hubManager.Connection.InvokeAsync("SyncFriends", new MessageModel());
```
