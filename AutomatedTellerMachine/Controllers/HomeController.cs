using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET /home/index
        //this mapping of request-to-action method is called routing
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            return View();
        }

        // GET /home/about
        //[ActionName("about-this-atm")] //alternate name for invoking this method
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About"); //when we use ActionName, we need to explicitly say that it should look for About view
        }

        //GET /home/contact
        [Route("home/contact")]
        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having trouble? Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message) //matches the name of the textarea in the form
        {
            //TODO: send message to HQ
            ViewBag.TheMessage = "Thanks, we got your message.";

            return View();

        }

        //used as an alias for About
        public ActionResult Foo() {
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }

            return Content(serial);
            //return new HttpStatusCodeResult(403)
            //return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }

    }
}