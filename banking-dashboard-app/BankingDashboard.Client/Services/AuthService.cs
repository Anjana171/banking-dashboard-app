using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BankingDashboard.Client.Models;

namespace BankingDashboard.Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public async Task Register(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", request);
            response.EnsureSuccessStatusCode();
        }

        public void Logout()
        {
            // Implement logout logic, such as clearing tokens
        }
    }
}