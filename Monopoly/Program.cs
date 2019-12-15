using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var boardgame = new FinalBoardGame();
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
            stack_chance.Push(chance2);
            stack_chance.Push(chance3);
            stack_chance.Push(chance4);
            stack_chance.Push(chance5);
            stack_chance.Push(chance6 ); // ON THE TOP OF THE STACK

            // creation community cards 
            Community community1 = new Community(1, "You receive 100$");
            Community community2 = new Community(2, "You lose 10$");
            Community community3 = new Community(3, "You reveive 40$");
            Community community4 = new Community(4, "You go to jail");
            Community community5 = new Community(5, "You receive 300$");
            Community community6 = new Community(6, "You receive 1$");

            // community stack
            Stack<Community> stack_community = new Stack<Community>();
            stack_community.Push(community1);
            stack_community.Push(community2);
            stack_community.Push(community3);
            stack_community.Push(community4);
            stack_community.Push(community5);
            stack_community.Push(community6);

             public void PickCardChance()
            {
                Chance topOfStack = stack_chance.Pop(); // take the first card at the top of the stack
                Console.WriteLine("Here is the card you picked : " + topOfStack.description);
                // don't know how to put the select card below

            }

            public void PickCardCommunity()
            {
                Community topOfStack2 = stack_community.Pop(); // take the first card at the top of the stack
                Console.WriteLine("Here is the card you picked : " + topOfStack2.description);
                // don't know how to put the select card below

            }
        }
}
