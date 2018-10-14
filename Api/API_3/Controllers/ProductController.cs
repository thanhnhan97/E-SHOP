using API_3.Models;
using System.Linq;
using System.Web.Http;

namespace API_3.Controllers
{
    public class ProductController : ApiController
    {
        private readonly APIshopEntities db = new APIshopEntities();

        //Get: api/product
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(db.Products);
        }

        //Get by id: api/product/3
        [HttpGet]
        [Route("api/product/{id}")]
        public IHttpActionResult GetByID(int id)
        {
            var ob = db.Products.FirstOrDefault(x => x.ProductID == id);
            return Json(ob);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Product product)
        {
            //Check parameter null?
            if (product == null)
            {
                return null;
            }
            else
            {
                var ob = db.Products.Add(product);
                var checkItem = db.SaveChanges();
                if (checkItem > 0)
                {
                    return Json(ob);
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPut]
        [Route("api/product/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Product product)
        {
            var ob = db.Products.FirstOrDefault(x => x.ProductID == id);
            if (ob == null)
            {
                return null;
            }
            else
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                var checkUpdate = db.SaveChanges();
                if (checkUpdate > 0)
                {
                    return Json(product);
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpDelete]
        [Route("api/product/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var ob = db.Products.FirstOrDefault(x => x.ProductID == id);
            if (ob == null)
            {
                return null;
            }
            else
            {
                var itemRemove = db.Products.Remove(ob);
                var result = db.SaveChanges();
                if (result > 0)
                {
                    return Json(ob);
                }
                return null;
            }
        }
    }
}