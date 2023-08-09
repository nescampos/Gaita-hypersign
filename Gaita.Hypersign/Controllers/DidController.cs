using Microsoft.AspNetCore.Mvc;

namespace Gaita.Hypersign.Controllers
{
    public class DidController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
