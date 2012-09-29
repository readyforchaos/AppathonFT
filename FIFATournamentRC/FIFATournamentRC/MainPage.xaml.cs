using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Backend;
using Backend.Xml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FIFATournamentRC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            PlayerList.ItemsSource = App.Instance.OCPlayers;
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            foreach (Player p in App.Instance.OCPlayers)
            {
                if (p.Name != null)
                {
                    App.Instance.Players.Add(p);
                }
            }
            if (App.Instance.Players.Count > 0)
            {
                this.Frame.Navigate(typeof(ChooseTeams), null);
            }
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            App.Instance.OCPlayers.Add(new Player());

        }

        private void PlayerList_Selected(object sender, SelectionChangedEventArgs e)
        {
            PlayerList.SelectedIndex = -1;

        }
    }
}
