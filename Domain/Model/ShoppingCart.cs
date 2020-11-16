using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
    public class ShoppingCart : IShoppingCart
    {
        int _id;
        public ShoppingCart()
        {
            _id = new Random().Next();
            this.BooksInCart = new List<IBookCartItem>();
        }

        public int Id { get { return _id; } }
        public List<IBookCartItem> BooksInCart { get; set; }

        public decimal TotalSum
        {
            get
            {
                return this.BooksInCart == null || this.BooksInCart.Count == 0 ? 0 : this.BooksInCart.Where(it => it.OrderAblility == Enums.OrderAblility.Full).Sum(s => s.Quantity * s.Book.Price);
            }
        }

        public int TotalQuantity
        {
            get
            {
                return this.BooksInCart == null || this.BooksInCart.Count == 0 ? 0 : this.BooksInCart.Where(it => it.OrderAblility == Enums.OrderAblility.Full).Sum(s => s.Quantity );
            }
        }
    }
}
