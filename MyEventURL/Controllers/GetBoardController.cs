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
    builder.EntitySet<Board>("GetBoard");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class GetBoardController : ODataController
    {
        private MyEventURLContext db = new MyEventURLContext();

        // GET: odata/GetBoard
        [EnableQuery]
        public IQueryable<Board> GetGetBoard()
        {
            return db.Boards;
        }

        // GET: odata/GetBoard(5)
        [EnableQuery]
        public SingleResult<Board> GetBoard([FromODataUri] int key)
        {
            return SingleResult.Create(db.Boards.Where(board => board.BoardID == key));
        }

        // PUT: odata/GetBoard(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Board> patch)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Board board = db.Boards.Find(key);
            if (board == null)
            {
                return NotFound();
            }

            patch.Put(board);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(board);
        }

        // POST: odata/GetBoard
        public IHttpActionResult Post(Board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Boards.Add(board);
            db.SaveChanges();

            return Created(board);
        }

        // PATCH: odata/GetBoard(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Board> patch)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Board board = db.Boards.Find(key);
            if (board == null)
            {
                return NotFound();
            }

            patch.Patch(board);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(board);
        }

        // DELETE: odata/GetBoard(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Board board = db.Boards.Find(key);
            if (board == null)
            {
                return NotFound();
            }

            db.Boards.Remove(board);
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

        private bool BoardExists(int key)
        {
            return db.Boards.Count(e => e.BoardID == key) > 0;
        }
    }
}
