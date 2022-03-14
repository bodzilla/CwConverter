using System.Windows;

namespace CwConverter.Themes
{
    public partial class LightTheme
    {
        private void CloseWindow_Event(object sender, RoutedEventArgs e)
        {
            if (e.Source == null) return;
            try { CloseWind(Window.GetWindow((FrameworkElement)e.Source)); } catch { }
        }

        private void AutoMinimize_Event(object sender, RoutedEventArgs e)
        {
            if (e.Source == null) return;
            try { MaximizeRestore(Window.GetWindow((FrameworkElement)e.Source)); } catch { }
        }

        private void Minimize_Event(object sender, RoutedEventArgs e)
        {
            if (e.Source == null) return;
            try { MinimizeWind(Window.GetWindow((FrameworkElement)e.Source)); } catch { }
        }

        public void CloseWind(Window window) => window.Close();

        public void MaximizeRestore(Window window) => window.WindowState = window.WindowState switch
        {
            WindowState.Maximized => WindowState.Normal,
            WindowState.Normal => WindowState.Maximized,
            _ => window.WindowState
        };
        public void MinimizeWind(Window window) => window.WindowState = WindowState.Minimized;
    }
}
