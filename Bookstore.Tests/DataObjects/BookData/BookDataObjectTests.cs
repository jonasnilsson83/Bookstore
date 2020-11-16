using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreData.BookData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Tests;
using Domain.Interface;

namespace BookstoreData.BookData.Tests
{
    [TestClass()]
    public class BookDataObjectTests : TestBase
    {
        [TestMethod()]
        public void GetAllBooksTest()
        {
            //var books = DataObjectFactory.Create<IBook>. //.GetBookDataObject().GetAllBooks();
            

            //Assert.IsTrue(books.Count() != 0);
        }

        [TestMethod()]
        public void GetAllBooksBySearchStringTest()
        {
            //var factory = DataObjectFactory.GetInstance();
            //var books = factory.GetBookDataObject().GetAllBooks("Ove");
            //Assert.IsTrue(books.Count() != 0);
        }
    }
}