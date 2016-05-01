using PagedList;
using RYAP.Models;
using System.Linq;
using System.Web.Mvc;

namespace RYAP.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        public object Index(int? page)
        {
            var pageNumber = page ?? 1;

            var jokes = db.Jokes.OrderBy(ks => ks.AddedOn);

            var onePageOfJokes = jokes.ToPagedList(pageNumber, 10);

            ViewBag.OnePageOfJokes = onePageOfJokes;

            return View();
        }

        public ActionResult Contribute()
        {
            ViewBag.Message = "Your contribution page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";

            return View();
        }
    }
}