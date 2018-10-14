using System.Linq;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : ApiController
    {
        private readonly ShoeShopEntities db = new ShoeShopEntities();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(db.Cards);
        }

        [HttpGet]
        [Route("api/cart/{id}")]
        public IHttpActionResult GetById(int id)
        {
            //Kiểm tra id có tồn tại hay không
            if (id.ToString() != null)
            {
                var ob = db.Cards.FirstOrDefault(x => x.CardID == id);
                return Ok(ob);
            }
            return null;
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Card cart)
        {
            if (cart != null)
            {
                var ob = db.Cards.Add(cart);
                return db.SaveChanges() > 0 ? Json(ob) : null;
            }
            return null;
        }

        [HttpDelete]
        [Route("api/cart/{id}")]
        public IHttpActionResult Detele(int id)
        {
            if (id.ToString() != null)
            {
                var ob = db.Cards.FirstOrDefault(x => x.CardID == id);
                db.Cards.Remove(ob);
                return db.SaveChanges() > 0 ? Json(ob) : null;
            }

            return null;
        }

        [HttpPut]
        [Route("api/cart/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Card cart)
        {
            if (id.ToString() != null)
            {
                var existItem = db.Cards.FirstOrDefault(x => x.CardID == id);
                if (existItem != null)
                {
                    db.Entry(existItem).CurrentValues.SetValues(cart);
                    return db.SaveChanges() > 0 ? Json(cart) : null;
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