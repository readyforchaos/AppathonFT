﻿using System;
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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace FIFAtest2
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class BasicPage1 : FIFAtest2.Common.LayoutAwarePage
    {

        ObservableCollection<Player> players;

        public BasicPage1()
        {
            this.InitializeComponent();
            players = new ObservableCollection<Player>();

            PlayerList.ItemsSource = players;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            foreach (Player p in players)
            {
                if (p.Name != "")
                {
                    App.Instance.Players.Add(p);
                }
            }
            this.Frame.Navigate(typeof(BasicPage2), null);
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            players.Add(new Player());
        }
    }
}
