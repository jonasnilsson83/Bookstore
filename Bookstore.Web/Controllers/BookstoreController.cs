using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Web.Controllers
{
    public class BookstoreController : BaseController
    {
        
        IEnumerable<IBook> books;

        public BookstoreController()
        {
           
        }       

        

        // GET: Bookstore
        public ActionResult Index(string searchString)
        {
            GetCartFromSession();

            if (String.IsNullOrEmpty(searchString))
                books = new Book[] { }; // _facade.BookstoreService.GetBooksAsync().Result;
            else
                books = _facade.BookstoreService.GetBooksAsync(searchString).Result;

            return View(books);
        }


        //new endpoint to test Jquery from Bookstore.Index
        [HttpGet]
        public JsonResult SearchForBooks(string searchString)
        {
            
            if (String.IsNullOrEmpty(searchString))
                books = new Book[] { }; // _facade.BookstoreService.GetBooksAsync().Result;
            else
                books = _facade.BookstoreService.GetBooksAsync(searchString).Result.ToList();
            
            return Json(books,JsonRequestBehavior.AllowGet);
        }

        

        // GET: Bookstore/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }


            var book = _facade.BookstoreService.GetBooksAsync(id.Value).Result;
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        public void AddToCart(int id)
        {
            //GetCartFromSession();
            //var book = _facade.BookstoreService.GetBooksAsync(id).Result;
            ////return RedirectToAction("Index");
            //shoppingCart = _facade.ShoppingCartService.AddOrRemoveBookCartItemFromShoppingCart(shoppingCart, true, book).Result;


            //SaveCartToSession();
            //ViewBag.Info = "You added a book to your cart!";

            ////RedirectToAction("CheckOut"); //PRG pattern
            //RedirectToRoute("CheckOut");
        }

       

        //public async Task<ActionResult> ManipulateCartFromCheckOut(int id, bool add)
        //{
        //    GetCartFromSession();
        //    var book = _facade.BookstoreService.GetBooksAsync(id).Result;
        //    //return RedirectToAction("Index");
        //    shoppingCart = _facade.ShoppingCartService.AddOrRemoveBookCartItemFromShoppingCart(shoppingCart, add, book).Result;
        //    shoppingCart = await _facade.ShoppingCartService.CheckAndSplitOrderByOrderability(shoppingCart);


        //    SaveCartToSession();
            

        //    return View("CheckOut", shoppingCart);
        //}



        // GET: Bookstore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookstore/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bookstore/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bookstore/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bookstore/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bookstore/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
