using API.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers
{
    public class ProductCategoriesController : ApiController
    {
        private WebBanHangEntities db = new WebBanHangEntities();

        // GET: api/ProductCategories
        public IQueryable<ProductCategory> GetProductCategories()
        {
            return db.ProductCategories.AsQueryable();
        }

        // GET: api/ProductCategories/5
        [ResponseType(typeof(ProductCategory))]
        public async Task<IHttpActionResult> GetProductCategory(int id)
        {
            ProductCategory productCategory = await db.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return null;
            }

            return Ok(productCategory);
        }

        // PUT: api/ProductCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.ProductCategoryID)
            {
                return null;
            }

            db.Entry(productCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
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

        // POST: api/ProductCategories
        [ResponseType(typeof(ProductCategory))]
        public async Task<IHttpActionResult> PostProductCategory(ProductCategory productCategory)
        {
            var ob = db.ProductCategories.Add(productCategory);
            await db.SaveChangesAsync();

            return Ok(ob);
        }

        // DELETE: api/ProductCategories/5
        [ResponseType(typeof(ProductCategory))]
        public async Task<IHttpActionResult> DeleteProductCategory(int id)
        {
            ProductCategory productCategory = await db.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return null;
            }

            db.ProductCategories.Remove(productCategory);
            await db.SaveChangesAsync();

            return Ok(productCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductCategoryExists(int id)
        {
            return db.ProductCategories.Count(e => e.ProductCategoryID == id) > 0;
        }
    }
}