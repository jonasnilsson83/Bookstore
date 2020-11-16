using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData.DataObjects.BookData
{
    public class BookDataObjectMapper : BaseDataMapper
    {
        private Book MapToBook(DataRow row)
        {

            var book = new Book
            {
                InternalId = GetInt(row, "BookId"),
                Author = string.Format("{0} {1}", GetString(row, "FirstName")  , GetString(row, "LastName")),
                InStock = GetInt(row, "Amount"),
                Price = GetDecimal(row, "Price"),
                Title = GetString(row,"Title"),
                Format =  new BookFormat() { Format = GetString(row, "FormatType") }
            };

            return book;
        }
        
        public Book MapToBook(DataTable table)
        {
            if (table == null || table.Rows.Count != 1)
            {
                return null;
            }

            DataRow row = table.Rows[0];
            return MapToBook(row);

        }

        public IEnumerable<Book> MapToBookList(DataTable table)
        {
            return (from DataRow row in table.Rows select MapToBook(row));
        }

    }
}
