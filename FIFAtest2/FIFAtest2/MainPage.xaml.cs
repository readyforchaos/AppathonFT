using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace FIFAtest2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //public List<league> Leagues { get; set; }
        //public List<Player> Players { get; set; }

        public MainPage()
        {
            //Players = new List<Player>();
            //GenerateLeague();
            //ObjectHolder.GenerateLeague();
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

        private void Continue(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BasicPage1), null);
        }

        /*void GenerateLeague()
        {
            Leagues = new List<league>();
            for (int i = 1; i <= 32; i++)
            {
                league temp = ObjectSerializer.FromXML<league>("http://fifaapi.com/league/" + i + ".xml");
                Leagues.Add(temp);
            }
        }*/
    }
}
