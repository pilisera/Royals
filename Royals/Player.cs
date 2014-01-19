using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royals
{
    internal abstract class Player
    {
        // Hand will be regularly inserted and removed, and usually looped over instead of searched
        internal LinkedList<Card> Hand { get; set; }
        internal Suits? HomeSuit { get; private set; }
        internal int Score { get; set; }

        public Player()
        {
            Hand = new LinkedList<Card>();
            Score = 0;
        }

        abstract internal void ChooseHomeSuit();
        abstract internal Card PlayCard();
    }

    internal class HumanPlayer : Player
    {
        internal string HandString
        {
            get
            {
                return String.Join(", ", Hand);
            }
        }

        internal override void ChooseHomeSuit()
        {
            Console.WriteLine("Your hand is: ");
            Console.WriteLine(HandString);
            Console.WriteLine("Your opponent");
            
        }

        internal override Card PlayCard()
        {
            throw new NotImplementedException();
        }
    }
}
