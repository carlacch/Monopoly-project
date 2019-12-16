using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class GoBox : Box
    {
        
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

        public GoBox() : base("Go", 200)
        {
            this.owner = null; //Cannot be owned
        }

    }
}
