using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royals
{
    internal class RoyalsGame
    {
        // Always 10 cards in the initial deal
        private const byte CARDS_PER_HAND = 10;
        // Two players for the standard game, will be expanded to 3 and 4 for Marriage and Alliance Royals
        private const byte NUMBER_OF_PLAYERS = 2;

        List<Card> Deck { get; set; }
        List<Player> Players { get; set; }
        public IReadOnlyCollection<Card> DeckView
        {
            get
            {
                return new ReadOnlyCollection<Card>(Deck);
            }
        }

        private static Random RNG = new Random();

        #region init
        internal RoyalsGame()
        {
            Reset();
        }

        internal void Reset()
        {
            InitializeDeck();
            InitializePlayers();
        }

        private void InitializeDeck()
        {
            Deck = new List<Card>();

            // Loop over suits and values
            foreach (Suits suit in Enum.GetValues(typeof(Suits)).Cast<Suits>())
            {
                for (int number = 1; number <= 13; number++)
                {
                    Card card = new Card(suit, number);

                    // Add one copy for the Poker deck
                    Deck.Add(card);

                    // Add two copies for the Pinochle deck
                    if (number > 8)
                    {
                        Deck.Add(card);
                        Deck.Add(card);
                    }
                }
            }

            ShuffleDeck();
        }

        private void InitializePlayers()
        {
            Players = new List<Player>();

            for (int i = 0; i < NUMBER_OF_PLAYERS; i++)
            {
                Players.Add(new Player());
            }
        }
        #endregion

        #region Play
        internal void Start()
        {
            Deal();
            ChooseHomeSuits();

            bool HandContinues = true;
            while (HandContinues)
            {
                HandContinues = TakeTurn();
            }

            AdjustScores();
        }

        private void Deal()
        {

        }

        private void ChooseHomeSuits()
        {

        }

        private bool TakeTurn()
        {
            return false;
        }

        private void AdjustScores()
        {

        }
        #endregion

        private void ShuffleDeck()
        {
            // Fisher-Yates Shuffle
            for (int currentIndex = Deck.Count - 1; currentIndex > 0; currentIndex--)
            {
                int randomIndex = RNG.Next(currentIndex + 1);
                Card swapValue = Deck[randomIndex];
                Deck[randomIndex] = Deck[currentIndex];
                Deck[currentIndex] = swapValue;
            }
        }
    }
}
