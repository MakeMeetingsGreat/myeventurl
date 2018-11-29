using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using MyEventURL.Models;

namespace MyEventURL.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using MyEventURL.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<EngagementInfo>("EngagementInfo");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EngagementInfoController : ODataController
    {
        private MyEventURLContext db = new MyEventURLContext();

        // GET: odata/EngagementInfo
        [EnableQuery]
        public IQueryable<EngagementInfo> GetEngagementInfo()
        {
            return db.EngagementInfoes;
        }

        // GET: odata/EngagementInfo(5)
        [EnableQuery]
        public SingleResult<EngagementInfo> GetEngagementInfo([FromODataUri] int key)
        {
            return SingleResult.Create(db.EngagementInfoes.Where(engagementInfo => engagementInfo.EngagementInfoID == key));
        }

        // PUT: odata/EngagementInfo(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<EngagementInfo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EngagementInfo engagementInfo = db.EngagementInfoes.Find(key);
            if (engagementInfo == null)
            {
                return NotFound();
            }

            patch.Put(engagementInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngagementInfoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(engagementInfo);
        }

        // POST: odata/EngagementInfo
        public IHttpActionResult Post(EngagementInfo engagementInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EngagementInfoes.Add(engagementInfo);
            db.SaveChanges();

            return Created(engagementInfo);
        }

        // PATCH: odata/EngagementInfo(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<EngagementInfo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EngagementInfo engagementInfo = db.EngagementInfoes.Find(key);
            if (engagementInfo == null)
            {
                return NotFound();
            }

            patch.Patch(engagementInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngagementInfoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(engagementInfo);
        }

        // DELETE: odata/EngagementInfo(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            EngagementInfo engagementInfo = db.EngagementInfoes.Find(key);
            if (engagementInfo == null)
            {
                return NotFound();
            }

            db.EngagementInfoes.Remove(engagementInfo);
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

        private bool EngagementInfoExists(int key)
        {
            return db.EngagementInfoes.Count(e => e.EngagementInfoID == key) > 0;
        }
    }
}
