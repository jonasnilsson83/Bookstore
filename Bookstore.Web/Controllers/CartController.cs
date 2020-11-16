using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Web.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
            GetCartFromSession();
            return View("Edit", shoppingCart);
        }

       
        // POST: Cart/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                GetCartFromSession();
                //return RedirectToAction("Index");
                shoppingCart = _facade.ShoppingCartService.AddOrRemoveShoppingCart(shoppingCart, true, id).Result;


                SaveCartToSession();
                ViewBag.Info = "You added a book to your cart!";

                //RedirectToAction("CheckOut"); //PRG pattern
                //RedirectToRoute("CheckOut");


                return RedirectToAction("CheckOut");
            }
            catch
            {
                return View();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddOne(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                GetCartFromSession();

                shoppingCart = _facade.ShoppingCartService.AddOrRemoveShoppingCart(shoppingCart, true, id).Result;


                SaveCartToSession();
                ViewBag.Info = "You added a book to your cart!";

                //RedirectToAction("CheckOut"); //PRG pattern
                //RedirectToRoute("CheckOut");


                return RedirectToAction("CheckOut");
            }
            catch
            {
                return View();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RemoveOne(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                GetCartFromSession();

                shoppingCart = _facade.ShoppingCartService.AddOrRemoveShoppingCart(shoppingCart, true, id).Result;


                SaveCartToSession();
                ViewBag.Info = "You added a book to your cart!";

                //RedirectToAction("CheckOut"); //PRG pattern
                //RedirectToRoute("CheckOut");


                return RedirectToAction("CheckOut");
            }
            catch
            {
                return View();
            }
        }

        void SaveCartToSession()
        {
            Session["cart"] = shoppingCart;
            Session["nbrOfCartItems"] = shoppingCart?.BooksInCart?.Count;
        }

        public async Task<ActionResult> ManipulateCartFromCheckOut(int id, bool add)
        {
            GetCartFromSession();

            shoppingCart = _facade.ShoppingCartService.AddOrRemoveShoppingCart(shoppingCart, add, id).Result;
            shoppingCart = await _facade.ShoppingCartService.CheckAndSplitOrderByOrderability(shoppingCart);


            SaveCartToSession();

            return RedirectToAction("CheckOut");
            //return View("CheckOut", shoppingCart);
        }

        public async Task<ActionResult> CheckOut()
        {
            
            GetCartFromSession();
            shoppingCart = await _facade.ShoppingCartService.CheckAndSplitOrderByOrderability(shoppingCart);

            return View(shoppingCart);
        }
    }
}
