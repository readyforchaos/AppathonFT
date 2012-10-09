using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class BufferPage : Page
    {
        public BufferPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        void GenerateLeague()
        {
            for (int i = 1; i <= 32; i++)
            {
                league temp = ObjectSerializer.FromXML<league>("http://fifaapi.com/league/" + i + ".xml");
                App.Instance.Leagues.Add(temp);
            }
        }

        async void CheckNetwork()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                GenerateLeague();
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                var md = new MessageDialog("No network connection found");

                md.Commands.Add(new UICommand("Try again", (UICommandInvokedHandler) =>
                    {
                        
                    }));

                md.Commands.Add(new UICommand("Exit", (UICommandInvokedHandler) =>
                {
                    App.Current.Exit();
                }));

                await md.ShowAsync();
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            CheckNetwork();
        }
    }
}
