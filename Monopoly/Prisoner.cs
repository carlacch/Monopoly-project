﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Prisoner : IStatePlayer
    {
        public void Action(Player context)
        {
            Console.WriteLine("You are going to jail...");
        }

        public bool IsPrisoner(Player context)
        {
            return true;
        }
    }
}
