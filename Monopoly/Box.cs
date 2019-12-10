using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
   
    enum Type
    {
        go,
        station,
        parking,
        chance,
        community,
        tax,
        jail,
        go_to_jail,
    }

    class Box
    {
        Type box_name;
        int box_value; // for parking, station and tax not null, null for all others

        public Box(Type box_name, int box_value)
        {
            this.box_name = box_name;
            this.box_value = box_value;

        }
        public Type Box_name
        {
            get { return box_name; }
            set { box_name = value; }
        }

        public int Value
        {
            get { return box_value; }
            set { box_value = value; }
        }

        

    }
}

