using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarneebo
{
    internal class Card
    {
        public enum Suit { Clubs, Diamonds, Hearts, Spades, None}
        public Suit CardSuit { get; set; }
        public int CardRank { get; set; }

        public Card(Suit suit, int rank)
        {
            CardSuit = suit;
            CardRank = rank;
        }

        public int CompareTo(Card other)
        {
            return CardRank.CompareTo(other.CardRank);
        }
    }
}
