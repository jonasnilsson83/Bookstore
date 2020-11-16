using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBookCartItem
    {
        int Quantity { get; set; }

        System.DateTime DateCreated { get; set; }

        IBook Book { get; set; }
        
        int QuantityOutOfOrder { get; set; }

        OrderAblility OrderAblility { get; set; }
    }
}
