using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CoreCards.Models;
using System.Linq;

namespace Testing123
{
    /// <summary>
    /// Provide a class to test the object methods in the CoreCards application.
    /// </summary>
    [TestFixture]
    public class ClassTest
    {

        /// <summary>
        /// This method tests that the initialization of the card object
        /// assigns the correct values.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCase(CardSuit.Clubs, CardValue.Ace, "Ace Clubs")]
        [TestCase(CardSuit.Diamonds, CardValue.Four, "Four Diamonds")]
        [TestCase(CardSuit.Hearts, CardValue.Jack, "Jack Hearts")]
        public void CorrectCardOutput(int suit, int value, string expected)
        {
            Assert.That(new Card(suit, value).ToString(), Is.EqualTo(expected));
        }

        /// <summary>
        /// This method ensures that the number of generated cards is correct.
        /// </summary>
        /// <param name="expected"></param>
        [TestCase(52)]
        public void GenerateNumberOfCards(int expected)
        {
            Assert.That(new Deck().Cards.Count, Is.EqualTo(expected));
        }

        /// <summary>
        /// This method asserts that the deck initialization correctly assigns
        /// a list of card objects their values.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="expected"></param>
        [TestCase(5, "Six Hearts")]
        [TestCase(13, "Ace Diamonds")]
        [TestCase(51, "King Spades")]
        public void EnsureCardPosition(int index, string expected)
        {
            Assert.That(new Deck().Cards[index].ToString(), Is.EqualTo(expected));
        }

        /* *********************
         * The shuffle is random. It may be the case where this test isn't always aserted without exception.
         * The test is that this is an infrequent collision.
         * Because of the occasional exception, this test is commented out. Uncomment it to run the test.
         * ************************ /
         /// <summary>
         /// This method tests whether the deck shuffle method returns a reordered deck.
         /// </summary>
         /// <param name="index"></param>
         /// <param name="expected"></param>
        [TestCase(5, "Six Hearts")]
        [TestCase(13, "Ace Diamonds")]
        [TestCase(51, "King Spades")]
        public void EnsureShufflePosition(int index, string expected)
        {
            Assert.That((new Deck().ShuffleDeck()).ElementAt<Card>(index).ToString() , Is.Not.EqualTo(expected));
        }  */

        /// <summary>
        /// This method ensures that the top position of value belongs to the king cards of every suit.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="expected"></param>
        [TestCase(48, "King Hearts")]
        [TestCase(49, "King Diamonds")]
        [TestCase(50, "King Clubs")]
        [TestCase(51, "King Spades")]
        public void EnsureKingsHigh(int index, string expected)
        {
            Assert.That(new Deck().GetAscendingCardsKingHigh().ElementAt<Card>(index).ToString(), Is.EqualTo(expected));
        }


    }
}
