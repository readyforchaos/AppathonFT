using System;

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
            if (Club.name.Length > 9)
            {
                clubnameTemp = clubnameTemp.Substring(0, 9);
            }
            string nameTemp = Name;
            if (Name.Length > 9)
            {
                nameTemp = nameTemp.Substring(0, 9);
            }

            return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",
            Position.ToString().PadRight(6), clubnameTemp.PadRight(10), nameTemp.PadRight(10),
            Played.ToString().PadRight(8), Wins.ToString().PadRight(6), Ties.ToString().PadRight(4),
            Losses.ToString().PadRight(7), GoalsFor.ToString().PadRight(5),
            GoalsAgainst.ToString().PadRight(4), GoalDifference.ToString().PadRight(4), Points);
        }

    }
}
