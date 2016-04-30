using System.Web.Mvc;

namespace RYAP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contribute()
        {
            ViewBag.Message = "Your contribution page.";

            return View();
        }
    }
}