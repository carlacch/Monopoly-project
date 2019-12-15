using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        /*
        protected bool prisoner = false; //prisoner or not
        */
        protected IStatePlayer state;
        protected int playing_order; // ordre dans lequel ils commencent à jouer
        protected int cash; // amount of money earned
        protected Pawn hispawn;
        //protected List<Property> properties; // properties earned 
        protected Dice twoDice; // Dice used by the player
        protected List<Dice> previewsdice; //List of maximum 3 twodice
      
        public Player(int playing_order, int cash, Dice twoDice) : this(cash,twoDice)
        {
            this.playing_order = playing_order;
        }

        public Player(int cash, Dice twoDice)
        {
            this.cash = cash;
            this.twoDice = twoDice;
            //this.properties = new List<Property>();
            this.state = new Free();
            this.previewsdice = new List<Dice>();
        }

        public Player(int cash, Dice twoDice, Pawn pawn) : this(cash,twoDice)
        {
            this.hispawn = pawn;
        }

        public Pawn Hispawn
        {
            get { return hispawn; }
            set { hispawn = value; }
        }

        /*
        public bool Banker
        {
            get { return banker; }
            set { banker = value; }
        }

        public bool Prisoner
        {
            get { return prisoner; }
            set { prisoner = value; }
        }
        */

        public IStatePlayer State
        {
            get { return state; }
            set { state = value; }
        }

        public int Playing_Order
        {
            get { return playing_order; }
            set { playing_order = value; }
        }

        public int Cash
        {
            get { return cash; }
            set { cash = value; }
        }
        /*
        public List<Property> Properties
        {
            get { return properties; }
            set { properties  = value; }
        }
        */
        public Dice TwoDice
        {
            get { return twoDice; }
            set { twoDice = value; }
        }
        
        public List<Dice> Previewsdice
        {
            get { return previewsdice; }
            set { previewsdice = value; }
        }

        public void Action()
        {
            state.Action(this);
        }

        public bool IsPrisoner()
        {
            return state.IsPrisoner(this);
        }

        public int SumDice()
        {
            int sum = this.twoDice.Die1 + this.twoDice.Die2;
            return sum;
        }

        public bool DoubleDice()
        {
            if (this.twoDice.Die1 == this.twoDice.Die2)
            {
                return true;
            }
            return false;
        }

        public bool Replay()
        {
            if (DoubleDice() && !GoToJail() && !IsPrisoner()) //a vérifier
            {
                this.previewsdice.Add(this.twoDice);
                Console.WriteLine("You can play again !\n");
                return true;
            }
            return false;
        }

        public bool GoToJail()
        {
            if (previewsdice.Count > 2) //If the player made 3 doubles consecutifs
            {
                state = new Prisoner();
                Action();
                return true;
            }
            return false;
        }

        public bool EndTurn()
        {
            if (!Replay())
            {
                this.previewsdice = new List<Dice>(); //reset list for non-consecutive double
                return true;
            }
            return false;
        }

        public void PickCard()
        {
            Console.WriteLine("Here is the card you picked : ");
        }

        public int ChoosePawn(List<String> colorList)
        {
            int col = -1;
            bool valid = false;
            do
            {
                valid = true;
                Console.WriteLine("Please choose your pawn's color : ");
                Console.WriteLine("You have a choice with : ");
                foreach (String color in colorList)
                {
                    Console.WriteLine("\t " + colorList.IndexOf(color) + " : " + color);
                }
                int nb = colorList.Count();
                Console.Write("Make your choice >>  ");
                try
                {
                    col = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException) 
                { }
                if ( col >= nb || col < 0)
                    {
                        Console.WriteLine("your choice <" + col + "> isn't available => try again ");
                        valid = false;
                    }
            } while (!valid);
            this.hispawn = new Pawn(colorList[col]);
            Console.WriteLine("\nYou choose {0}", colorList[col]);
            return col;
        }

        public void RollDice()
        {
            twoDice.Rolldice();
        }

        public void DisplayDiceValue()
        {
            Console.WriteLine("\tRolled <{0}> and <{1}> ! \n\tTotal of {2} ", twoDice.Die1, twoDice.Die2, SumDice());
        }

        public void Move()
        {
            if (IsPrisoner())
            {
                Console.WriteLine("You can't move, you are in jail");
            }
            else
            {
                hispawn.Position = (hispawn.Position + SumDice() )% 40;
            }
        }

        public void BuyLand(Box land)
        {
            Console.WriteLine("Do you want to buy this {0} ? It costs {1}$", land.Box_name, Math.Abs(land.Box_value));
            Console.WriteLine("\n1/ YES \n2/ NO");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    if (cash >= Math.Abs(land.Box_value))
                    {
                        cash += land.Box_value;
                        land.Owner = this;
                        Console.WriteLine(" This {0} has been added to your proprieties", land.Box_name);
                    }
                    else
                    {
                        Console.WriteLine("You can't buy this property.");
                    }
                    break;
                case 2:
                    Console.WriteLine("You chose to not buy this property");
                    break;
                default:
                    Console.WriteLine("\ninvalid choice => choose again....");
                    break;
            }
        }

        public void NoMoreCash()
        {
            this.cash = 0;
            Console.WriteLine("\nYou don't have any money left....\n\tYou lost");
        }

        public void PayingOwner(Box land)
        {
            Console.WriteLine("You are on the land of {0}... You need to pay him {1}$", land.Owner.Hispawn.Color, Math.Abs(land.Box_value));
            if (this.cash <= Math.Abs(land.Box_value))
            {
                NoMoreCash();
            }
            else { this.cash += land.Box_value; }
            land.Owner.Cash += Math.Abs(land.Box_value);
        }
    }
}
