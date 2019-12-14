using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Pawn
    {
        String color;
        int position; // from 0 to 39

        public Pawn(String color,int position)
        {
            this.color = color;
            this.position = position;
        }

        public Pawn(int position)
        {
            this.position = position;
        }

        public Pawn(String color)
        {
            this.color = color;
            position = 0;
        }

        public Pawn()
        {
            position = 0;
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public String Color
        {
            get { return color; }
        }
      
    }

}
