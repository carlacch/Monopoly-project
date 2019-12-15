using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {      
        static void Main(string[] args)
        {
            Game MonopolyGame = new Game();
            MonopolyGame.Board.DispayBoard();
            MonopolyGame.Initialization();
            int turn = 0;
            do
            {
                turn += 1;
                MonopolyGame.ATurn();
            } while (!MonopolyGame.EndGame(turn));
            Console.ReadKey();
        }
    }
}
