using Microsoft.AspNetCore.Mvc;

namespace GiftApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
