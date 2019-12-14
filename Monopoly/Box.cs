using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
   
    enum Type
    {
        go,//  1
        station, //4
        parking, // 12
        chance, // 5
        street, // 6
        community, // 5
        tax, // 5
        jail, //1
        go_to_jail, //1

    }

    class Box
    {
        public string box_name;
        public int box_value; // for parking, station and tax not null, null for all others

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

        public int Value
        {
            get { return box_value; }
            set { box_value = value; }
        }

        

    }
}

