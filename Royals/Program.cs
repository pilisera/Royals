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

            do
            {
                game.Reset();
                Console.WriteLine(game.DeckView.First());
                Console.ReadKey();
            } while (true);
        }
    }
}
