using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Interface;

namespace Bookstore.Tests
{
    [TestClass]
    public class BookstoreServiceTests : TestBase
    {
        ShoppingCart shoppingCartToTest;
        //[TestInitialize]
        //public void Initialize()
        //{
        //    service = new BookstoreService.BookstoreJsonService();
        //    shoppingCartService = new BookstoreService.ShoppingCartService();
        //    shoppingCartToTest = new ShoppingCart();
        //    var books =  Task.Run(() =>  service.GetAllBooksAsync()).Result;
        //    var bookCartItem1 = new BookCartItem() { Book = (Book)books.First(), DateCreated = DateTime.Now, Quantity = 10 };
        //    var bookCartItem2 = new BookCartItem() { Book = (Book)books.Skip(1).First(), DateCreated = DateTime.Now, Quantity = 2 };
        //    shoppingCartToTest.BooksInCart.Add(bookCartItem1);
        //    shoppingCartToTest.BooksInCart.Add(bookCartItem2);
        //}

        //[TestInitialize]
        //public new void Initialize()
        //{
        //    //_applicationFacadeService = new ApplicationFacadeService.ApplicationFacadeService();

        //    var books = Task.Run(() => service.GetAllBooksAsync()).Result;
        //    var bookCartItem1 = new BookCartItem() { Book = (Book)books.First(), DateCreated = DateTime.Now, Quantity = 10 };
        //    var bookCartItem2 = new BookCartItem() { Book = (Book)books.Skip(1).First(), DateCreated = DateTime.Now, Quantity = 2 };
        //    shoppingCartToTest.BooksInCart.Add(bookCartItem1);
        //    shoppingCartToTest.BooksInCart.Add(bookCartItem2);
        //}

        //[TestMethod]
        //public async Task GetBooksAsyncTest()
        //{
        //    var searchString = "Rich";
        //    var response = await service.GetBooksAsync(searchString);

        //    Assert.IsTrue(response.Count() == 2);
        //}

        //[TestMethod]
        //public async Task GetBooksAsyncTest2()
        //{
        //    var searchString = "";
        //    var response = await service.GetBooksAsync(searchString);

        //    Assert.IsNull(response);
        //}

        //[TestMethod]
        //public async Task GetBooksAsyncByIdTest()
        //{
        //    var id = 3;
        //    var response = await service.GetBooksAsync(id);

        //    Assert.IsTrue(response.Title == "Generic Title");
        //}

        //[TestMethod]
        //public async Task GetBooksAsyncByIdTest2()
        //{
        //    var id = 4;
        //    var response = await service.GetBooksAsync(id);

        //    Assert.IsTrue(response.Title == "How To Spend Money");
        //}
        //[TestMethod]
        //public async Task CheckQuantityVsStock()
        //{
        //    var response = await shoppingCartService.CheckQuantityVsStock(shoppingCartToTest);
        //    //should split bookCartItem2 into two pieces
        //    Assert.IsTrue(response.BooksInCart.Count == 3);
        //}

    }
}
