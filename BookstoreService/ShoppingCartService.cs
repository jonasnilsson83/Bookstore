using BookstoreData;
using Domain.Enums;
using Domain.Interface;
using Domain.Model;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreService
{
    public class ShoppingCartService : ServiceBase, IShoppingCartService
    {
        IBookstoreService _bookstoreService;

        public ShoppingCartService(IDataObjectFactory dataObjectFactory, IBookstoreService bookstoreService) : base(dataObjectFactory)
        {
            _bookstoreService = bookstoreService;
        }

        public async Task<IShoppingCart> CheckAndSplitOrderByOrderability(IShoppingCart shoppingCart)
        {
            var allBooks = _bookstoreService.GetBooksAsync().Result.Where(it => shoppingCart.BooksInCart.Any(b => b.Book.InternalId == it.InternalId) );
            IShoppingCart shadow = new ShoppingCart();

            foreach (var item in shoppingCart.BooksInCart)
            {
                IBook bookToCheck = allBooks.Single(it => it.InternalId == item.Book.InternalId);
                if (bookToCheck.InStock < item.Quantity)
                {
                    if(bookToCheck.InStock == 0)
                        shadow.BooksInCart.Add(MakeBookCartItem(0, item.Book, OrderAblility.None, item.DateCreated, Math.Abs(bookToCheck.InStock - item.Quantity)));

                    //add max in stock
                    if (bookToCheck.InStock > 0)
                        shadow.BooksInCart.Add(MakeBookCartItem(bookToCheck.InStock, item.Book, OrderAblility.Partial, item.DateCreated, Math.Abs(bookToCheck.InStock - item.Quantity)));
                }
                else
                {
                    shadow.BooksInCart.Add(MakeBookCartItem( item));
                }
            }

            return shadow;
        }

        public async Task<IShoppingCart> AddOrRemoveShoppingCart(IShoppingCart shoppingCart, bool increaseQuantity, int bookId)
        {
            // ChangeAmount
            var book = _bookstoreService.GetBooksAsync(bookId).Result;

            bool isBookInCart = false;

            for (int i = 0; i < shoppingCart.BooksInCart.Count; i++)
            {
                if (shoppingCart.BooksInCart[i].Book.InternalId == bookId)
                {
                    isBookInCart = true;
                    if (increaseQuantity)
                        shoppingCart.BooksInCart[i].Quantity++;
                    else
                    {
                        if (shoppingCart.BooksInCart[i].Quantity >= 1)
                            shoppingCart.BooksInCart[i].Quantity--;
                    }
                }
            }

            //add to cart
            if (isBookInCart == false)
            {
                shoppingCart.BooksInCart.Add(MakeBookCartItem(1, book, OrderAblility.Unknown, DateTime.Now));
            }

            //remove zeros
            shoppingCart.BooksInCart = shoppingCart.BooksInCart.Where(it => it.Quantity > 0).ToList();

            //shoppingCart = await CheckAndSplitOrderByOrderability(shoppingCart);


            //TODO somthing smells here!
            shoppingCart =   CheckAndSplitOrderByOrderability(shoppingCart).Result;

            return shoppingCart;
        }

        BookCartItem MakeBookCartItem(int quantity, IBook book, OrderAblility orderAblility, DateTime creationTime, int quantityOutOfOrder = 0)
        {
            return new BookCartItem()
            {
                Quantity = quantity,
                Book = book,
                OrderAblility = orderAblility,
                DateCreated = creationTime,
                QuantityOutOfOrder = quantityOutOfOrder
            };
        }
        BookCartItem MakeBookCartItem(IBookCartItem bookCartItem)
        {
            return new BookCartItem()
            {
                Quantity = bookCartItem.Quantity,
                Book = bookCartItem.Book,
                OrderAblility = OrderAblility.Full,
                DateCreated = DateTime.Now,
                QuantityOutOfOrder = bookCartItem.QuantityOutOfOrder
            };
        }

    }
}
