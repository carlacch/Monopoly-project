using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        bool banker = false; // if it's a banker he gives the money at the beginning
        int playing_order; // ordre dans lequel ils commencent à jouer
        int cash; // amount of money earned
        bool prisoner = false;
        List<Property> properties; // properties earned 

        public Player(int playing_order, int cash, List<Property> properties)
        {
            this.playing_order = playing_order;
            this.cash = cash;
            this.properties = properties;
        }

        public int Playing_Order
        {
            get { return playing_order; }
            set { playing_order = value; }
        }

        public int Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        public List<Property> Properties
        {
            get { return properties; }
            set { properties  = value; }
        }


    }
}
