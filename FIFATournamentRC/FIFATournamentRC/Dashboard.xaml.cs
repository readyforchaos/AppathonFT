using System;
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

namespace FIFATournamentRC
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Dashboard : FIFATournamentRC.Common.LayoutAwarePage
    {

        Bracket bracket;
        Boolean swapped;

        public Dashboard()
        {
            bracket = new Bracket(App.Instance.Players);

            this.InitializeComponent();
            swapped = false;
            GenerateMatchList();
            GenerateLeaderboard();
            
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

        void GenerateMatchList()
        {
            MatchList.Items.Clear();

            for (int i = bracket.CurrentMatch; i < bracket.MatchCount; i++)
            {
                ListViewItem temp = new ListViewItem();
                temp.Content = bracket.Matches[i].ToString();
                MatchList.Items.Add(temp);
            }

            /*foreach (Match m in bracket.Matches)
            {
                ListViewItem temp = new ListViewItem();
                temp.Content = m.ToString();
                MatchList.Items.Add(temp);
            }*/
            
        }

        void GenerateLeaderboard()
        {
            bracket.Players.Sort(delegate(Player p1, Player p2) { return p2.Points.CompareTo(p1.Points); });

            //Leaderboard.Items.Clear();
            

            foreach (Player p in bracket.Players)
            {
                ListViewItem temp = new ListViewItem();
                temp.Content = p.ToString();
                //Leaderboard.Items.Add(temp);
            }

        }

        private void Player1TeamPlus_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!swapped)
            {
                bracket.Matches[bracket.CurrentMatch].Club1Goals++;
                UpdateMatchList();
            }
        }

        private void Player1TeamSubstract_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!swapped)
            {
                bracket.Matches[bracket.CurrentMatch].Club1Goals--;
                UpdateMatchList();
            }
        }

        private void Player2TeamPlus_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!swapped)
            {
                bracket.Matches[bracket.CurrentMatch].Club2Goals++;
                UpdateMatchList();
            }
        }

        private void Player2TeamSubstract_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!swapped)
            {
                bracket.Matches[bracket.CurrentMatch].Club2Goals--;
                UpdateMatchList();
            }
        }

        void UpdateMatchList()
        {
            ListViewItem temp = new ListViewItem();
            temp.Content = bracket.Matches[bracket.CurrentMatch].ToString();
            MatchList.Items.RemoveAt(0);
            MatchList.Items.Insert(0, temp);
        }

        void UpdatePlayerStats()
        {
            Match match = bracket.Matches[bracket.CurrentMatch];
            int index1 = 0;
            int index2 = 1;

            //Gets index of the players we are updating
            for (int i = 0; i < bracket.Players.Count; i++)
            {
                if (match.club1 == bracket.Players[i].Club.name)
                {
                    index1 = i;
                }

                if (match.club2 == bracket.Players[i].Club.name)
                {
                    index2 = i;
                }
            }
            bracket.Players[index1].Played++;
            bracket.Players[index2].Played++;

            //Sorts out points
            if (match.Club1Goals > match.Club2Goals)
            {
                bracket.Players[index1].Points += 3;
                bracket.Players[index1].Wins++;
                bracket.Players[index2].Losses++;
            }
            else if (match.Club1Goals < match.Club2Goals)
            {
                bracket.Players[index2].Points += 3;
                bracket.Players[index2].Wins++;
                bracket.Players[index1].Losses++;
            }
            else
            {
                bracket.Players[index1].Points += 1;
                bracket.Players[index2].Points += 1;
                bracket.Players[index1].Ties++;
                bracket.Players[index2].Ties++;
            }

            //Sorts out GoalsAgainst
            bracket.Players[index1].GoalsAgainst += match.Club2Goals;
            bracket.Players[index2].GoalsAgainst += match.Club1Goals;

            //Sorts out GoalsFor
            bracket.Players[index1].GoalsFor += match.Club1Goals;
            bracket.Players[index2].GoalsFor += match.Club2Goals;

            //Sorts out GoalDifference
            bracket.Players[index1].GoalDifference =
                bracket.Players[index1].GoalsFor - bracket.Players[index1].GoalsAgainst;
            bracket.Players[index2].GoalDifference =
                bracket.Players[index2].GoalsFor - bracket.Players[index2].GoalsAgainst;

            //Reloads the Leaderboard
            //GenerateLeaderboard();
        }

        void GenerateMatchesPlayed()
        {
            MatchList.Items.Clear();

            for (int i = 0; i < bracket.CurrentMatch; i++)
            {
                ListViewItem temp = new ListViewItem();
                temp.Content = bracket.Matches[i].ToString();
                MatchList.Items.Add(temp);
            }
        }

        private void btnMatch_Click(object sender, RoutedEventArgs e)
        {
            
            if (bracket.CurrentMatch < bracket.MatchCount - 1 && !swapped)
            {

                UpdatePlayerStats();
                MatchList.Items.RemoveAt(0);

                bracket.CurrentMatch++;

            }
        }

        private void btnSwap_Click(object sender, RoutedEventArgs e)
        {
            if (!swapped)
            {
                GenerateMatchesPlayed();
                txbMatches.Text = "Played Matches";
                swapped = true;
            }
            else
            {
                GenerateMatchList();
                txbMatches.Text = "Matches";
                swapped = false;
            }
        }
    }
}
