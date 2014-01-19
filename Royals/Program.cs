using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royals
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new RoyalsGame();


            foreach (var card in game.DeckView)
            {
                Console.WriteLine(card);
                Console.ReadKey(true);
            }
        }
    }
}
