using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<IBook>  TopList { get; set; }
        public string InfoText { get; set; }


    }
}