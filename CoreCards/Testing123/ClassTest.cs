using NUnit.Framework;
using CoreCards.Models;
using System.Linq;
using System.Collections.Generic;

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

        /// <summary>
        /// This method tests whether the shuffle method returns a deck with not more than
        /// the expected card positions in common.
        /// </summary>
        /// <param name="expected"></param>
        [TestCase(10)]
        [TestCase(5)]
        public void EnsureShufflePosition(int expected)
        {
            Deck d = new Deck();
            Assert.That(d.GetNumberEqualCardPositions(d.ShuffleDeck()), Is.Not.GreaterThan(expected));
        }  

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

        /// <summary>
        /// This method ensures that the top position of value belongs to the king cards of every suit.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="expected"></param>
        [TestCase(48, "Ace Hearts")]
        [TestCase(49, "Ace Diamonds")]
        [TestCase(50, "Ace Clubs")]
        [TestCase(51, "Ace Spades")]
        public void EnsureAcesHigh(int index, string expected)
        {
            Assert.That(new Deck().GetAscendingCardsAceHigh().ElementAt<Card>(index).ToString(), Is.EqualTo(expected));
        }

        /// <summary>
        /// This test is to ensure that the shuffle method returns a unique shuffle for two
        /// decks initialized simultaneously.
        /// </summary>
        [Test]
        public void DoubleShuffle()
        {
            Deck deckA = new Deck();
            Deck deckB = new Deck();

            CollectionAssert.AreNotEqual(deckA.ShuffleDeck(), deckB.ShuffleDeck(), new CardComparer());
        }

        /// <summary>
        /// This is the comparer class to be used on the collection assert.
        /// </summary>
        public class CardComparer : Comparer<Card>
        {
            public override int Compare(Card cardA, Card cardB)
            {
                return cardA.ToString().CompareTo(cardB.ToString());
            }
        }

    }
}
