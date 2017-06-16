using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCards.Models
{
    /// <summary>
    /// This class holds the methods and fields associated with a playing card.
    /// </summary>
    public class Card
    {
        private CardSuit suit;
        private CardValue value;

        public CardSuit Suit => suit;
        public CardValue Value => value;

        /// <summary>
        /// Initialize the card with a suit and a value.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="value"></param>
        public Card(int suit, int value)
        {
            this.suit = (CardSuit)suit;
            this.value = (CardValue)value;
        }

        /// <summary>
        /// Provide an override for the to string method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return value.ToString() + Utl.Constants.SINGLE_SPACE_STRING + suit.ToString();
        }

    }
}
