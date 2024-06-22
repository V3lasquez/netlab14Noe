using LAB14_TINOCO_DAEA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETLAB14_DAEA.Models.Requets;

namespace NETLAB14_DAEA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInserController : ControllerBase
    {
        private readonly MarketContext _context;

        public ProductInserController(MarketContext context)
        {
            _context = context;
        }
        [HttpPost]
        public void Insert(ProductInsertRequest request)
        {

            //Convertir request=>model
            Product model = new Product();
            model.Price = request.Price;
            model.Name = request.Name;
            model.Active = true;

            _context.Products.Add(model);
            _context.SaveChanges();
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] ProductDeleteRequest request)
        {
            var product = _context.Products.Find(request.ProductID);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}
