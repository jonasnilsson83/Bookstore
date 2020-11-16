using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BookstoreWeb
{
    public partial class _Default : Page
    {
        IShoppingCart shoppingCart;
        decimal sumFooterValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["cart"] != null)
                shoppingCart = (IShoppingCart)Session["cart"];
            else
                shoppingCart = new ShoppingCart();


            if (Request["Id"] != null && Request["Increase"] != null && IsPostBack == false)
            {
                //bool increaseQuantity;
                //int id;

                //bool.TryParse(Request["Increase"], out increaseQuantity);
                //int.TryParse(Request["Id"].ToString(), out id);

                //shoppingCart = await AddOrRemoveFromCart(id, increaseQuantity);

                //Debug.WriteLine("Redireting: " + DateTime.Now);
                //Response.Redirect(Request.Url.AbsolutePath);
                //Debug.WriteLine("Redirecting done: " + DateTime.Now);
            }
            else
            {
                //dgvCart.DataSource = shoppingCart.BooksInCart;
                //dgvCart.DataBind();
                Session["cart"] = shoppingCart;
            }

        }

        private async Task<IShoppingCart> AddOrRemoveFromCart(int bookId, bool increaseQuantity)
        {
            var book = Global._facade.BookstoreService.GetBooksAsync(bookId).Result;

            var q = await Global._facade.ShoppingCartService.AddOrRemoveBookCartItemFromShoppingCart(shoppingCart, increaseQuantity, book);

            Debug.WriteLine("AddOrRemoveCat done: " + DateTime.Now);
            return q;
        }

        protected async void btnSearch_Click(object sender, EventArgs e)
        {
            var searchResult = await Global._facade.BookstoreService.GetBooksAsync(txtSeachBox.Text);

            // Display the result.
            dgvSearchResult.DataSource = searchResult;
            dgvSearchResult.DataBind();
        }

        protected void dgvCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BookCartItem item = (BookCartItem)e.Row.DataItem;

                Label lbl = (Label)e.Row.FindControl("lblQuantity");
                if (lbl != null)
                    lbl.Text = item.Quantity.ToString();
                sumFooterValue += item.Quantity * item.Book.Price;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lblTotal");
                lbl.Text = sumFooterValue.ToString();
            }
        }

        protected void dgvSearchResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IncreaseBookInCart")
            {
                shoppingCart = Task.Run(() => AddOrRemoveFromCart(int.Parse(e.CommandArgument.ToString()), true)).Result;
                Session["cart"] = shoppingCart;

                BindDataToDgv(dgvCart, shoppingCart.BooksInCart);
                BindDataToDgv(dgvSearchResult, null);
            }
        }

        protected void dgvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IncreaseBookInCart")
            {
                shoppingCart = Task.Run(() => AddOrRemoveFromCart(int.Parse(e.CommandArgument.ToString()), true)).Result;
                Session["cart"] = shoppingCart;

                BindDataToDgv(dgvCart, shoppingCart.BooksInCart);
            }
            else if (e.CommandName == "DecreaseBookInCart")
            {
                shoppingCart = Task.Run(() => AddOrRemoveFromCart(int.Parse(e.CommandArgument.ToString()), false)).Result;
                Session["cart"] = shoppingCart;

                BindDataToDgv(dgvCart, shoppingCart.BooksInCart);
            }
        }

        void BindDataToDgv(GridView gv, object dataToBind)
        {
            gv.DataSource = dataToBind;
            gv.DataBind();
        }
    }
}