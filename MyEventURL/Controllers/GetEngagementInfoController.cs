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
    using MyEventURL.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<EngagementInfo>("GetEngagementInfo");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class GetEngagementInfoController : ODataController
    {
        private MyEventURLContext db = new MyEventURLContext();

        // GET: odata/GetEngagementInfo
        [EnableQuery]
        public IQueryable<EngagementInfo> GetGetEngagementInfo()
        {
            return db.EngagementInfo;
        }

        // GET: odata/GetEngagementInfo(5)
        [EnableQuery]
        public SingleResult<EngagementInfo> GetEngagementInfo([FromODataUri] int key)
        {
            return SingleResult.Create(db.EngagementInfo.Where(engagementInfo => engagementInfo.EngagementInfoID == key));
        }

        // PUT: odata/GetEngagementInfo(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<EngagementInfo> patch)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EngagementInfo engagementInfo = db.EngagementInfo.Find(key);
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

        // POST: odata/GetEngagementInfo
        public IHttpActionResult Post(EngagementInfo engagementInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EngagementInfo.Add(engagementInfo);
            db.SaveChanges();

            return Created(engagementInfo);
        }

        // PATCH: odata/GetEngagementInfo(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<EngagementInfo> patch)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EngagementInfo engagementInfo = db.EngagementInfo.Find(key);
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

        // DELETE: odata/GetEngagementInfo(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            EngagementInfo engagementInfo = db.EngagementInfo.Find(key);
            if (engagementInfo == null)
            {
                return NotFound();
            }

            db.EngagementInfo.Remove(engagementInfo);
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
            return db.EngagementInfo.Count(e => e.EngagementInfoID == key) > 0;
        }
    }
}
