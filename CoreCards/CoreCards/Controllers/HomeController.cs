
using CoreCards.Models;
using CoreCards.Controllers;
using CoreCards.Utl;
using Microsoft.AspNetCore.Mvc;

namespace CoreCards.Controllers
{
    public class HomeController : Controller
    {
        Deck deck;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShuffleDeck(string method)
        {
            ViewData[Utl.Constants.MESSAGE] = Utl.Constants.YOUR_CARDS;
            deck = new Deck();
            getCards(method);

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private void getCards(string method)
        {
            if (method == Utl.Constants.SHUFFLE) { ViewData[Utl.Constants.CARDS] = deck.ShuffleDeck(); }
            else { ViewData[Utl.Constants.CARDS] = deck.GetAscendingCardsKingHigh(); }
        }
    }
}
