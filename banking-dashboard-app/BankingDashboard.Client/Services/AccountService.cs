using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BankingDashboard.Client.Models;

namespace BankingDashboard.Client.Services
{
    public class AccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Account[]> GetAccountsAsync()
        {
            return await _httpClient.GetFromJsonAsync<Account[]>("api/account");
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Account>($"api/account/{id}");
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            var response = await _httpClient.PostAsJsonAsync("api/account", account);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Account>();
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/account/{account.Id}", account);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Account>();
        }

        public async Task DeleteAccountAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/account/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}