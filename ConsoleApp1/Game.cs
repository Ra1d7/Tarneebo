using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;

namespace ConsoleApp1
{
    internal class Game
    {
        public static Player[] Players = new Player[4];
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
                Console.WriteLine($"Highest estimator is of team 0");
                if (team1score >= highestEst)
                {
                    team0score = 0;
                }
                else
                {
                    team1score = -highestEst;
                }
            }
            Console.WriteLine(team0score);
            Console.WriteLine(team1score);
        }

        public void CollectEstimates()
        {
            // Ask each player to calculate their estimate
            foreach (Player player in Players)
            {
                player.CalculateEstimate();
            }

            // Determine the player with the highest estimate
            int highestEstimate = Players[0].Estimate;
            int highestEstimateIndex = 0;
            for (int i = 1; i < Players.Count(); i++)
            {
                if (Players[i].Estimate > highestEstimate && Players[i].Estimate>7)
                {
                    highestEstimate = Players[i].Estimate;
                    highestEstimateIndex = i;
                    CurrentTarneebSuit = Players[i].wantedsuit;
                    highestEstimatorIndex= i;
                }
            }
            //If no player estimated above the minimum estimate which is 7, the last player is forced the minimum estimate
            if(highestEstimate == 0)
            {
                Players[3].Estimate = 7;
                highestEstimate = 7;
                highestEstimateIndex = 3;
                CurrentTarneebSuit = Players[3].wantedsuit;
                highestEstimatorIndex= 3;
            }
            highestEst = highestEstimate;
            Console.WriteLine($"Highest estimate is {highestEstimate} with the suit of {CurrentTarneebSuit} by {Players[highestEstimatorIndex].Name}");
        }
        public void PlayTricks()
        {
            Trick.CurrentTarneebSuit = CurrentTarneebSuit;
            Trick.startingPlayerIndex = highestEstimatorIndex;
            Trick t1 = new Trick();
            Trick t2 = new Trick();
            Trick t3 = new Trick();
            Trick t4 = new Trick();
            Trick t5 = new Trick();
            Trick t6 = new Trick();
            Trick t7 = new Trick();
            Trick t8= new Trick();
            Trick t9 = new Trick();
            Trick t10 = new Trick();
            Trick t11 = new Trick();
            Trick t12 = new Trick();
            Trick t13 = new Trick();
        }
    }
}
