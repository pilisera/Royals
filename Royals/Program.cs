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

            game.RunHand();

            foreach (var p in game.PlayerView)
            {
                Console.WriteLine("Hand is: " + p.HandString);
                Console.WriteLine("Score is: " + p.Score);

                Console.ReadKey();
            }
        }
    }
}
