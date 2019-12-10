using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Dice
    {
        int dice_value; // between 1 and 6

        public Dice()
        {
            this.dice_value = 0;
        }

        public int Dice_value
        {
            get { return dice_value; }
            set { dice_value = value; }
        }
            
        public void Rolldice()
        {
            Random rdm = new Random();
            this.dice_value = rdm.Next(1,6);
        }
        
    }


}
