﻿
using CoreCards.Models;
using CoreCards.Utl;
using Microsoft.AspNetCore.Mvc;

namespace CoreCards.Controllers
{
    /// <summary>
    /// Provide a controller for the application.
    /// </summary>
    public class HomeController : Controller
    {
        private Deck deck;

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
            deck = new Deck();
            assignCards(method);

            return View();
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
        private void assignCards(string method)
        {
            if (method == Constants.SHUFFLE)
            {
                ViewData[Constants.CARDS] = deck.ShuffleDeck();
            }
            else if (method == Constants.KING_HIGH){ ViewData[Constants.CARDS] = deck.GetAscendingCardsKingHigh(); }
            else { ViewData[Constants.CARDS] = deck.GetAscendingCardsAceHigh(); }
        }
    }
}
