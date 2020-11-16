using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Book : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }

        public int InternalId { get; set; }
    
        public BookFormat Format { get; set; }
    }

    public class BookCollection
    {
        public IEnumerable<Book> Books { get; set; }

    }
}
