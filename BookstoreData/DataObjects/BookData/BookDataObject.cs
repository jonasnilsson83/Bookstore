using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using System.Data;
using BookstoreData.DataObjects.BookData;
using Domain.Interface;

namespace BookstoreData.BookData
{
    public class BookDataObject : BaseDataObject, IBookDataObject
    {
        BookDataObjectMapper dataObjectMapper;

        public BookDataObject()
        {
            dataObjectMapper = new BookDataObjectMapper();
        }

        public IEnumerable<Book> GetAll()
        {
            var table = ExecuteSelect(BookDataObjectSQL.SELECT_ALL);
            return dataObjectMapper.MapToBookList(table);
        }

        public IEnumerable<IBook> GetAllBooks(string searchString)
        {
            var parameterValuesList = new List<SqlParamValues>
            {
                CreateParamValues(ParameterDirection.Input,  DbType.String, "searchString", string.Format("{0}{1}{0}", "%", searchString))
            };

            var table = ExecuteSelect(BookDataObjectSQL.SELECT_BY_NAME_OR_TITLE, parameterValuesList);
            return dataObjectMapper.MapToBookList(table);
        }

        public Book Get(int domainObjectId)
        {
            var parameterValuesList = new List<SqlParamValues>
            {
                CreateParamValues(ParameterDirection.Input,  DbType.Int32, "id", domainObjectId)
            };

            var table = ExecuteSelect(BookDataObjectSQL.SELECT_BY_ID, parameterValuesList);
            return dataObjectMapper.MapToBook(table);
        }


        IEnumerable<IBook> IBookDataObject.GetRandomBooks(int numberOfBooks)
        {
            List<Book> books = new List<Book>();

            var parameterValuesList = new List<SqlParamValues>
            {
                CreateParamValues(ParameterDirection.Input,  DbType.Int32, "limit", numberOfBooks)
            };

            var table = ExecuteSelect(BookDataObjectSQL.SELECT_RANDOM, parameterValuesList);

            return dataObjectMapper.MapToBookList(table);
        }

        


        public int Delete(Book domainObject)
        {
            throw new NotImplementedException();
        }

        //public Book Get(int domainObjectId)
        //{
        //    throw new NotImplementedException();
        //}

        public int Insert(Book domainObject)
        {
            throw new NotImplementedException();
        }

        public int Update(Book domainObject)
        {
            throw new NotImplementedException();
        }

        public void SetDatabase(Database database)
        {
            throw new NotImplementedException();
        }

        public int Create(Book domainObject)
        {
            throw new NotImplementedException();
        }

        public int Delete(int domainObjectId)
        {
            throw new NotImplementedException();
        }

        
    }
}

