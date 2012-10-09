using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

using Backend;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace FIFATournamentRC
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ChooseTeams : FIFATournamentRC.Common.LayoutAwarePage
    {

        int count;

        public ChooseTeams()
        {
            this.InitializeComponent();

            GenerateLists();
            count = 0;
            PlayerName.Text = "Select team, " + App.Instance.Players[0].Name + ":";
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            App.Instance.Players.Clear();

            this.Frame.Navigate(typeof(MainPage));
        }

        private void GenerateFixtures(object sender, RoutedEventArgs e)
        {
            if (ClubList.SelectedIndex >= 0)
            {
                Boolean matchFound = true;

                club temp = App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex];

                foreach (Player p in App.Instance.Players)
                {
                    if (temp == p.Club)
                    {
                        matchFound = false;
                    }
                }

                if (matchFound)
                {
                    App.Instance.Players[count].Club = temp;
                    count++;
                    if (count < App.Instance.Players.Count)
                    {
                        PlayerName.Text = "Select team, " + App.Instance.Players[count].Name + ":";
                        LeagueList.SelectedIndex = -1;
                        ClubList.SelectedIndex = -1;
                        ClubName.Text = "Select club";
                        ClubImage.Source = null;
                        Def.Text = "";
                        Mid.Text = "";
                        Att.Text = "";
                    }
                    if ((count) == App.Instance.Players.Count())
                    {
                        this.Frame.Navigate(typeof(Dashboard), null);
                    }
                }
            }
        }

        private void LeagueListSelected(object sender, SelectionChangedEventArgs e)
        {
            ClubList.Items.Clear();
            if (LeagueList.SelectedIndex >= 0)
            {
                foreach (club c in App.Instance.Leagues[LeagueList.SelectedIndex].clubs)
                {
                    ComboBoxItem temp = new ComboBoxItem();
                    temp.Content = c.name;
                    ClubList.Items.Add(temp);
                }
            }
        }

        private void ClubListSelected(object sender, SelectionChangedEventArgs e)
        {
            if (ClubList.SelectedIndex >= 0)
            {
                ClubName.Text = App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex].name;
                if (App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex].def == 0)
                {
                    Def.Text = "?";
                }
                else
                {
                    Def.Text = App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex].def.ToString();
                }
                if (App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex].mid == 0)
                {
                    Mid.Text = "?";
                }
                else
                {
                    Mid.Text = App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex].mid.ToString();
                }
                if (App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex].att == 0)
                {
                    Att.Text = "?";
                }
                else
                {
                    Att.Text = App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex].att.ToString();
                }
                BitmapImage bi = new BitmapImage();
                bi.UriSource = new Uri(App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex].logo);
                ClubImage.Source = bi;
                GenerateStarRating();
            }
        }

        void GenerateStarRating()
        {
            double score = App.Instance.Leagues[LeagueList.SelectedIndex].clubs[ClubList.SelectedIndex].score;
            BitmapImage star = new BitmapImage(new Uri("ms-appx:///Assets/star.png"));
            BitmapImage emptyStar = new BitmapImage(new Uri("ms-appx:///Assets/starEmpty.png"));
            BitmapImage halfStar = new BitmapImage(new Uri("ms-appx:///Assets/half_str.png"));

            List<Image> foo = new List<Image>();
            for (int i = 1; i <= 5; i++)
            {
                foo.Add(new Image());
                if (score >= i)
                {
                    foo[i - 1].Source = star;
                }
                else if (score < i && score > (i - 1))
                {
                    foo[i - 1].Source = halfStar;
                }
                else
                {
                    foo[i - 1].Source = emptyStar;
                }

            }

            Star1.Source = foo[0].Source;
            Star2.Source = foo[1].Source;
            Star3.Source = foo[2].Source;
            Star4.Source = foo[3].Source;
            Star5.Source = foo[4].Source;

        }
    }
}
