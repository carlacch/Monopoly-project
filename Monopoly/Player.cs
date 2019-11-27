using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Player
    {
        bool banker = false; // if it's a banker he gives the money at the beginning
        int playing_order; // ordre dans lequel ils commencent à jouer
        int cash; // amount of money earned
        bool prisoner = false;
        List<Property> hisProperty; // properties earned 
    }
}
