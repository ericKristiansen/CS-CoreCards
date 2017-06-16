using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCards.Models
{
    public class Deck
    {
        private const string TO_STRING_VALUE = "Deck Type Object";
        private List<Card> cards = new List<Card>();
        private Random random = new Random();

        public List<Card> Cards => cards;

        public Deck()
        {
            generateDeck();
        }

        private void generateDeck()
        {
            for (int suit = (int)CardSuit.Hearts; suit <= (int)CardSuit.Spades; suit++)
            {
                for (int value = (int)CardValue.Ace; value <= (int)CardValue.King; value++)
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        public IOrderedEnumerable<Card> ShuffleDeck()
        {
            return cards.OrderBy(card => random.Next());
        }

        /* Not Implemented
        public IOrderedEnumerable<Card> GetAscendingCardsAceHigh()
        {
            return cards.OrderBy(card => { if (card.Value == CardValue.Ace){ return CardValue.AceHigh; }return card.Value; });
        } */

        public IOrderedEnumerable<Card> GetAscendingCardsKingHigh()
        {
            return cards.OrderBy(card => card.Value);
        }

        public override string ToString()
        {
            return TO_STRING_VALUE;
        }

    }

    public enum CardSuit
    {
        Hearts = 1,
        Diamonds,
        Clubs,
        Spades
    };

    public enum CardValue
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Joker = 14,
        AceHigh = 15
    };


}
