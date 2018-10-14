using System.Linq;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : System.Web.Http.ApiController
    {
        private readonly ShoeShopEntities db = new ShoeShopEntities();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(db.Products);
        }

        [HttpGet]
        [Route("api/product/{id}")]
        public IHttpActionResult GetById(int id)
        {
            if (id.ToString() != null)
            {
                var ob = db.Products.FirstOrDefault(x => x.ProductID == id);
                return Ok(ob);
            }
            return null;
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Product product)
        {
            if (product != null)
            {
                var ob = db.Products.Add(product);
                return db.SaveChanges() > 0 ? Json(ob) : null;
            }
            return null;
        }

        [HttpDelete]
        [Route("api/product/{id}")]
        public IHttpActionResult Detele(int id)
        {
            if (id.ToString() != null)
            {
                var ob = db.Products.FirstOrDefault(x => x.ProductID == id);
                db.Products.Remove(ob);
                return db.SaveChanges() > 0 ? Json(ob) : null;
            }

            return null;
        }

        [HttpPut]
        [Route("api/product/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Product product)
        {
            if (id.ToString() != null)
            {
                var existItem = db.Products.FirstOrDefault(x => x.ProductID == id);
                if (existItem != null)
                {
                    db.Entry(existItem).CurrentValues.SetValues(product);
                    return db.SaveChanges() > 0 ? Json(product) : null;
                }
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}