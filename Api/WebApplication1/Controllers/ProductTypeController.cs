using System.Linq;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductTypeController : ApiController
    {
        private readonly ShoeShopEntities db = new ShoeShopEntities();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(db.ProductTypes);
        }

        [HttpGet]
        [Route("api/producttype/{id}")]
        public IHttpActionResult GetById(int id)
        {
            //Kiểm tra id có tồn tại hay không
            if (id.ToString() != null)
            {
                var ob = db.ProductTypes.FirstOrDefault(x => x.ProductTypeID == id);
                return Ok(ob);
            }
            return null;
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] ProductType producttype)
        {
            if (producttype != null)
            {
                var ob = db.ProductTypes.Add(producttype);
                return db.SaveChanges() > 0 ? Json(ob) : null;
            }
            return null;
        }

        [HttpDelete]
        [Route("api/producttype/{id}")]
        public IHttpActionResult Detele(int id)
        {
            if (id.ToString() != null)
            {
                var ob = db.ProductTypes.FirstOrDefault(x => x.ProductTypeID == id);
                db.ProductTypes.Remove(ob);
                return db.SaveChanges() > 0 ? Json(ob) : null;
            }

            return null;
        }

        [HttpPut]
        [Route("api/producttype/{id}")]
        public IHttpActionResult Update(int id, [FromBody] ProductType producttype)
        {
            if (id.ToString() != null)
            {
                producttype.Products = null;
                var existItem = db.ProductTypes.FirstOrDefault(x => x.ProductTypeID == id);
                if (existItem != null)
                {
                    int result;
                    db.Entry(existItem).CurrentValues.SetValues(producttype);
                    return (result = db.SaveChanges()) > 0 ? Json(producttype) : null;
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