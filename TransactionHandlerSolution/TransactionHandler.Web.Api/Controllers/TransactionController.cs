using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using TransactionHandler.Business.Enums;
using TransactionHandler.Business.Models;

namespace TransactionHandler.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class TransactionController : ControllerBase
    {
        private IMemoryCache _cache;

        public TransactionController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpPost]
        [Route("CreateNew")]
        public IActionResult CreateNewTransaction([FromBody] string transactionName)
        {
            var newTransactionId = Guid.NewGuid();

            var newTransaction = new TransactionModel()
            {
                ID = newTransactionId,
                IsActive = true,
                Name = transactionName,
                StatusId = TransactionStatus.InProgress,
                CreatedDate = DateTime.Now,
                LastUpdatedDate = null
            };

            _cache.Set(newTransactionId, newTransaction);

            return new OkObjectResult(newTransaction);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetTransactionById(Guid transactionId)
        {
            var foundTransaction = _cache.Get<TransactionModel>(transactionId);

            if (foundTransaction == null)
            {
                return NotFound();
            }

            return new OkObjectResult(foundTransaction);
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateTransaction([FromBody] TransactionModel transaction)
        {
            var transactionToUpdate = _cache.Get<TransactionModel>(transaction.ID);

            if (transactionToUpdate == null)
            {
                return NotFound();
            }

            _cache.Remove(transaction.ID);
            _cache.Set(transaction.ID, transaction);
            return new OkResult();
        }
    }
}
