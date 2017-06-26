using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreCards.Models
{
    public class Deck
    {
        private const string TO_STRING_VALUE = "Deck Type Object";
        private List<Card> cards = new List<Card>();
        private static Random random = new Random();

        public List<Card> Cards => cards;

        /// <summary>
        /// Initialize the deck.
        /// </summary>
        public Deck()
        {
            GenerateDeck();
        }

        /// <summary>
        /// Generate each card of the deck to a suit and a value.
        /// </summary>
        private void GenerateDeck()
        {
            for (int suit = (int)CardSuit.Hearts; suit <= (int)CardSuit.Spades; suit++)
            {
                for (int value = (int)CardValue.Ace; value <= (int)CardValue.King; value++)
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        /// <summary>
        /// Return a randomized deck of cards.
        /// </summary>
        /// <returns></returns>
        public IOrderedEnumerable<Card> ShuffleDeck()
        {
            return cards.OrderBy(card => random.Next());
        }

        /// <summary>
        /// Return the cards in ascending order with the aces as a low value.
        /// </summary>
        /// <returns></returns>
        public IOrderedEnumerable<Card> GetAscendingCardsKingHigh()
        {
            return cards.OrderBy(card => card.Value);
        }

        /// <summary>
        /// Return the cards in ascending order with the aces as a high value.
        /// </summary>
        /// <returns></returns>
        public IOrderedEnumerable<Card> GetAscendingCardsAceHigh()
        {
            return cards.OrderBy(card => { if (card.Value == CardValue.Ace){ return CardValue.AceHigh; } return card.Value; });
        }

        /// <summary>
        /// Override the to string method to return a customized string value.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TO_STRING_VALUE;
        }

        /// <summary>
        /// Return the number of common card positions with the default deck.
        /// </summary>
        /// <param name="ordCard"></param>
        /// <returns></returns>
        public int GetNumberEqualCardPositions(IOrderedEnumerable<Card> ordCard)
        {
            int commonCards = 0;
            for (int cardIndex = 0; cardIndex < cards.Count; cardIndex++)
            {
                if (ordCard.ElementAt<Card>(cardIndex).ToString().Equals(cards.ElementAt(cardIndex).ToString()))
                {
                    commonCards++;
                }
            }
            return commonCards;
        }

    }

    /// <summary>
    /// Provide a nice enumeration to make the application more readable and robust.
    /// </summary>
    public enum CardSuit
    {
        Hearts = 1,
        Diamonds,
        Clubs,
        Spades
    };

    /// <summary>
    /// Provide a nice enumeration to make the application more readable and robust.
    /// </summary>
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
