using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    /// <summary>
    /// Holds information on the players
    /// Name, Club and Position in tournament.
    /// </summary>
    public class Player
    {
        public String Name { get; set; }
        public club Club { get; set; }
        public int Position { get; set; }

        public int Played { get; set; }
        public int Wins { get; set; }
        public int Ties { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }

        public Player(String name, club club)
        {
            Name = name;
            Club = club;
        }

        public Player(String name)
        {
            Name = name;
        }

        public Player()
        {
        }

        public override string ToString()
        {

            return Club.name + " " + Position + " " + Played + " " + Wins + " " + Ties +
                " " + Losses + " " + GoalsFor + " " + GoalsAgainst + " " + GoalDifference + " " + Points;
        }

    }
}
