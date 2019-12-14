using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class BoardGame
    {
        private static BoardGame instance = new BoardGame();
        private static readonly int size = 40;
        private List<Box> squares = new List<Box>(40);

        public int Size
        {
            get { return size; }
        }

        public List<Box> Squares
        {
            get { return squares; }
            set { squares = value; }
        }

        public static BoardGame GetInstance()
        {
            return instance;
        }

        private BoardGame()
        {
            var listBoxes = new ListBox();
            squares = listBoxes.Boxes;
        }

        public void DispayBoard()
        {
            Console.WriteLine();
            for (int i=0; i <= 10; i++)
            { 
                Console.Write("| {0} ", squares[i].Box_name);
            }
            Console.WriteLine("\n-----------------------------------------------------------------------------------------");
            for (int i = 0; i <= 8; i++)
            {
                Console.WriteLine("| {0} \t|\t\t\t\t\t\t\t\t\t\t | {1} \t|", squares[39-i].Box_name, squares[11+i].Box_name);
            }
            Console.WriteLine("\n-----------------------------------------------------------------------------------------");
            for (int i = 30; i >= 20; i--)
            {
                Console.Write("| {0} ", squares[i].Box_name);
            }
            Console.WriteLine();
        }

    }
}
