using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    enum Type
        {
            rose,
            orange,
            rouge,
            jaune,
            vert,
            bleu,
            violet,
            light_blue,
            prison,
            gare,
            start,
        };

    class Box
    {
        string name;
        Type box_type;
        int value;


        public Box()
        {

        }

    }
}
