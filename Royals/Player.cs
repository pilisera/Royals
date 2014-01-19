using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royals
{
    class Player
    {
        List<Card> Hand { get; set; }
        Suits? HomeSuit { get; set; }
        int Score { get; set; }

        public Player()
        {
            Hand = new List<Card>();
            Score = 0;
        }
        
    }
}
