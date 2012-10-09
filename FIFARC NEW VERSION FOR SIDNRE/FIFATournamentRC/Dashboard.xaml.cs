using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

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
        Boolean finals;
        FontFamily font;

        public Dashboard()
        {
            bracket = new Bracket(App.Instance.Players);

            this.InitializeComponent();
            swapped = false;
            finals = false;
            font = new FontFamily("Courier New");
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
                temp.FontFamily = font;
                temp.Content = bracket.Matches[i].ToString();
                MatchList.Items.Add(temp);
            }

        }

        void GenerateLeaderboard()
        {
            Leaderboard.Items.Clear();

            foreach (Player p in bracket.Players)
            {
                ListViewItem temp = new ListViewItem();
                temp.FontFamily = font;
                temp.Content = p.ToString();
                Leaderboard.Items.Add(temp);
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
            temp.FontFamily = font;
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

            //Sorts out Position
            bracket.Players.Sort(delegate(Player p1, Player p2) { return p2.Points.CompareTo(p1.Points); });
            for (int i = 0; i < bracket.Players.Count; i++)
            {
                bracket.Players[i].Position = i + 1;
            }

            //Reloads the Leaderboard
            GenerateLeaderboard();
        }

        void GenerateMatchesPlayed()
        {
            MatchList.Items.Clear();

            for (int i = 0; i < bracket.CurrentMatch; i++)
            {
                ListViewItem temp = new ListViewItem();
                temp.FontFamily = font;
                temp.Content = bracket.Matches[i].ToString();
                MatchList.Items.Add(temp);
            }
        }

        private async void btnMatch_Click(object sender, RoutedEventArgs e)
        {
            if (finals)
            {
                String winner;
                if (bracket.Matches[bracket.Matches.Count - 1].Club1Goals > 
                    bracket.Matches[bracket.Matches.Count - 1].Club2Goals)
                {
                    winner = bracket.Matches[bracket.Matches.Count - 1].club1;
                }
                else { winner = bracket.Matches[bracket.Matches.Count - 1].club2; }

                var md = new MessageDialog(winner + " are champions!");

                md.Commands.Add(new UICommand("Exit", (UICommandInvokedHandler) =>
                {
                    App.Current.Exit();
                }));
                
                await md.ShowAsync();
            }

            if (bracket.CurrentMatch < bracket.MatchCount - 1 && !swapped)
            {

                UpdatePlayerStats();
                MatchList.Items.RemoveAt(0);

                bracket.CurrentMatch++;
                if (bracket.CurrentMatch == bracket.MatchCount - 1)
                {
                    btn_Match.Content = "End match";
                }

            }
            else if (MatchList.Items.Count > 0 && !swapped)
            {
                UpdatePlayerStats();
                MatchList.Items.RemoveAt(0);
                bracket.CurrentMatch++;
                
                //Final
                List<Player> temp = new List<Player>();
                temp.Add(bracket.Players[0]);
                temp.Add(bracket.Players[1]);
                if (bracket.Players[1].Points == bracket.Players[2].Points)
                {
                    temp.Add(bracket.Players[2]);
                    if (temp[0].Points == temp[2].Points)
                    {
                        temp.Sort(delegate(Player p1, Player p2)
                        { return p2.GoalDifference.CompareTo(p1.GoalDifference); });
                    }
                }
                
                bracket.Matches.Add(new Match(temp[0], temp[1]));
                txbMatches.Text = "League final!";

                ListViewItem lwi = new ListViewItem();
                lwi.FontFamily = font;
                lwi.Content = bracket.Matches[bracket.Matches.Count - 1].ToString();
                MatchList.Items.Clear();
                MatchList.Items.Add(lwi);
                finals = true;

            }
        }

        private void btnSwap_Click(object sender, RoutedEventArgs e)
        {
            if (!swapped)
            {
                GenerateMatchesPlayed();
                txbMatches.Text = "Played Matches";
                swapped = true;
                ButtonSwap.Content = "Current Matches";
            }
            else
            {
                if (!finals) 
                { 
                    GenerateMatchList(); 
                    txbMatches.Text = "Matches"; }
                else if (finals) 
                { 
                    txbMatches.Text = "League final!";
                    ListViewItem lwi = new ListViewItem();
                    lwi.Content = bracket.Matches[bracket.Matches.Count - 1].ToString();
                    MatchList.Items.Clear();
                    MatchList.Items.Add(lwi);
                }

                swapped = false;
                ButtonSwap.Content = "Played Matches";
            }
        }

        private void MatchList_Selected(object sender, SelectionChangedEventArgs e)
        {
            MatchList.SelectedIndex = -1;
            Leaderboard.SelectedIndex = -1;
        }
    }
}
