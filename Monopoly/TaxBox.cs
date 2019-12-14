using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class TaxBox : Box
    {
        // value of all taxBox : -40


        public new string Box_name
        {
            get { return base.box_name; }
            set { base.box_name = value; }
        }

        public new int Box_value
        {
            get { return base.box_value; }
            set { base.box_value = value; }
        }

        public TaxBox() : base("Tax", -40)
        {
        }
    }
}
