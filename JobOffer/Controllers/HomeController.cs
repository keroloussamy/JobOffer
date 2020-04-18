using JobOffer.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOffer.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }


        public ActionResult Apply(int JobId)
        {
            //ViewBag.JobId = JobId;

            ApplyForJob model = new ApplyForJob
            {
                JobId = JobId
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Apply(ApplyForJob applyForJob, HttpPostedFileBase cv)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/CVs"), cv.FileName);
                cv.SaveAs(path);
                applyForJob.Cv = cv.FileName;
                applyForJob.UserId = User.Identity.GetUserId();//get from el user msagel beah f el register
                applyForJob.ApplyTime = DateTime.Now;
                db.ApplyForJobs.Add(applyForJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applyForJob);
        }

        public ActionResult JobsByPublisher()
        {
            var userId = User.Identity.GetUserId();
            var jobs = from a in db.ApplyForJobs
                       join j in db.Jobs
                       on a.JobId equals j.Id
                       where j.User.Id == userId
                       select a;

            var grouped = from j in jobs
                          group j by j.Job.JobTitle
                          into gr
                          select new JobsViewModel
                          {
                              JobTitle = gr.Key,
                              Items = gr
                          };

            return View(grouped.ToList());
        }

        
        public ActionResult Search()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchinput)
        {
            var result = db.Jobs.Where(a => a.JobTitle.Contains(searchinput)
            || a.JobContent.Contains(searchinput)
            || a.Category.CategoryName.Contains(searchinput)
            || a.Category.CategoryDescription.Contains(searchinput)).ToList();
            return View(result);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}