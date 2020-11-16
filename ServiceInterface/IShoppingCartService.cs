using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
    public interface IShoppingCartService
    {
        Task<IShoppingCart> CheckAndSplitOrderByOrderability(IShoppingCart shoppingCart);
        Task<IShoppingCart> AddOrRemoveShoppingCart(IShoppingCart shoppingCart, bool increaseQuantity, int bookId);

    }
}
