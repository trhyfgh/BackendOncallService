using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BackendOncallService.Models;

namespace BackendOncallService.Controllers
{
    public class OncallCellsController : ApiController
    {
        private BackendOncallServiceContext db = new BackendOncallServiceContext();

        // GET: api/OncallCells
        public IQueryable<OncallCellDTO> GetOncallCells()
        {
            var oncallCells = from oc in db.OncallCells
                             select new OncallCellDTO()
                             {
                                 Id = oc.Id,
                                 OncallName = oc.OncallName,
                                 OncallShift = oc.OncallShift,
                                 OncallDate = oc.OncallDate
                             };
            return oncallCells;
            //return db.OncallCells;
        }

        // GET: api/OncallCells/5
        [ResponseType(typeof(OncallCellDetailDTO))]
        public async Task<IHttpActionResult> GetOncallCell(int id)
        {
            var oncallCell = await db.OncallCells.Select (oc =>
                new OncallCellDetailDTO()
                {
                    Id = oc.Id,
                    OncallName=oc.OncallName,  
                    OncallDate = oc.OncallDate,
                    OncallShift= oc.OncallShift
                }).SingleOrDefaultAsync(oc=>oc.Id==id);
                
           // OncallCell oncallCell = await db.OncallCells.FindAsync(id);
            if (oncallCell == null)
            {
                return NotFound();
            }

            return Ok(oncallCell);
        }

        // PUT: api/OncallCells/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOncallCell(int id, OncallCell oncallCell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oncallCell.Id)
            {
                return BadRequest();
            }

            db.Entry(oncallCell).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OncallCellExists(id))
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

        // POST: api/OncallCells
        [ResponseType(typeof(OncallCell))]
        public async Task<IHttpActionResult> PostOncallCell(OncallCell oncallCell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OncallCells.Add(oncallCell);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = oncallCell.Id }, oncallCell);
        }

        // DELETE: api/OncallCells/5
        [ResponseType(typeof(OncallCell))]
        public async Task<IHttpActionResult> DeleteOncallCell(int id)
        {
            OncallCell oncallCell = await db.OncallCells.FindAsync(id);
            if (oncallCell == null)
            {
                return NotFound();
            }

            db.OncallCells.Remove(oncallCell);
            await db.SaveChangesAsync();

            return Ok(oncallCell);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OncallCellExists(int id)
        {
            return db.OncallCells.Count(e => e.Id == id) > 0;
        }
    }
}