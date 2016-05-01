using PagedList;
using RYAP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            if(Session["Jokes"] == null)
                Session["Jokes"] = db.Jokes.OrderBy(ks => Guid.NewGuid()).ToList();

            var jokes = ((List<Joke>)Session["Jokes"]).AsQueryable();

            var onePageOfJokes = jokes.ToPagedList(pageNumber, 
                int.Parse(ConfigurationManager.AppSettings["JokesPerPage"]));

            ViewBag.OnePageOfJokes = onePageOfJokes;

            return View();
        }

        public ActionResult Contribute(ContributeViewModel model)
        {
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}