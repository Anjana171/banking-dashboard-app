using System;
using System.Threading.Tasks;
using BankingDashboard.API.Models;
using BankingDashboard.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingDashboard.API.Services
{
    public class TransferService
    {
        private readonly BankingContext _context;

        public TransferService(BankingContext context)
        {
            _context = context;
        }

        public async Task<bool> TransferFunds(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = await _context.Accounts.FindAsync(fromAccountId);
            var toAccount = await _context.Accounts.FindAsync(toAccountId);

            if (fromAccount == null || toAccount == null || fromAccount.Balance < amount)
            {
                return false; // Transfer cannot be completed
            }

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            var transfer = new Transfer
            {
                FromAccountId = fromAccountId,
                ToAccountId = toAccountId,
                Amount = amount,
                TransferDate = DateTime.UtcNow
            };

            _context.Transfers.Add(transfer);
            await _context.SaveChangesAsync();

            return true; // Transfer completed successfully
        }
    }
}