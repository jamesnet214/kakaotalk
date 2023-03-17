# kakaotalk

> Jamesnet.WPF NugetPackage 설치

## 1. Kakao 프로젝트 생성
    - Starter
    - App : JamesApplication
## 3. Kakao.Forms 프로젝트 생성
    - KakaoWindow : JamesWindow
## 4. Kakao.Login 프로젝트 생성
## 5. Region
    - JamesRegion
## 7. ViewModules
    - IModule
## 8. DirectModules  
    - Region.RegisterViewWithRegion (Resolve<IRegion>)  
## 9. ViewModel
    - ObservableBase (Jamesnet.WPF.Mvvm)
## 10. Login Command
    - [RelayCommand] attribute
## 11. Kakao.Main 프로젝트 생성
## 12. Active MainContent
    - IRegionManager
    - IContainerProvider
## 13. Logout Command
    - Active LoginContent
## 14. KakaoViewModel 생성
    - RegisterViewWithRegion 폐기
    - Active LoginContent (대체)
