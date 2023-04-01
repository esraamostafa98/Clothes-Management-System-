using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.BL.Interfaces;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct product;

        public ProductController(IProduct Product)
        {
            product = Product;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = product.Get();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var data = product.GetById(id);
            return Ok(data);
        }
        [HttpPost]
        public ActionResult PostData([FromForm]ProductVM prod)
        {
             product.Add(prod);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateData([FromForm] ProductVM prod)
        {
             product.Edit(prod);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteData(int id)
        {
             product.Delete(id);
            return Ok();
        }


    }
}
