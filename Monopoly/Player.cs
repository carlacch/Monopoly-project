using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        protected bool banker = false; // if it's a banker he gives the money at the beginning
        protected bool prisoner = false; //prisoner or not
        protected int playing_order; // ordre dans lequel ils commencent à jouer
        protected int cash; // amount of money earned
        protected Pawn hispawn;
        protected List<Property> properties; // properties earned 
        protected Tuple<Dice, Dice> twoDice; // Dice used by the player
        protected List<Tuple<Dice, Dice>> previewsdice; //List of maximum 3 tuples of dice

        public Player(int playing_order, int cash, Tuple<Dice, Dice> twoDice)
        {
            this.playing_order = playing_order;
            this.cash = cash;
            this.twoDice = twoDice;
            this.properties = null;
        }

        public Player(int cash, Tuple<Dice, Dice> twoDice)
        {
            this.cash = cash;
            this.twoDice = twoDice;
            this.properties = null;
        }

        public Player(int cash, Tuple<Dice, Dice> twoDice, Pawn pawn)
        {
            this.cash = cash;
            this.twoDice = twoDice;
            this.hispawn = pawn;
            this.properties = null;
        }

        public Pawn Hispawn
        {
            get { return hispawn; }
            set { hispawn = value; }
        }

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
            set { properties = value; }
        }

        public Tuple<Dice, Dice> TwoDice
        {
            get { return twoDice; }
            set { twoDice = value; }
        }

        public List<Tuple<Dice, Dice>> Previewsdice
        {
            get { return previewsdice; }
            set { previewsdice = value; }
        }

        public int SumDice()
        {
            int sum = this.twoDice.Item1.Dice_value + this.twoDice.Item2.Dice_value;
            return sum;
        }

        public bool DoubleDice() // if true the player plays again
        {
            if (this.twoDice.Item1.Dice_value == this.twoDice.Item2.Dice_value)
            {
                return true;
            }
            return false;
        }

        public bool Replay()
        {
            if (DoubleDice())
            {
                this.previewsdice.Add(this.twoDice);
                return true;
            }
            return false;
        }

        public bool GoToJail()
        {
            if (previewsdice.Count >= 3) //If the player made 3 doubles in a row
            {
                prisoner = true;
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

        public void PickCardChance()
        {
            Chance topOfStack = stack_chance.Pop();
            Console.WriteLine("Here is the card you picked : " + Chance.description);
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
                if (col >= nb || col < 0)
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

        public override string ActionPlayer(Player player)
        {
            for (int i = 1; i < 40; i++)
            {
                if (squares[i].box_name == "go")  // in case jail
                {
                    player.Cash += 200;
                    Console.WriteLine("You earned 200$ because you're starting the game or going through the go case :)");
                }
                else if (squares[i].box_name == "tax")
                {
                    player.Cash -= 40;
                    Console.WriteLine("You lose 40$ because of a tax :( ");
                }

                else if (squares[i].box_name == "station")
                {
                    Console.WriteLine("Do you want to buy this station ? It costs 100$");
                    Console.WriteLine("\n1/ YES \n2/ NO");
                    int k = int.Parse(Console.ReadLine());
                    switch (k)
                    {
                        case 1:
                            if (player.Cash >= 100)
                            {
                                player.Cash -= 100;
                                player.properties.Add("station", 200);
                                Console.WriteLine(" This station has been added to your proprieties");
                            }
                            else
                            {
                                Console.WriteLine("You can't buy this property.");

                            }
                            break;

                        case 2:
                            Console.WriteLine("You chose to not buy this property");
                            break;
                    }

                }
                else if (squares[i].box_name == "parking")
                {
                    Console.WriteLine("Do you want to buy this parking ? It costs 20$");
                    Console.WriteLine("\n1/ YES \n2/ NO");
                    int l = int.Parse(Console.ReadLine());
                    switch (l)
                    {
                        case 1:
                            if (player.Cash >= 20)
                            {
                                player.Cash -= 20;
                                player.properties.Add("parking", 20);
                                Console.WriteLine(" This parking has been added to your proprieties");
                            }
                            else
                            {
                                Console.WriteLine("You can't buy this property.");

                            }
                            break;

                        case 2:
                            Console.WriteLine("You chose to not buy this property");
                            break;
                    }

                }
                else if (squares[i].box_name == "street")
                {
                    Console.WriteLine("Do you want to buy this parking ? It costs 150$");
                    Console.WriteLine("\n1/ YES \n2/ NO");
                    int m = int.Parse(Console.ReadLine());
                    switch (m)
                    {
                        case 1:
                            if (player.Cash >= 150)
                            {
                                player.Cash -= 150;
                                player.properties.Add("street", 150);
                                Console.WriteLine(" This street has been added to your proprieties");
                            }
                            else
                            {
                                Console.WriteLine("You can't buy this property.");

                            }
                            break;

                        case 2:
                            Console.WriteLine("You chose to not buy this property");
                            break;
                    }
                }
                else if (squares[i].box_name == "jail")
                {
                    Console.WriteLine("You're on the jail case, nothing happens");
                }

                else if (squares[i].box_name == "go_to_jail")
                {
                    Console.WriteLine("You're in jail ! You skip the new 3 turns");
                    prisoner = true;
                }

                else if (squares[i].box_name == "community")
                {
                    Console.WriteLine("Pick one community card");
                    /// to do
                }

                else if (squares[i].box_name == "chance")
                {
                    Console.WriteLine("Pick one chance card");
                    /// to do
                }



            }
        }
    }

}
