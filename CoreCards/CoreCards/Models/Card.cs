using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCards.Models
{
    public class Card
    {
        private CardSuit suit;
        private CardValue value;

        public CardSuit Suit => suit;
        public CardValue Value => value;

        public Card(int suit, int value)
        {
            this.suit = (CardSuit)suit;
            this.value = (CardValue)value;
        }

        public override string ToString()
        {
            return value.ToString() + Utl.Constants.SINGLE_SPACE_STRING + suit.ToString();
        }

        private string getImageURL()
        {
            return Utl.Constants.IMAGES_FOLDER + this.suit.ToString() + Utl.Constants.PNG_EXTENSION;
        }
    }
}
