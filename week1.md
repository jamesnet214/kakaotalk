# kakaotalk

> Jamesnet.WPF NugetPackage 설치

### 1. Kakao 프로젝트 생성
- Starter
- App : JamesApplication
- CreateShell
### 2. Kakao.Forms 프로젝트 생성
- KakaoWindow : JamesWindow
### 3. Kakao.Login 프로젝트 생성
- LoginContent : JamesContent
### 4. Region
- MainRegion (KakaoWindow)
### 5. ViewModules
- IModule
### 6. DirectModules  
- #Region.RegisterViewWithRegion (Resolve<IRegion>)  
### 7. ViewModel
- ObservableBase (Jamesnet.WPF.Mvvm)
### 8. Login Command
- [RelayCommand] attribute
### 9. Kakao.Main 프로젝트 생성
- MainContent : JamesContent
### 10. Active MainContent
- IRegionManager
- IContainerProvider
### 11. Logout Command
- Active LoginContent
### 12. KakaoViewModel 생성
- RegisterViewWithRegion 폐기
- Active LoginContent (대체)
### 13. FriendsContent 생성
### 14. VerticalMenuList 추가
- ListBox/ListBoxItem
