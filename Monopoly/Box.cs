using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
   /*
    enum Type
    {
        go, //1
        street, //22
        station, //4
        parking, //1
        chance, //3
        community, //3
        tax, //4
        jail, //1
        go_to_jail, //1
    }*/

    abstract class Box //Factory pattern
    {
        protected string box_name;
        protected int box_value; // for parking, station and tax not null, null for all others

        public Box(string box_name, int box_value)
        {
            this.box_name = box_name;
            this.box_value = box_value;

        }
        public string Box_name
        {
            get { return box_name; }
            set { box_name = value; }
        }

        public int Box_value
        {
            get { return box_value; }
            set { box_value = value; }
        }

        

    }
}

