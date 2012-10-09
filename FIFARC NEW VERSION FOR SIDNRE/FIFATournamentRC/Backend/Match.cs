using System;

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
            String club1Temp = club1;
            if (club1.Length > 22)
            {
                club1Temp = club1Temp.Substring(0, 21);
            }
            return String.Format("{0} {1} \t - \t {2} {3}",
            club1Temp.PadRight(22), club1Goals.ToString(), club2Goals.ToString(), club2.PadRight(22));
        }

    }
}
