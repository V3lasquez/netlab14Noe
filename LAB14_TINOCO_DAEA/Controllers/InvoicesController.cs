using LAB14_TINOCO_DAEA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETLAB14_DAEA.Models.Requets;

namespace NETLAB14_DAEA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly MarketContext _context;

        public InvoicesController(MarketContext context)
        {
            _context = context;
        }


        [HttpPost("FacturaUnica")]
        public IActionResult PostInvoice([FromBody] InvoiceInsertRequest request)
        {
            var invoice = new Invoice
            {
                CustomerID = request.CustomerID,
                Date = request.Date,
                InvoiceNumber = request.InvoiceNumber,
                Total = request.Total
                // Puedes añadir más propiedades según sea necesario
            };

            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            return Ok();
        }


        [HttpPost("InvoiceList")]
        public async Task<ActionResult<List<Invoice>>> InsertInvoiceList([FromBody] InvoiceInsertRequestV2 requestInvoiceV2)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(requestInvoiceV2.CustomerID);

                if (customer == null)
                {
                    return NotFound();
                }

                List<Invoice> invoiceList = requestInvoiceV2.requestInvoiceV3s.Select(x => new Invoice
                {
                    Date = x.Date,
                    Total = x.Total,
                    InvoiceNumber = x.InvoiceNumber,
                    CustomerID = customer.CustomerID,
                }).ToList();

                await _context.SaveChangesAsync();

                return CreatedAtAction("InsertInvoiceList", new { message = "Invoices insert correctly" }, invoiceList);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
}
