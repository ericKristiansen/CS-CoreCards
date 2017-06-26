
using CoreCards.Models;
using CoreCards.Utl;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace CoreCards.Controllers
{
    /// <summary>
    /// Provide a controller for the application.
    /// </summary>
    public class HomeController : Controller
    {
        private static Deck deck = new Deck();

        /// <summary>
        /// Return the default view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Return the view of cards layed out in the appropriate order.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public IActionResult ShuffleDeck(string method)
        {
            ViewData[Constants.MESSAGE] = Constants.YOUR_CARDS;

            return View(GetOrderedCards(method));
        }

        /// <summary>
        /// Provide an error view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// Assign the cards of appropriate order to the appropriate key in the 'ViewData' object.
        /// </summary>
        /// <param name="method"></param>
        private IOrderedEnumerable<Card> GetOrderedCards(string method)
        {
            IOrderedEnumerable<Card> cards = Enumerable.Empty<Card>().OrderBy(x => 1);

            if (method == Constants.SHUFFLE)
            {
                cards = deck.ShuffleDeck();
            }
            else if (method == Constants.KING_HIGH){ cards = deck.GetAscendingCardsKingHigh(); }
            else { cards = deck.GetAscendingCardsAceHigh(); }

            return cards;
        }
    }
}
