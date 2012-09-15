using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    class Match
    {
        String club1, club2;
        int club1Goals, club2Goals;

        public Match(Player player1, Player player2)
        {
            club1 = player1.Club.name;
            club2 = player2.Club.name;
            club1Goals = 0;
            club2Goals = 0;
        }

        public void AddPointClub1()
        {
            club1Goals++;
        }

        public void AddPointClub2()
        {
            club2Goals++;
        }

        public void SubtractPointClub1()
        {
            if (club1Goals > 0)
            {
                club1Goals--;

            }
        }

        public void SubstractPointClub2()
        {
            if (club2Goals > 0)
            {
                club2Goals--;
            }
        }

        public String ToString()
        {
            return "\t" + club1 + "\t" + club1Goals.ToString() + "\t -\t" + club2Goals.ToString() + "\t" + club2;
        }
    }
}
