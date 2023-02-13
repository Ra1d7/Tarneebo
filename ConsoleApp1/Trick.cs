using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tarneebo.Card;
using static Tarneebo.Game;

namespace Tarneebo
{
    internal class Trick
    {
        public static Card.Suit CurrentTarneebSuit { get; set; }
        public static int startingPlayerIndex { get; set; }
        public Card[] suitCards = new Card[4];
        private Card.Suit currentSuit;
        public Trick() 
        {
            foreach(int i in CalcIndex(startingPlayerIndex))
            {
                Card c = Game.Players[i].PlayCard(CurrentTarneebSuit);
                suitCards[i] = new Card(c.CardSuit, c.CardRank);
            }
            int winningplayerindex = WinningPlayerIndex();
            for(int i=0;i<Game.Players.Length;i++)
            {
                if (Game.Players[i].Name == $"Player{winningplayerindex}")
                {
                    Console.WriteLine($"{Game.Players[i].Name} Won the Trick");
                    Game.Players[i].Score++;
                    Trick.startingPlayerIndex= winningplayerindex;
                }
            }
        }
        public static int[] CalcIndex(int startindex)
        {
            int[] indexs = new int[4];
            switch (startindex)
            {
                case 0:
                    indexs = new int[] { 0, 1, 2, 3 };
                    break;
                case 1:
                    indexs = new int[] { 1, 2, 3, 0 };
                    break;
                case 2:
                    indexs = new int[] { 2, 3, 0, 1 };
                    break;
                case 3:
                    indexs = new int[] { 3, 0, 1, 2 };
                    break;
            }
            return indexs;
        }
        public int WinningPlayerIndex() {
            currentSuit = suitCards[0].CardSuit;
            bool thereistarneeb = false;
        tarneeb:
            int highestrank = 0;
            foreach (Card card in suitCards)
            {
                if (card.CardSuit == currentSuit)
                {
                    if(card.CardRank > highestrank) 
                    {
                    highestrank= card.CardRank;
                    }
                }
                else if(card.CardSuit == CurrentTarneebSuit && thereistarneeb==false)
                {
                    thereistarneeb = true;
                    currentSuit = CurrentTarneebSuit;
                    goto tarneeb;
                }
            }
            for (int i=0;i<suitCards.Length;i++)
            {
                if (suitCards[i].CardRank == highestrank && suitCards[i].CardSuit == currentSuit)
                {
                    return i;
                }
            }
            return 654;
        }
    }
}
