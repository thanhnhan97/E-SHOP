using API.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers
{
    public class AccessManagementsController : ApiController
    {
        private WebBanHangEntities db = new WebBanHangEntities();

        // GET: api/AccessManagements
        public IQueryable<AccessManagement> GetAccessManagements()
        {
            return db.AccessManagements.AsQueryable();
        }

        // GET: api/AccessManagements/5
        [ResponseType(typeof(AccessManagement))]
        public async Task<IHttpActionResult> GetAccessManagement(int id)
        {
            AccessManagement accessManagement = await db.AccessManagements.FindAsync(id);
            if (accessManagement == null)
            {
                return null;
            }

            return Ok(accessManagement);
        }

        // PUT: api/AccessManagements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAccessManagement(int id, AccessManagement accessManagement)
        {
            if (id != accessManagement.AMID)
            {
                return null;
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
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        // POST: api/AccessManagements
        [ResponseType(typeof(AccessManagement))]
        public async Task<IHttpActionResult> PostAccessManagement(AccessManagement accessManagement)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            var ob = db.AccessManagements.Add(accessManagement);
            await db.SaveChangesAsync();

            return Ok(ob);
        }

        // DELETE: api/AccessManagements/5
        [ResponseType(typeof(AccessManagement))]
        public async Task<IHttpActionResult> DeleteAccessManagement(int id)
        {
            AccessManagement accessManagement = await db.AccessManagements.FindAsync(id);
            if (accessManagement == null)
            {
                return null;
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