using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.Web.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart cartToUse)
        {
            this.ShoppingCart = cartToUse;
        }

        public IShoppingCart ShoppingCart { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}