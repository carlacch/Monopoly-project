using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class goToJailBox : Box
    {
        // value of all taxBox : 0
        // action :  go to jail so remove the pawn from the position and go to position of jail


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

        public goToJailBox(string box_name, int box_value) : base(box_name, box_value)
        {
        }
    }
}
