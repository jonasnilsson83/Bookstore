using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
    public interface IBookstoreService
    {
        //contains methods this service must implement. could also have methods that not is shows by DO
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<IBook>> GetBooksAsync(string searchString);
        Task<Book> GetBooksAsync(int bookId);

        Task<IEnumerable<IBook>> GetRandomBooks(int nubmerOfBooks);

    }
}
