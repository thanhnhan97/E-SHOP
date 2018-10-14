using App_Shop.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace App_Shop.Controllers
{
    public class AccessManagementsController : ApiController
    {
        private DbShopEntities db = new DbShopEntities();

        // GET: api/AccessManagements
        public IQueryable<AccessManagement> GetAccessManagements()
        {
            return db.AccessManagements;
        }

        // GET: api/AccessManagements/5
        [ResponseType(typeof(AccessManagement))]
        public async Task<IHttpActionResult> GetAccessManagement(int id)
        {
            AccessManagement accessManagement = await db.AccessManagements.FindAsync(id);
            if (accessManagement == null)
            {
                return NotFound();
            }

            return Ok(accessManagement);
        }

        // PUT: api/AccessManagements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAccessManagement(int id, AccessManagement accessManagement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accessManagement.AMID)
            {
                return BadRequest();
            }

            db.Entry(accessManagement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessManagementExists(id))
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

        // POST: api/AccessManagements
        [ResponseType(typeof(AccessManagement))]
        public async Task<IHttpActionResult> PostAccessManagement(AccessManagement accessManagement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccessManagements.Add(accessManagement);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = accessManagement.AMID }, accessManagement);
        }

        // DELETE: api/AccessManagements/5
        [ResponseType(typeof(AccessManagement))]
        public async Task<IHttpActionResult> DeleteAccessManagement(int id)
        {
            AccessManagement accessManagement = await db.AccessManagements.FindAsync(id);
            if (accessManagement == null)
            {
                return NotFound();
            }

            db.AccessManagements.Remove(accessManagement);
            await db.SaveChangesAsync();

            return Ok(accessManagement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccessManagementExists(int id)
        {
            return db.AccessManagements.Count(e => e.AMID == id) > 0;
        }
    }
}