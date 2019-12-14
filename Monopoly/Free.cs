using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Free : IStatePlayer
    {
        public void Action(Player context)
        {
            Console.WriteLine("You are now free and can move again ! ");
        }

        public bool IsPrisoner(Player context)
        {
            return false;
        }
    }
}
