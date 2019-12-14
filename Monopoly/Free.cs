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
            throw new NotImplementedException();
        }

        public bool IsPrisoner(Player context)
        {
            return false;
        }
    }
}
