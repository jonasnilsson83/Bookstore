using Bookstore.Web.Models;
using System.Web.Mvc;

namespace Bookstore.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var topList = _facade.BookstoreService.GetRandomBooks(5).Result;

            HomeViewModel viewModel = new HomeViewModel()
            {
                InfoText = "This is a Bookstore project, based on MVC",
                TopList = topList
            };

            return View(viewModel);
    }

    public ActionResult About()
    {
        ViewBag.Message = "Application description page.";

        return View();
    }

    public ActionResult Contact()
    {


        return View();
    }
}
}