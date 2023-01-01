using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public int Score { get; set; }
        public int Estimate { get; set; }
        public int Team { get; set; }
        public Card.Suit wantedsuit { get; set; }

        public Player(string name)
        {
            Name = name;
            Cards = new List<Card>();
            Score = 0;
            Estimate = 0;
        }

        public void SortCards()
        {
            Cards.Sort((card1, card2) => card1.CompareTo(card2));
        }
        public Card PlayCard(Card.Suit leadSuit)
        {
            // Check if the player has any cards of the lead suit
            List<Card> cardsOfLeadSuit = Cards.Where(card => card.CardSuit == leadSuit).ToList();
            if (cardsOfLeadSuit.Count > 0 && leadSuit != Card.Suit.None)
            {
                // Play a card of the lead suit
                Card cardToPlay = cardsOfLeadSuit[0];
                Cards.Remove(cardToPlay);
                Console.WriteLine($"Playing {cardToPlay.CardRank} of {cardToPlay.CardSuit} by {Name}");
                return cardToPlay;
            }
            else
            {
                // Play any card
                Card cardToPlay = Cards[0];
                Cards.Remove(cardToPlay);
                Console.WriteLine($"Playing {cardToPlay.CardRank} of {cardToPlay.CardSuit} by {Name}");
                return cardToPlay;
            }
        }


        public void CalculateEstimate()
        {
            // Determine the suit with the most cards in the player's hand
            int spadesCount = Cards.Count(card => card.CardSuit == Card.Suit.Spades);
            int heartsCount = Cards.Count(card => card.CardSuit == Card.Suit.Hearts);
            int diamondsCount = Cards.Count(card => card.CardSuit == Card.Suit.Diamonds);
            int clubsCount = Cards.Count(card => card.CardSuit == Card.Suit.Clubs);

            Card.Suit mostCommonSuit = Card.Suit.Spades;
            int mostCommonCount = spadesCount;
            if (heartsCount > mostCommonCount)
            {
                mostCommonSuit = Card.Suit.Hearts;
                mostCommonCount = heartsCount;
            }
            if (diamondsCount > mostCommonCount)
            {
                mostCommonSuit = Card.Suit.Diamonds;
                mostCommonCount = diamondsCount;
            }
            if (clubsCount > mostCommonCount)
            {
                mostCommonSuit = Card.Suit.Clubs;
                mostCommonCount = clubsCount;
            }
            wantedsuit = mostCommonSuit;

            // Calculate the player's estimate based on their cards and the potential Tarneeb suit
            int estimate = 0;
            foreach (Card card in Cards)
            {
                if (card.CardSuit == mostCommonSuit || card.CardRank > 10)
                {
                    estimate++;
                }
            }
            if (estimate < 7)
            {
                estimate = 0;
            }else if (estimate > 13)
            {
                estimate= 13;
            }
            Console.WriteLine($"{Name} Has Estimated {estimate}");
            Estimate = estimate;
        }
    }
}
