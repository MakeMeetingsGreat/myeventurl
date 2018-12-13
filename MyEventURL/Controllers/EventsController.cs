using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyEventURL;
using MyEventURL.Models;

namespace MyEventURL.Controllers
{
    public class EventsController : Controller
    {
        private MyEventURLContext db = new MyEventURLContext();

        // GET: Events
        public ActionResult Index()
        {
            this.getUser();
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            this.getUser();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }


        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            this.getUser();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.getUser();
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void getUser()
        {
            string[] emailarray = null;
            ViewBag.Email = User.Identity.Name;
            if (ViewBag.Email != "")
            {
                if (ViewBag.Email.Contains("#"))
                {
                    emailarray = ViewBag.Email.Split('#');
                    ViewBag.Email = emailarray[emailarray.Length - 1];
                }
                emailarray = ViewBag.Email.Split('@');
                ViewBag.UserName = emailarray[0];
                ViewBag.Domain = emailarray[1];
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
