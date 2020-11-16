using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData.BookData
{
    public interface IBookDataObject : IDataObject<Book>
    {
        //contains methods attached to this dataobject
        IEnumerable<IBook> GetAllBooks(string searchString);

        IEnumerable<IBook> GetRandomBooks(int numberOfBooks);

    }
}
