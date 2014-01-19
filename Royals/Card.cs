using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royals
{
    enum Suits { Spades, Hearts, Diamonds, Clubs }
    internal struct Card
    {
        // 1 - 13 for Ace - King
        internal readonly int Number;
        internal readonly Suits Suit;
        public string NumberString
        {
            get
            {
                switch (Number)
                {
                    case 1:
                        return "Ace";
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    default:
                        return Number.ToString();
                }
            }
        }

        internal Card(Suits suit, int number)
        {
            if (number > 13 || number < 1)
            {
                throw new ArgumentOutOfRangeException("Number must be between 1 and 13, but instead was: " + number);
            }

            Suit = suit;
            Number = number;
        }

        public override string ToString()
        {
            return NumberString + " of " + Suit.ToString();
        }
    }
}
