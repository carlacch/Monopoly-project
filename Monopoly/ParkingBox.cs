﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ParkingBox : Box
    {
        public new string Box_name
        {
            get { return this.box_name; }
            set { this.box_name = value; }
        }

        public new int Box_value
        {
            get { return this.box_value; }
            set { this.box_value = value; }
        }

        public new Player Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public ParkingBox() : base("Parking", -20)
        {
        }
    }
}
