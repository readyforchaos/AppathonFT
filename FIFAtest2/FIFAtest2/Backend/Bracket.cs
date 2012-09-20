using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    class Bracket
    {
        List<Player> players;
        public List<Match> Matches{ get; private set; }
        public int MatchCount { get; private set; }
        public int CurrentMatch { get; set; }

        public Bracket(List<Player> players)
        {
            this.players = players;
            Matches = new List<Match>();
            CurrentMatch = 0;
            GenerateMatches();
        }

        void GenerateMatches()
        {

            //Randomize List http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
            for (int i = 1; i <= players.Count; i++)
            {
                MatchCount += (players.Count() - i);
            }

            int matchMaking = 0;
            Boolean matchFound = false;
            Random rng = new Random();

            while (matchMaking < MatchCount)
            {
                int player1 = rng.Next(players.Count);
                int player2 = rng.Next(players.Count);

                if (player1 != player2)
                {
                    Match temp = new Match(players[player1], players[player2]);
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
