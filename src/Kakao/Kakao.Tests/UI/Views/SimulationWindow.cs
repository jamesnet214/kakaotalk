using Jamesnet.Wpf.Controls;
using System.Windows;

namespace Kakao.Tests.UI.Views
{
    public class SimulationWindow : JamesWindow
    {
        static SimulationWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SimulationWindow), new FrameworkPropertyMetadata(typeof(SimulationWindow)));
        }

        public SimulationWindow()
        {
            Closing += SimulationWindow_Closing;
        }

        private void SimulationWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsVisible && DialogResult == null)
            {
                e.Cancel = true;
                Visibility = Visibility.Hidden;
            }
        }
    }
}
