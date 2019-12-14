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
        protected bool banker = false; // if it's a banker he gives the money at the beginning
        protected bool prisoner = false; //prisoner or not
        */
        protected IStatePlayer state;
        protected int playing_order; // ordre dans lequel ils commencent à jouer
        protected int cash; // amount of money earned
        protected Pawn hispawn;
        protected List<Property> properties; // properties earned 
        protected Tuple<Dice, Dice> twoDice; // Dice used by the player
        protected List<Tuple<Dice, Dice>> previewsdice; //List of maximum 3 tuple of dice
      
        public Player(int playing_order, int cash, Tuple<Dice, Dice> twoDice) : this(cash,twoDice)
        {
            this.playing_order = playing_order;
        }

        public Player(int cash, Tuple<Dice, Dice> twoDice)
        {
            this.cash = cash;
            this.twoDice = twoDice;
            this.properties = null;
            this.state = new Free();
        }

        public Player(int cash, Tuple<Dice, Dice> twoDice, Pawn pawn) : this(cash,twoDice)
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

        public List<Property> Properties
        {
            get { return properties; }
            set { properties  = value; }
        }

        public Tuple<Dice,Dice> TwoDice
        {
            get { return twoDice; }
            set { twoDice = value; }
        }
        
        public List<Tuple<Dice, Dice>> Previewsdice
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
            int sum = this.twoDice.Item1.Dice_value + this.twoDice.Item2.Dice_value;
            return sum;
        }

        public bool DoubleDice()
        {
            if (this.twoDice.Item1.Dice_value == this.twoDice.Item2.Dice_value)
            {
                return true;
            }
            return false;
        }

        public bool Replay()
        {
            if (DoubleDice() && previewsdice.Count < 3 &&!IsPrisoner()) //a vérifier
            {
                this.previewsdice.Add(this.twoDice);
                Console.WriteLine("You can play again !");
                return true;
            }
            return false;
        }

        public bool GoToJail()
        {
            if (previewsdice.Count >= 3) //If the player made 3 doubles consecutifs
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
                this.previewsdice = null; //reset list for non-consecutive double
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
                Console.WriteLine("Make your choice >>  ");
                try
                {
                    col = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e) 
                { }
                if ( col >= nb || col < 0)
                    {
                        Console.WriteLine("your choice <" + col + "> isn't available => try again ");
                        valid = false;
                    }
            } while (!valid);
            this.hispawn = new Pawn(colorList[col]);
            return col;
        }

        public void RollDice()
        {
            twoDice.Item1.Rolldice();
            twoDice.Item2.Rolldice();
        }

        public void DisplayDiceValue()
        {
            Console.WriteLine("You rolled <{0}> and <{1}> ! \nTotal of {2} ", twoDice.Item1.Dice_value, twoDice.Item2.Dice_value, SumDice());
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
    }
}
