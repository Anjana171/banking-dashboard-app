using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BankingDashboard.Shared.Models;

namespace BankingDashboard.Client.Services
{
    public class TransferService
    {
        private readonly HttpClient _httpClient;

        public TransferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Transfer> TransferFundsAsync(Transfer transfer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/transfer", transfer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Transfer>();
        }
    }
}