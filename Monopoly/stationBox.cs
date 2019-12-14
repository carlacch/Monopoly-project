using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class stationBox : Box
    {
        // value of all station box : 100


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

        public stationBox(string box_name, int box_value) : base(box_name, box_value)
        {
        }
    }
}
