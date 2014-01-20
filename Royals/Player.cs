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
        internal List<Card> Spoils { get; set; }
        internal List<Card> Meld { get; set; }

        internal int Score { get; set; }

        internal string HandString
        {
            get
            {
                return String.Join(", ", Hand);
            }
        }

        public Player()
        {
            Score = 0;
            Hand = new LinkedList<Card>();
            Spoils = new List<Card>();
            Meld = new List<Card>();
        }

        abstract internal Suits ChooseHomeSuit(IEnumerable<Suits> chosenSuits);
        abstract internal Card PlayCard();
        internal void AdjustScore()
        {
            int scoreDelta = 0;
            int scoreMultiplier = 1;

            #region Hand
            foreach (var card in Hand)
            {
                scoreDelta -= card.PointValue;
            }
            #endregion

            #region Meld and Spoils
            var meldAndSpoils = Meld;
            meldAndSpoils.AddRange(Spoils);

            var countByNumber = from Card card in meldAndSpoils
                                group card by card.Number into counts
                                select new { Number = counts.Key, Count = counts.Count() };

            foreach (var card in meldAndSpoils)
            {
                int count = countByNumber.Count(pair => pair.Number == card.Number);

                if (count >= 3)
                {
                    scoreDelta += card.PointValue * count * 2;
                }
                else
                {
                    scoreDelta += card.PointValue * count;
                }
            }

            var countByCard = from card in meldAndSpoils
                              group card by card into counts
                              select new { card = counts.Key, Count = counts.Count() };

            int numHomeJacks = countByCard.Count(a => a.card == new Card(HomeSuit.Value, Card.JACK));
            int numHomeQueens = countByCard.Count(a => a.card == new Card(HomeSuit.Value, Card.QUEEN));
            int numHomeKings = countByCard.Count(a => a.card == new Card(HomeSuit.Value, Card.KING));

            int numFamilies = Math.Min(numHomeJacks, Math.Min(numHomeQueens, numHomeKings));
            
            scoreMultiplier += numFamilies;
            #endregion

            Score += scoreDelta * scoreMultiplier;
        }
    }

    internal class HumanPlayer : Player
    {
        // TODO: Maybe pass number of players, or game type, to decide how to display Ally suit
        internal override Suits ChooseHomeSuit(IEnumerable<Suits> chosenSuits)
        {
            Console.WriteLine("Your hand is: ");
            Console.WriteLine(HandString);

            switch (chosenSuits.Count())
            {
                case 0:
                    Console.WriteLine("You are the first to choose a home suit.");
                    break;
                case 1:
                    Console.WriteLine("Your opponent has chosen " + chosenSuits.First() + " as their home suit.");
                    break;
                default:
                    throw new NotImplementedException("Marriage and Alliance Royals not yet supported.");
            }

            Console.WriteLine("Which suit do you want to be your home suit?");

            string suitString;
            Suits chosenSuit;
            bool understoodSuit;

            do
            {
                suitString = Console.ReadLine();
                understoodSuit = Enum.TryParse<Suits>(suitString, true, out chosenSuit);
            } while (!understoodSuit);

            return chosenSuit;
        }

        internal override Card PlayCard()
        {
            throw new NotImplementedException();
        }

        
    }
}
