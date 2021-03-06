﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyEventURL;
using MyEventURL.Models;
using System.Web.Http.Cors;

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

        // GET: Events/Create
        [Authorize]
        [RemoveXFrameOptions]
        public ActionResult Create(int? id)
        {
            this.getUser();
            if (id == null)
            {
                return View();                
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Start,End,Timezone,Title,Description,Location,Organizer,Email,Reminder,sway,NoReply,Forms,Style,Private,Icon,search,Views,Engaged,Board")] Event @event)
        {           
            if (ModelState.IsValid)
            {
                int boardid = (Request.Form["Board"] != "") ? Convert.ToInt32(Request.Form["Board"]) : 0;
                db.Events.Add(@event);
                db.SaveChanges();
                if (boardid > 0)
                {
                    var addboard = db.Boards.Where(b => b.BoardID == boardid).First();
                    addboard.Events += ";" + @event.EventId;
                    db.Entry(addboard).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                return View("Close");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        [Authorize]
        [RemoveXFrameOptions]
        public ActionResult Edit(int? id)
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

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Start,End,Timezone,Title,Description,Location,Organizer,Email,Reminder,sway,NoReply,Forms,Created,Style,Private,Icon,search,Views,Engaged")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return View("Close");
            }
            return View(@event);
        }


        // GET: Events/Delete/5
        [Authorize]
        [RemoveXFrameOptions]
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
            return View("Close");
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
