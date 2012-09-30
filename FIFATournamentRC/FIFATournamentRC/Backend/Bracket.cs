using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Backend
{
    class Bracket
    {
        public List<Player> Players { get; set; }
        
        public List<Match> Matches{ get; set; }
        public List<Match> MatchesPlayed { get; set; }
        public int MatchCount { get; private set; }
        public int CurrentMatch { get; set; }

        public Bracket(List<Player> players)
        {
            Matches = new List<Match>();
            MatchesPlayed = new List<Match>();
            CurrentMatch = 0;
            Players = players;
            GenerateMatches();
            
        }

        void GenerateMatches()
        {

            for (int i = 1; i <= Players.Count; i++)
            {
                MatchCount += (Players.Count() - i);
            }

            int matchMaking = 0;
            Boolean matchFound = false;
            Random rng = new Random();

            while (matchMaking < MatchCount)
            {
                int player1 = rng.Next(Players.Count);
                int player2 = rng.Next(Players.Count);

                if (player1 != player2)
                {
                    Match temp = new Match(Players[player1], Players[player2]);
                    matchFound = true;
                    foreach (Match m in Matches)
                    {
                        if ((m.club1 == temp.club1 && m.club2 == temp.club2) || 
                            (m.club1 == temp.club2 && m.club2 == temp.club1))
                        {
                            matchFound = false;
                            break;
                        }
                    }
                    if (matchFound)
                    {
                        Matches.Add(temp);
                        matchMaking++;
                    }
                }
            }
        }
    }
}
