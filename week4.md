1. SSMS 설치
2. BlazorWebAssembly 프로젝트 생성 (Id, Hosted)
3. Database 마이그레이션
4. 로컬DB 확인
5. OAuth Google Nuget
6. appjson
7. Google Cloud Platform OAuth API 생성
8. index.html WPF 호출 스크립트 추가
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
