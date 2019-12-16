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
            get { return this.id_card; }
            set { this.id_card = value; }
        }

        public new string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public Community(int id_card, string description) : base(id_card, description)
        {
        }

        public override void ActionCard(Player p, Game game)
        {
            switch (id_card)
            {
                case 1:
                    p.Cash += 100;
                    Console.WriteLine("You now have {0}$", p.Cash);
                    break;
                case 2:
                    p.Cash -= 100;
                    Console.WriteLine("You now have {0}$", p.Cash);
                    break;
                case 3:
                    p.Cash += 40;
                    Console.WriteLine("You now have {0}$", p.Cash);
                    break;
                case 4:
                    p.GoToJail();
                    break;
                case 5:
                    p.Cash += 300;
                    Console.WriteLine("You now have {0}$", p.Cash);
                    break;
                case 6:
                    p.Hispawn.Position += 2;
                    Console.WriteLine(">> You moved to {0} land", game.Board.Squares[p.Hispawn.Position].Box_name);
                    game.ActionPlayer(p);
                    break;
                default:
                    break;
            }
        }
    }
}
