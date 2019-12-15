using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Community : Card
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

        public Community(int id_card, string description) : base(id_card, description)
        {
        }

        // creation of community cards :


        Community community1 = new Community(1, "You receive 100$");
        Community community2 = new Community(2, "You lose 10$");
        Community community3 = new Community(3, "You reveive 40$");
        Community community4 = new Community(4, "You go to jail");
        Community community5 = new Community(5, "You receive 300$");
        Community community6 = new Community(6, "You receive 1$");

        Stack<Community> stack_community = new Stack<Community>();
        stack_community.Push(community1);
        stack_community.Push(community2);
        stack_community.Push(community3);
        stack_community.Push(community4);
        stack_community.Push(community5);
        stack_community.Push(community6);

    }

}
