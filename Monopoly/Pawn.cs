using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Pawn
    {
        int position; // from 0 to 39

        public Pawn(int position)
        {
            this.position = position;
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

      
    }

}
