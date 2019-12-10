using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class BoardGame
    {
        private readonly int size = 40;
        private List<Box> squares = new List<Box>(40);

        public BoardGame(int size, List<Box> squares)
        {
            this.size = size;
            this.squares = squares;
        }

        public int Size
        {
            get { return size; }
            
        }

        public List<Box> Squares
        {
            get { return squares; }
            set { squares = value; }
        }


        public BoardGame()
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
            //Box s = new Box("Square " + i, i - 1);
            //squares.add(s);
        }

    }
}
