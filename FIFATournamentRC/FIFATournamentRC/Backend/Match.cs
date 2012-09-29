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
                if (value >= 0)
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
                if (value >= 0)
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
        
        String Foo(string text)
        {
            if (text.Length < 25)
            {
                for (int i = text.Length; i < 25; i++)
                {
                    text += " ";
                }
            }
            else
            {
                text.Substring(0, 24);
            }

            return text;
        }

        public override String ToString()
        {
            //return "\t" + club1 + "\t" + Club1Goals.ToString() + "\t -\t" + Club2Goals.ToString() + "\t" + club2;

            return String.Format("\t {0} {1} \t - \t {2} \t {3}", 
                club1, club1Goals.ToString(), club2Goals.ToString(), club2); 

            //String cant be smaller then 2nd index of Substring parameter
            //Mulig fix, += X antall "space" for å få lengen på strengen innenfor parametere
        }

        //Add override method Equals, for Bracket generating?
    }
}
