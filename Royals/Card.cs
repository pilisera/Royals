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
        #region constants
        internal const int JACK = 11;
        internal const int QUEEN = 12;
        internal const int KING = 13;
        internal const int ACE = 14;
        #endregion

        // 2 - 14 for Two - Ace
        internal readonly int Number;
        internal int PointValue
        {
            get
            {
                // 10 points for 9-Ace, 5 for 2-8
                return Number >= 9 ? 10 : 5;
            }
        }
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

        #region overrides
        public override string ToString()
        {
            return NumberString + " of " + Suit.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
                var card = (Card)obj;
                return card.Number == Number && card.Suit == Suit;
            }
            return false;
        }

        public static bool operator ==(Card lhs, Card rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Card lhs, Card rhs)
        {
            return !(lhs.Equals(rhs));
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + Number.GetHashCode();
            hash = hash * 31 + Suit.GetHashCode();
            return hash;
        }
        #endregion
    }
}
