using Microsoft.AspNetCore.Mvc;

namespace Gaita.Hypersign.Controllers
{
    public class CredentialsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
