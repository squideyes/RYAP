using RYAP.Models;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace RYAP.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        public object Index(int? page)
        {
            var pageNumber = page ?? 1;

            var jokes = db.Jokes.OrderBy(j => j.AddedOn);

            var onePageOfJokes = jokes.ToPagedList(pageNumber, 10);

            ViewBag.OnePageOfJokes = onePageOfJokes;

            return View();
        }

        public ActionResult Contribute()
        {
            ViewBag.Message = "Your contribution page.";

            return View();
        }
    }
}