using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Interface;

namespace BookstoreService.Tests
{
    [TestClass()]
    public class CommunicatorTests
    {
        //Communicator communicator;
        //[TestInitialize]
        //public void Initialize()
        //{
        //    communicator = new Communicator();
        //}

        //[TestMethod()]
        //public void GetBooksTest()
        //{
        //    PrivateObject obj = new PrivateObject(communicator);
        //    var jsonString = obj.Invoke("GetJsonFromExternalSource").ToString();
        //    Assert.IsTrue(string.IsNullOrEmpty(jsonString) == false);
        //}

        //[TestMethod()]
        //public void DeserializeJsonTest()
        //{
        //    PrivateObject obj = new PrivateObject(communicator);
        //    var books = (IEnumerable<Book>)obj.Invoke("DeserializeJson");

        //    Assert.IsTrue(books.Count() == 7);
        //}

        //[TestMethod()]
        //public async Task GetBooksFromExternalSourceTest()
        //{
        //    var books = await communicator.GetBooksAsync("Mastering");

        //    Assert.IsTrue(books.Count() == 1);
        //}

        //[TestMethod()]
        //public async Task GetAllBooksAsyncTest()
        //{
        //    var response = await communicator.GetAllBooksAsync();

        //    Assert.IsTrue(response.Count() == 7);
        //}

        //[TestMethod()]
        //public async Task GetBooksAsyncByIdTest()
        //{
        //    var id = 5;
        //    var response = await communicator.GetBooksAsyncById(id);

        //    Assert.IsTrue(response != null);
        //}
    }
}