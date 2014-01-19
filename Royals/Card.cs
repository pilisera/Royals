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
        // 2 - 14 for Two - Ace
        internal readonly int Number;
        internal readonly Suits Suit;
        public string NumberString
        {
            get
            {
                switch (Number)
                {
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    case 14:
                        return "Ace";
                    default:
                        return Number.ToString();
                }
            }
        }

        internal Card(Suits suit, int number)
        {
            if (number > 14 || number < 2)
            {
                throw new ArgumentOutOfRangeException("Number must be between 2 and 14, but instead was: " + number);
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
