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

        // creation of chance cards :

         
            Chance chance1 = new Chance(1, "You receive 100$");
            Chance chance2 = new Chance(2, "Continue until the Go box");
            Chance chance3 = new Chance(3, "Go to jail");
            Chance chance4 = new Chance(4, "You receive 30$");
            Chance chance5 = new Chance(5, "You are free from jail");
            Chance chance6 = new Chance(6, "Move 7 boxes ahead");

        // creation of chance stack

        Stack<Chance> stack_chance = new Stack<Chance>();
        stack_chance.Push(chance1);








    }
}
