using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game
    {
        BoardGame board;
        Queue<Card> chance_cards;
        Queue<Card> comm_cards;
        List<Player> players;
        List<String> pawnavailable;

        public Game()
        {
            board = BoardGame.GetInstance();
            players = new List<Player>();
            chance_cards = CreateChance();
            comm_cards = CreateCommunity();
            String[] colorlist = { "Red", "Yellow", "Green", "Blue", "Black", "White", "Purple" };
            pawnavailable = new List<String>(colorlist);
        }

        public BoardGame Board
        {
            get { return board; }
        }

        public Queue<Card> CreateChance() //La création des cartes n'est pas encore faite de manière dynamique 
        {
            Card chance1 = new Chance(1, "You receive 100$");
            Card chance2 = new Chance(2, "Continue until the Go box");
            Card chance3 = new Chance(3, "Go to jail");
            Card chance4 = new Chance(4, "You receive 30$");
            Card chance5 = new Chance(5, "Move 1 box ahead");
            Card chance6 = new Chance(6, "Move 7 boxes ahead");
            
            // creation of chance deck
            Queue<Card> deck_chance = new Queue<Card>();
            deck_chance.Enqueue(chance6); // LAST CARD OF THE DECK
            deck_chance.Enqueue(chance5);
            deck_chance.Enqueue(chance4);
            deck_chance.Enqueue(chance3);
            deck_chance.Enqueue(chance2);
            deck_chance.Enqueue(chance1); // IS ON THE TOP OF THE DECK

            return deck_chance;
        }

        public Queue<Card> CreateCommunity()
        {
            Card community1 = new Community(1, "You receive 100$");
            Card community2 = new Community(2, "You lose 100$");
            Card community3 = new Community(3, "You reveive 40$");
            Card community4 = new Community(4, "You go to jail");
            Card community5 = new Community(5, "You receive 300$");
            Card community6 = new Community(6, "Move 2 boxes ahead");
            // community stack
            Queue<Card> deck_community = new Queue<Card>();
            deck_community.Enqueue(community6);
            deck_community.Enqueue(community5);
            deck_community.Enqueue(community4);
            deck_community.Enqueue(community3);
            deck_community.Enqueue(community2);
            deck_community.Enqueue(community1);

            return deck_community;
        }

        public void PlayingOrder(List<int> Sums)
        {
            int nb = Sums.Count();
            for (int i = 0; i < nb - 1; i++)
            {
                if (Sums[i] < Sums[i + 1])
                {
                    players.Insert(i, players[i + 1]);
                    players.RemoveAt(i + 2);
                }
            }
        }

        public void Initialization()
        {
            bool valid = true;
            List<int> Sums = new List<int>();
            Console.WriteLine("\nHow many players will be playing ? ");
            int nbplayers = 0;
            do
            {
                Console.Write("Please enter a number between 2 and 4 included : ");
                //Console.Write("Please enter a number between 1 and 4 included : "); //Playing with COMPUTER isn't done yet
                try
                {
                    nbplayers = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException) { }
                if (nbplayers <= 1 || nbplayers > 4)
                {
                    valid = false;
                    Console.WriteLine("Your choice isn't valid, try again !\n");
                }
            } while (!valid);
            if (nbplayers == 1) //NOT OVER YET
            {
                OnePlayer(Sums);
            }
            else
            {
                MultiPlayer(nbplayers, Sums);
            }
            PlayingOrder(Sums);
            foreach (Player player in players)
            {
                Console.WriteLine("The player " + player.Hispawn.Color + " is the player " + (players.IndexOf(player) + 1));
            }
        }

        public void OnePlayer(List<int> Sums)
        {
            //Each player starts with 1500$
            players.Add(new Player(1500, new Dice()));
            players.Add(new Player(1500, new Dice(), new Pawn("Grey"))); //This player is the computer
            int pawnused = players[0].ChoosePawn(pawnavailable);
            pawnavailable.RemoveAt(pawnused);
            foreach (Player player in players)
            {
                if (player.Hispawn.Color == "Grey")
                {
                    Console.WriteLine("Computer Grey : ");
                }
                player.RollDice();
                player.DisplayDiceValue();
                Sums.Add(player.SumDice());
            }
        }

        public void MultiPlayer(int nbplayers, List<int> Sums)
        {
            for (int i = 0; i < nbplayers; i++)
            {
                //Each player starts with 1500$
                players.Add(new Player(1500, new Dice()));
            }
            foreach (Player player in players)
            {
                Console.WriteLine();
                int pawnused = player.ChoosePawn(pawnavailable);
                pawnavailable.RemoveAt(pawnused);
                player.RollDice();
                player.DisplayDiceValue();
                Sums.Add(player.SumDice());
            }
        }

        public void ATurn()
        {
            foreach (Player p in players)
            {
                /*
                if (p.Hispawn.Color != "Grey")
                {*/
                Console.WriteLine("\n\t\tPlayer {0} it's your turn !", p.Hispawn.Color);
                Console.WriteLine("\t\tYou have {0}$", p.Cash);
                do
                {
                    Console.WriteLine("\nPress any key to roll dice : ");
                    Console.ReadKey();
                    Console.WriteLine();
                    p.RollDice();
                    p.DisplayDiceValue();
                    p.GoingToJail();
                    p.Move();
                    Console.WriteLine(">> You are on {0}", board.Squares[p.Hispawn.Position].Box_name);
                    board.DispayBoard();
                    ActionPlayer(p);
                } while (!p.EndTurn());
                if (p.IsPrisoner())
                {
                    p.TurninJail += 1; 
                }
                else
                {
                    p.TurninJail = 0;
                }
                //}
                /*  COMPUTER ISN'T DONE YET
                else
                {
                    Console.WriteLine("\n\t\tIt's the computer {0} turn !", p.Hispawn.Color);
                    do
                    {
                        Console.WriteLine("\nRolling dice.... press any key to continue ");
                        Console.ReadKey();
                        Console.WriteLine();
                        p.RollDice();
                        p.DisplayDiceValue();
                        p.GoToJail();
                        p.Move();
                        Console.WriteLine(">> Computer is on {0}", board.Squares[p.Hispawn.Position].Box_name);
                        board.DispayBoard();
                        ActionPlayer(p);
                    } while (!p.EndTurn());
                }*/
                if (p.Lost)
                {
                    Console.WriteLine("Player {0} lost...", p.Hispawn.Color);
                    players.Remove(p);
                }
            }
        }

        public bool EndGame(int nb_turn, int max_turn)
        {
            bool end = false;
            if (nb_turn > max_turn) //To simplify we impose in our rules that a game ends after a number of turns
            {
                end = true;
                Console.WriteLine("\t\tTHE GAME IS OVER ");
            }
            if (players.Count <= 1)
            {
                end = true;
                Console.WriteLine("\t\tTHE GAME IS OVER ");
                Console.WriteLine("Player {0} won with a total of {1}$", players[0].Hispawn.Color, players[0].Cash);
            }
            return end;
        }

        public void ActionPlayer(Player player)
        {
            int position = player.Hispawn.Position;
            Box box = board.Squares[position];
            if (box.Box_name == "Go" || player.MadeATurn() && !player.IsPrisoner())  
            {
                player.Cash += board.Squares[0].Box_value;
                Console.WriteLine("You earned {0}$ because you're starting the game or going through the go case :)", board.Squares[0].Box_value);
                Console.WriteLine("You now have {0}$", player.Cash);
            }
            if (box.Box_name == "Tax")
            {
                Console.WriteLine("You lose {0}$ because of a tax :( ", Math.Abs(box.Box_value));
                if (player.Cash > Math.Abs(box.Box_value))
                {
                    player.Cash += box.Box_value;
                    Console.WriteLine("You now have {0}$", player.Cash);
                }
                else
                {
                    player.NoMoreCash();
                }
            }
            if (box.Box_name == "Station")
            {
                if (box.Owner == null)
                {
                    player.BuyLand(box);
                }
                else
                {
                    if (box.Owner != player)
                    {
                        player.PayingOwner(box);
                    }
                    else { Console.WriteLine("This is your propriety !"); }
                }
            }
            if (box.Box_name == "Parking")
            {
                if (box.Owner == null)
                {
                    player.BuyLand(box);
                }
                else
                {
                    if (box.Owner != player)
                    {
                        player.PayingOwner(box);
                    }
                    else { Console.WriteLine("This is your propriety !"); }
                }
            }
            if (box.Box_name.Contains("Street"))
            {
                if (box.Owner == null)
                {
                    player.BuyLand(box);
                }
                else
                {
                    if (box.Owner != player)
                    {
                        player.PayingOwner(box);
                    }
                    else { Console.WriteLine("This is your propriety !"); }
                }
            }
            if (box.Box_name == "Jail")
            {
                Console.WriteLine("You're on the jail case");
                if (player.IsPrisoner())
                {
                    Console.WriteLine("You're behind bars..");

                }
                else
                {
                    Console.WriteLine("You're visiting a friend");
                }
            } 
            if (box.Box_name == "Go To Jail")
            {
                player.GoToJail();
                Console.WriteLine("You skip the next 3 turns");                
            }
            if (box.Box_name == "Community")
            {
                Console.WriteLine("Press any key to pick one community card");
                Console.ReadKey();
                player.PickCard(comm_cards,this);
            }
            if (box.Box_name == "Chance")
            {
                Console.WriteLine("Press any key to pick one chance card");
                Console.ReadKey();
                player.PickCard(chance_cards,this);
            }                  

        }
    }
}
