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

        public new string Box_name
        {
            get { return this.box_name; }
            set { this.box_name = value; }
        }

        public new int Box_value
        {
            get { return this.box_value; }
            set { this.box_value = value; }
        }

        public GoBox(string box_name, int box_value) : base(box_name, box_value)
        {
        }

    }
}
