using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Game
    {
        BoardGame board;
        List<Card> cards;
        List<Player> players;
        List<String> pawnavailable;

        public Game()
        {
            board = BoardGame.GetInstance();
            players = new List<Player>();
            cards = new List<Card>();
            String[] colorlist = {"Red","Yellow","Green","Blue","Black","White","Purple" };
            pawnavailable = new List<String>(colorlist);
        }

        public BoardGame Board
        {
            get { return board; }
        }

        public void PlayingOrder(List<int> Sums)
        {
            int nb = Sums.Count();
            for (int i = 0; i < nb-1; i++)
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
                Console.Write("Please enter a number between 1 and 4 included : ");
                try
                {
                    nbplayers = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException) { }
                if (nbplayers <= 0 || nbplayers > 4)
                {
                    valid = false;
                    Console.WriteLine("Your choice isn't valid, try again !\n");
                }
            } while (!valid);
            if (nbplayers == 1)
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
                Console.WriteLine("The player " + player.Hispawn.Color + " is the player " + (players.IndexOf(player) + 1) );
            }
        }

        public void OnePlayer(List<int> Sums)
        {
            //Each player starts with 1500$
            players.Add(new Player(1500, new Dice()) );
            players.Add( new Player(1500, new Dice() , new Pawn("Grey")) ); //This player is the computer
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
                if (p.Hispawn.Color != "Grey")
                {
                    Console.WriteLine("\n\t\tPlayer {0} it's your turn !", p.Hispawn.Color);
                    do
                    {
                        Console.WriteLine("\nPress any key to roll dice : ");
                        Console.ReadKey();
                        Console.WriteLine();
                        p.RollDice();
                        p.DisplayDiceValue();
                        p.GoToJail(); 
                        p.Move();
                        Console.WriteLine(">> You are on {0}", board.Squares[p.Hispawn.Position].Box_name);
                        board.DispayBoard();
                    } while ( !p.EndTurn() );
                }
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
                    } while (!p.EndTurn());
                }
            }
        }

        public bool EndGame(int nb_turn)
        {
            bool end = false;
            if (nb_turn > 5) //To simplify we impose in our rules that a game ends after the 5th turn
            {
                end = true;
            }
            return end;
        }

    }
}
