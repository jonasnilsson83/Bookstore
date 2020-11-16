using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookstoreWeb
{
    public partial class CheckOut : System.Web.UI.Page
    {
        IShoppingCart shoppingCart;
        private decimal sumFooterValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
                shoppingCart = (IShoppingCart)Session["cart"];
           

            CheckAndSplitByOrderability();

            //reset cart
            Session["cart"] = null;
        }

        private async void CheckAndSplitByOrderability()
        {
            var shoppingCart  = await Task.Run(() => Global._facade.ShoppingCartService.CheckAndSplitOrderByOrderability(this.shoppingCart));

            dgvCart.DataSource = shoppingCart.BooksInCart.Where(it => it.CanBeOrdered && it.Quantity > 0);
            dgvCart.DataBind();

            if (shoppingCart.BooksInCart.Where(it => it.CanBeOrdered == false).Any())
            {
                dgvNotInStock.DataSource = shoppingCart.BooksInCart.Where(it => it.CanBeOrdered == false);
                dgvNotInStock.DataBind();
            }
            else
                hrError.Visible = false;          
        }

        protected void dgvCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BookCartItem item = (BookCartItem)e.Row.DataItem;
                sumFooterValue += item.Quantity * item.Book.Price;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lblTotal");
                lbl.Text = sumFooterValue.ToString();
            }
        }
    }
}