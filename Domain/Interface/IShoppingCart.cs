using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IShoppingCart
    {
        int Id { get; }
        List<IBookCartItem> BooksInCart { get; set; }

        decimal TotalSum { get; }

        int TotalQuantity { get; }
    }
}
