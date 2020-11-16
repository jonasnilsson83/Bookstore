using Domain.Enums;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class BookCartItem : IBookCartItem
    {
        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public IBook Book { get; set; }
        
        public int IdForPresentation { get { return Book.InternalId; } }

        public int QuantityOutOfOrder { get; set; }
        public OrderAblility OrderAblility { get; set; }
    }
}
