using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using PagedList;
using RYAP.Website.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace RYAP.Website.Controllers
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
            if (ModelState.IsValid)
            {
                var storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.AppSettings["StorageConnString"]);

                var queueClient = storageAccount.CreateCloudQueueClient();

                var queue = queueClient.GetQueueReference("contributions");

                queue.CreateIfNotExists();

                var json = JsonConvert.SerializeObject(model);

                var message = new CloudQueueMessage(json);

                queue.AddMessage(message);

                model.Question = null;
                model.Answer = null;

                return View(model);
            }
            else
            {
                return View(new ContributeViewModel());
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}