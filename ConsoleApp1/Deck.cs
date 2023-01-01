using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();

            foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
            {
                if(suit != Card.Suit.None)
                {
                    for (int i = 2; i <= 14; i++)
                    {
                        cards.Add(new Card(suit, i));
                    }
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
        }

        public Card DrawCard()
        {
            Card drawnCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return drawnCard;
        }
    }
}
