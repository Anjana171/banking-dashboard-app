using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingDashboard.API.Data;
using BankingDashboard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingDashboard.API.Services
{
    public class AccountService
    {
        private readonly BankingContext _context;

        public AccountService(BankingContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}