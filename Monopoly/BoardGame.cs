using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class BoardGame
    {
        private static readonly int SIZE = 40;
        private List<box> squares = new List<box>(SIZE);

        public BoardGame()
        {
            buildSquares();
        }

        private void buildSquares()
        {
            for (int i = 1; i <= SIZE; i++)
            {
                build(i);
            }
        }

        private void build(int i)
        {
            Box s = new Box("Square " + i, i - 1);
            squares.add(s);
        }

    }
}
