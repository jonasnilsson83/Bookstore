
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using BookstoreData;
using BookstoreData.BookData;
using ServiceInterface;
using Domain.Model;

namespace BookstoreService
{
    public class BookstoreDataService : ServiceBase, IBookstoreService
    {

        public BookstoreDataService(IDataObjectFactory dataObjectFactory) : base(dataObjectFactory)
        {
        }

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = Task.Run(() => DataObjectFactory.Create<IBookDataObject>().GetAll());

            return books;
        }

        public Task<IEnumerable<IBook>> GetBooksAsync(string searchString)
        {            
            var books = Task.Run(()=> DataObjectFactory.Create<IBookDataObject>().GetAllBooks(searchString));
            
            return books;
        }        

        public Task<Book> GetBooksAsync(int bookId)
        {
            var books = Task.Run(() => DataObjectFactory.Create<IBookDataObject>().Get(bookId));

            return books;
        }

        public Task<IEnumerable<IBook>> GetRandomBooks(int nubmerOfBooks)
        {
            var books = Task.Run(() => DataObjectFactory.Create<IBookDataObject>().GetRandomBooks(nubmerOfBooks));

            return books;
        }
    }
}
