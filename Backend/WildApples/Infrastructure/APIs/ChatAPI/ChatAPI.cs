using System.Net.Http.Json;

namespace Infrastructure.APIs.ChatAPI
{
    public class ChatAPI
    {
        private string AddUserUrl = "http://localhost:5072/chat/api/User/AddUser";
        private readonly HttpClient _httpClient;

        public ChatAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("ApiKey", "Token");
        }

        public async Task AddUserToApi(UserDTO user)
        {
            await _httpClient.PostAsJsonAsync(AddUserUrl, user);
        }
    }
}
