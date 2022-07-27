using GeneralStoreAPI.Data;
using GeneralStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private GeneralStoreDBContext _db;
        public TransactionController(GeneralStoreDBContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromForm] TransactionEdit newTransaction)
        {
            _db.Transactions.Add(new Transaction()
            {
                ProductId = newTransaction.ProductId,
                CustomerId = newTransaction.CustomerId,
                Quantity = newTransaction.Quantity
            });


            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _db.Transactions.ToListAsync();
            return Ok(transactions);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromForm] TransactionEdit model, [FromRoute] int id)
        {
            var oldTransaction = await _db.Transactions.FindAsync(id);
            if (oldTransaction == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.ProductId != null)
            {
                oldTransaction.ProductId = model.ProductId;
            }
            if (model.CustomerId != null)
            {
                oldTransaction.CustomerId = model.CustomerId;
            }
            if (model.Quantity != null)
            {
                oldTransaction.Quantity = model.Quantity;
            }
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
        {
            var transaction = await _db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            _db.Transactions.Remove(transaction);
            await _db.SaveChangesAsync();
            return Ok();
        }




    }
}