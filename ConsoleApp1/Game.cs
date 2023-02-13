using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tarneebo.Program;

namespace Tarneebo
{
    internal class Game
    {
        public static Player[] Players = new Player[4];
        public static int turn { get; set; }
        public Deck Deck = new Deck();
        public Trick[] Tricks = new Trick[13];
        public int Score { get; set; }
        public int highestEst { get; set; }
        public int team0score { get; set; }
        public int team1score { get; set; }
        public Card.Suit CurrentTarneebSuit { get; set; }
        public int highestEstimatorIndex { get; set; }
        public Game()
        {
            Deck.Shuffle();
            //Add 4 Players to the Players list
            for(int i = 0;i<4 ; i++)
            {
                Players[i] = new Player($"Player{i}");
                //Assign them to Teams
                if (i < 2)
                {
                    Players[i].Team = 0;
                }
                else
                {
                    Players[i].Team = 1;
                }
            }
            //Give each player 13 cards
            foreach(Player p in Players)
             {
                for(int i = 0;i<13;i++)
                {
                    //if a player has less than 13 cards give a card to him
                    p.Cards.Add(Deck.DrawCard());
                }
             }
            //Collect Estimates from the players
            CollectEstimates();
            PlayTricks();
            for(int i=0;i<4;i++)
            {
                if (Players[i].Team == 0) 
                {
                    team0score += Players[i].Score;
                }
                else { 
                    team1score+= Players[i].Score;
                }
            }
            if (Players[highestEstimatorIndex].Team == 0)
            {
                Console.WriteLine($"Highest estimator is of team 0");
                if(team0score >= highestEst)
                {
                    team1score= 0;
                }
                else
                {
                    team0score = -highestEst;
                }

            }else if(Players[highestEstimatorIndex].Team == 1)
            {
                Console.WriteLine($"Highest estimator is of team 1");
                if (team1score >= highestEst)
                {
                    team0score = 0;
                }
                else
                {
                    team1score = -highestEst;
                }
            }
        }

        public void CollectEstimates()
        {
            int highestEstimate = 0;
            // Ask each player to calculate their estimate
            foreach (int i in Trick.CalcIndex(turn++))
            {
                int est = Players[i].CalculateEstimate();
                if (est > highestEstimate || highestEstimate==0)
                {
                    highestEstimate = est;
                    highestEstimatorIndex = i;
                }
            }

            // Determine the player with the highest estimate
            //If no player estimated above the minimum estimate which is 7, the last player is forced the minimum estimate
            if(highestEstimate < 7)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                int rnd = new Random().Next(0, 4);
                highestEstimatorIndex = rnd;
                highestEstimate = 7;
                CurrentTarneebSuit = Players[rnd].wantedsuit;
            }
            highestEst = highestEstimate;
            Console.WriteLine($"Highest estimate is {highestEstimate} with the suit of {CurrentTarneebSuit} by {Players[highestEstimatorIndex].Name}");
        }
        public void PlayTricks()
        {
            Trick.CurrentTarneebSuit = CurrentTarneebSuit;
            Trick.startingPlayerIndex = highestEstimatorIndex;
            for (int i = 0; i < 13; i++)
            {
                Trick t = new Trick(); 
            }
        }
    }
}
