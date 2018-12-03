using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyEventURL.Models;

namespace MyEventURL.Controllers
{
    public class EngagementInfoAPIController : ApiController
    {
        private MyEventURLContext db = new MyEventURLContext();

        // GET: api/EngagementInfoAPI
        public IQueryable<EngagementInfo> GetEngagementInfo()
        {
            return db.EngagementInfo;
        }

        // GET: api/EngagementInfoAPI/5
        [ResponseType(typeof(EngagementInfo))]
        public IHttpActionResult GetEngagementInfo(int id)
        {
            EngagementInfo engagementInfo = db.EngagementInfo.Find(id);
            if (engagementInfo == null)
            {
                return NotFound();
            }

            return Ok(engagementInfo);
        }

        // PUT: api/EngagementInfoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEngagementInfo(int id, EngagementInfo engagementInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != engagementInfo.EngagementInfoID)
            {
                return BadRequest();
            }

            db.Entry(engagementInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngagementInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EngagementInfoAPI
        [ResponseType(typeof(EngagementInfo))]
        public IHttpActionResult PostEngagementInfo(EngagementInfo engagementInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EngagementInfo.Add(engagementInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = engagementInfo.EngagementInfoID }, engagementInfo);
        }

        // DELETE: api/EngagementInfoAPI/5
        [ResponseType(typeof(EngagementInfo))]
        public IHttpActionResult DeleteEngagementInfo(int id)
        {
            EngagementInfo engagementInfo = db.EngagementInfo.Find(id);
            if (engagementInfo == null)
            {
                return NotFound();
            }

            db.EngagementInfo.Remove(engagementInfo);
            db.SaveChanges();

            return Ok(engagementInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EngagementInfoExists(int id)
        {
            return db.EngagementInfo.Count(e => e.EngagementInfoID == id) > 0;
        }
    }
}