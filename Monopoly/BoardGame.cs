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
            buildSquares();
        }

        private void buildSquares()
        {
            for (int i = 1; i <= size; i++)
            {
                build(i);
            }
        }

        private void build(int i)
        {
            //FAIRE CREATION DES CASES AVEC FACTORY 
            //Box s = new Box("Box " + i, i - 1);
            //squares.add(s);
        }

    }
}
