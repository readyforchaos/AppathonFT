﻿using System;
using System.Collections.Generic;
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
    public sealed partial class BasicPage2 : FIFAtest2.Common.LayoutAwarePage
    {
        int count;

        public BasicPage2()
        {
            
            this.InitializeComponent();
            GenerateLists();
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

        void GenerateLists()
        {
            foreach (league l in App.Instance.Leagues)
            {
                ComboBoxItem temp = new ComboBoxItem();
                temp.Content = l.name;
                LeagueList.Items.Add(temp);
            }
        }

        private void GenerateFixtures(object sender, RoutedEventArgs e)
        {
            App.Instance.Players[count].Club = App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex];
            count++;
            LeagueList.SelectedIndex = -1;
            ClubList.SelectedIndex = -1;

            if ((count) == App.Instance.Players.Count())
            {
                this.Frame.Navigate(typeof(BasicPage3), null);
            }
        }

        private void LeagueListSelected(object sender, SelectionChangedEventArgs e)
        {
            ClubList.Items.Clear();
            if(LeagueList.SelectedIndex >= 0)
            {
                foreach (club c in App.Instance.Leagues[LeagueList.SelectedIndex].clubs)
                {
                  ComboBoxItem temp = new ComboBoxItem();
                  temp.Content = c.name;
                  ClubList.Items.Add(temp);
                }
            }
        }


    }
}
