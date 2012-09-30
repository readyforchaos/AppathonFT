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
            string clubnameTemp = Club.name;
            if (Club.name.Length > 10)
            {
                clubnameTemp = clubnameTemp.Substring(0, 9);
                
            }

            string nameTemp = Name;
            if (Name.Length > 10)
            {
                nameTemp = nameTemp.Substring(0, 9);
            }

            return String.Format("{0,-10} {1}\t{2}\t{3,-10} {4,-10} {5,-10} {6,-10} {7,-10} {8,-10} {9,-10} {10,-10}",
                Position, clubnameTemp, nameTemp, Played, Wins, Ties, Losses, 
                GoalsFor, GoalsAgainst, GoalDifference, Points);

            //return Club.name + " " + Position + " " + Played + " " + Wins + " " + Ties +
              //  " " + Losses + " " + GoalsFor + " " + GoalsAgainst + " " + GoalDifference + " " + Points;
        }

    }
}
