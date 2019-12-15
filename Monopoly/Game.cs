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
            List<int> Sums = null;
            Console.WriteLine("How many players will be playing ? ");
            int nbplayers = 0;
            do
            {
                Console.WriteLine("Please enter a number between 1 and 4 included : ");
                nbplayers = Convert.ToInt32(Console.ReadLine());
                if (nbplayers <= 0 || nbplayers > 4)
                {
                    valid = false;
                    Console.WriteLine("Your choice isn't valid, try again !");
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
                Console.WriteLine("The player " + player.Hispawn.Color + " is the " + (players.IndexOf(player) + 1) + " player");
            }
        }

        public void OnePlayer(List<int> Sums)
        {
            //Each player starts with 1500$
            players.Add(new Player(1500, Tuple.Create(new Dice(), new Dice())));
            players.Add( new Player(1500, Tuple.Create(new Dice(), new Dice()) , new Pawn("Grey")) ); //This player is the computer
            int pawnused = players[0].ChoosePawn(pawnavailable);
            pawnavailable.RemoveAt(pawnused);
            foreach (Player player in players)
            {
                player.RollDice();
                Sums.Add(player.SumDice());
            }
        }

        public void MultiPlayer(int nbplayers, List<int> Sums)
        {
            for (int i = 0; i < nbplayers; i++)
            {
                //Each player starts with 1500$
                players.Add(new Player(1500, Tuple.Create(new Dice(), new Dice())));
            }
            foreach (Player player in players)
            {
                int pawnused = player.ChoosePawn(pawnavailable);
                pawnavailable.RemoveAt(pawnused);
                player.RollDice();
                Sums.Add(player.SumDice());
            }
        }
    }
}
