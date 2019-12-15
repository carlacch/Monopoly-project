using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monopoly
{
    class Chance : Card
    {
        public new int Id_card
        {
            get { return base.id_card; }
            set { base.id_card = value; }
        }

        public new string Description
        {
            get { return base.description; }
            set { base.description = value; }
        }

        public Chance(int id_card, string description) : base(id_card,description)
        {
        }

        








    }
}
