using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class GoBox : Box
    {
        // value of all parking : 0
        // action : depart des pawn au lancement


        public string Box_name
        {
            get { return base.box_name; }
            set { base.box_name = value; }
        }

        public int Box_value
        {
            get { return base.box_value; }
            set { base.box_value = value; }
        }

        public GoBox(string box_name, int box_value) : base(box_name, box_value)
        {
        }
    }
}
