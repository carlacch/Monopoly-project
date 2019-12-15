﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Card
    {
        protected int id_card;
        public String description;

        public Card(int id_card, string description)
        {
            this.id_card = id_card;
            this.description = description;
        }

        public int Id_card
        {
            get { return id_card; }
            set { id_card = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
