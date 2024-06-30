using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LAB14_TINOCO_DAEA.Models;
using NETLAB14_DAEA.Models.Requets;

namespace LAB14_TINOCO_DAEA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MarketContext _context;

        public CustomersController(MarketContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            return await _context.Customers.Where(x => x.Active == true).ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, [FromBody] CustomerUpdateNumeroDocumento request)
        {
            if (id != request.CustomerID)
            {
                return BadRequest();
            }

            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.DocumentNumber = request.DocumentNumber;
            customer.FirstName = request.FirstName;
            customer.LasttName = request.LasttName;
            customer.Active = request.Active;

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(e => e.CustomerID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }


        //POST: api/Customers
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerInsertRequest requestCustomer)
        {
            Customer customer = new();
            customer.FirstName = requestCustomer.FirstName;
            customer.DocumentNumber = requestCustomer.DocumentNumber;
            customer.LasttName = requestCustomer.LasttName;

            if (_context.Customers == null)
            {
                return Problem("Entity set 'MarketContext.Customers'  is null.");
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerID }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] CustomerDeleteRequest request)
        {
            var customer = _context.Customers.Find(request.CustomerID);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }
    }
}
