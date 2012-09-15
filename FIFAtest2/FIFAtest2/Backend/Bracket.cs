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
            for (int i = 1; i <= players.Count; i++)
            {
                MatchCount += (players.Count() - i);
            }

            int matchMaking = 0;
            Boolean matchMade = false;
            Random rng = new Random();
            //Match temp = new Match(players[0], players[1]);
           // Matches.Add(temp);
            while (matchMaking < MatchCount)
            {
                int player1 = rng.Next(players.Count);
                int player2 = rng.Next(players.Count);

                if (player1 != player2)
                {
                    Match temp = new Match(players[player1], players[player2]);
                    Match temp2 = new Match(players[player2], players[player1]);
                    matchMade = true;
                    foreach (Match m in Matches)
                    {
                        /*if (!m.Equals(temp) && matchMade != false)
                        {
                            matchMade = true;
                        }
                        else
                        {
                            matchMade = false;
                        }*/

                        if(m == temp || m == temp2)
                        {
                            matchMade = false;
                            break;
                        }
                    }
                    if (matchMade)
                    {
                        Matches.Add(temp);
                        matchMaking++;
                    }

                }
        

            }
            

        }


    }
}
