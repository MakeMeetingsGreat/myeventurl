using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Batch;
using Microsoft.OData.Edm;
using MyEventURL.Models;

namespace MyEventURL.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using MyEventURL;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Event>("GetEvent");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class GetEventController : ODataController
    {
        private MyEventURLContext db = new MyEventURLContext();

        // GET: odata/GetEvent
        [EnableQuery]
        public IQueryable<Event> GetGetEvent(bool past = true)
        {
            if (past) return db.Events;
            else return db.Events.Where(e => e.Start > DateTime.Now);
        }

        // GET: odata/GetEvent(5)
        [EnableQuery]
        public SingleResult<Event> GetEvent([FromODataUri] int key)
        {
            return SingleResult.Create(db.Events.Where(@event => @event.EventId == key));
        }

        // PUT: odata/GetEvent(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Event> patch)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Event @event = db.Events.Find(key);
            if (@event == null)
            {
                return NotFound();
            }

            patch.Put(@event);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(@event);
        }

        // POST: odata/GetEvent
        public IHttpActionResult Post(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(@event);
            db.SaveChanges();

            return Created(@event);
        }

        // PATCH: odata/GetEvent(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Event> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Event @event = db.Events.Find(key);
            if (@event == null)
            {
                return NotFound();
            }

            patch.Patch(@event);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(@event);
        }

        // DELETE: odata/GetEvent(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Event @event = db.Events.Find(key);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int key)
        {
            return db.Events.Count(e => e.EventId == key) > 0;
        }
    }
}
