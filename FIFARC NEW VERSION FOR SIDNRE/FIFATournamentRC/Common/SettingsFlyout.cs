using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace FIFATournamentRC.Common
{
    class SettingsFlyout
    {

        private const int width = 346;
        private Popup popup;

        public void ShowFlyout(UserControl control)
        {
            popup = new Popup();
            popup.Closed += OnPopupClosed;
            Window.Current.Activated += OnWindowActivated;
            popup.IsLightDismissEnabled = true;
            popup.Width = width;
            popup.Height = Window.Current.Bounds.Height;

            control.Width = width;
            control.Height = Window.Current.Bounds.Height;

            popup.Child = control;
            popup.SetValue(Canvas.LeftProperty, Window.Current.Bounds.Width - width);
            popup.SetValue(Canvas.TopProperty, 0);
            popup.IsOpen = true;

        }

        private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
             {
                popup.IsOpen = false;
             }
        }

        void OnPopupClosed(object sender, object e)
        {
             Window.Current.Activated -= OnWindowActivated;
         }

    }
}
