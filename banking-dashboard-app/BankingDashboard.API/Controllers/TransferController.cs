using Microsoft.AspNetCore.Mvc;
using BankingDashboard.API.Models;
using BankingDashboard.API.Services;
using System.Threading.Tasks;

namespace BankingDashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly TransferService _transferService;

        public TransferController(TransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferFunds([FromBody] Transfer transfer)
        {
            if (transfer == null || transfer.Amount <= 0)
            {
                return BadRequest("Invalid transfer details.");
            }

            var result = await _transferService.ExecuteTransferAsync(transfer);
            if (result)
            {
                return Ok("Transfer successful.");
            }

            return BadRequest("Transfer failed. Please check the account details.");
        }
    }
}