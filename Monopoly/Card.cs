using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Card
    {
        String card_name;
        String description;

        public Card(string card_name, string description)
        {
            this.card_name = card_name;
            this.description = description;
        }

        public string Name
        {
            get { return card_name; }
            set { card_name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
