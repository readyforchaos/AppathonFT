using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    class Match
    {
        public String club1, club2;
        int club1Goals, club2Goals;
        public int Club1Goals
        {
            get { return club1Goals; }
            set
            {
                if (value > 0)
                {
                    club1Goals = value;
                }
            }
        }

        public int Club2Goals
        {
            get { return club2Goals; }
            set
            {
                if (value > 0)
                {
                    club2Goals = value;
                }
            }
        }

        public Match(Player player1, Player player2)
        {
            club1 = player1.Club.name;
            club2 = player2.Club.name;
            Club1Goals = 0;
            Club2Goals = 0;
        }
        /*
        public void AddPointClub1()
        {
            Club1Goals++;
        }

        public void AddPointClub2()
        {
            Club2Goals++;
        }

        public void SubtractPointClub1()
        {
            if (Club1Goals > 0)
            {
                Club1Goals--;

            }
        }

        public void SubstractPointClub2()
        {
            if (Club2Goals > 0)
            {
                Club2Goals--;
            }
        }*/

        public String ToString()
        {
            return "\t" + club1 + "\t" + Club1Goals.ToString() + "\t -\t" + Club2Goals.ToString() + "\t" + club2;
        }
    }
}
