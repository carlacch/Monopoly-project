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
            get { return this.id_card; }
            set { this.id_card = value; }
        }

        public new string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public Chance(int id_card, string description) : base(id_card,description)
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
                    p.Hispawn.Position = 0;
                    Console.WriteLine(">> You moved to {0} land", game.Board.Squares[p.Hispawn.Position].Box_name);
                    game.ActionPlayer(p);
                    break;
                case 3:
                    p.GoToJail();
                    break;
                case 4:
                    p.Cash += 30;
                    Console.WriteLine("You now have {0}$", p.Cash);
                    break;
                case 5:
                    p.Hispawn.Position += 1;
                    Console.WriteLine(">> You moved to {0} land", game.Board.Squares[p.Hispawn.Position].Box_name);
                    game.ActionPlayer(p);
                    break;
                case 6:
                    p.Hispawn.Position += 7;
                    Console.WriteLine(">> You moved to {0} land", game.Board.Squares[p.Hispawn.Position].Box_name);
                    game.ActionPlayer(p);
                    break;
                default:
                    break;
            }
        }
    }
}
