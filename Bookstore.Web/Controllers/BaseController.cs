using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationFacadeService.ApplicationFacadeService _facade;
        protected IShoppingCart shoppingCart;
        public BaseController()
        {
            _facade = new ApplicationFacadeService.ApplicationFacadeService();
        }

       internal void GetCartFromSession()
        {
            if (Session["cart"] != null)
                shoppingCart = (IShoppingCart)Session["cart"];
            else
                shoppingCart = new ShoppingCart();
        }
    }
}