using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public interface IBook
    {
        string Title { get; }
        string Author { get; }
        decimal Price { get; }
        int InStock { get; }
        int InternalId { get; set; }

        BookFormat Format { get; set; }
    }
}
