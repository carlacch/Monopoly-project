using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Dice
    {
        int die1; // between 1 and 6
        int die2;

        public Dice()
        {
            this.die1 = 0;
            this.die2 = 0;
        }

        public int Die1
        {
            get { return die1; }
            set { die1 = value; }
        }

        public int Die2
        {
            get { return die2; }
            set { die2 = value; }
        }

        public void Rolldice()
        {
            Random rdm = new Random();
            this.die1 = rdm.Next(1, 6 + 1);
            this.die2 = rdm.Next(1, 6 + 1);
        }
        
    }


}
