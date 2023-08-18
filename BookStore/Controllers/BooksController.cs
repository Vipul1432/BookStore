using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
