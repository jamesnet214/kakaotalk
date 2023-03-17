# kakaotalk

> Jamesnet.WPF NugetPackage 설치

1. Kakao 프로젝트 생성
    - Starter
    - App : JamesApplication
3. Kakao.Forms 프로젝트 생성
    - KakaoWindow : JamesWindow
4. Kakao.Login 프로젝트 생성
5. Region
    - JamesRegion
7. ViewModules
    - IModule
8. DirectModules  
    - Region.RegisterViewWithRegion (Resolve<IRegion>)  
8. ViewModel
    - ObservableBase (Jamesnet.WPF.Mvvm)
9. Login Command
    - [RelayCommand] attribute
10. Kakao.Main 프로젝트 생성
11. Active MainContent
    - IRegionManager
    - IContainerProvider
12. Logout Command
    - Active LoginContent
13. KakaoViewModel 생성
    - RegisterViewWithRegion 폐기
    - Active LoginContent (대체)
