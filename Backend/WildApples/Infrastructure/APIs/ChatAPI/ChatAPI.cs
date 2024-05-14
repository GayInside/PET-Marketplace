using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.APIs.ChatAPI
{
    public class ChatAPI
    {
        private readonly string AddUserUrl = "http://localhost:5072/chat/api/User/AddUser";
        private readonly string CreateChatUrl = "http://localhost:5072/chat/api/Chat/CreateChat";
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

        public async Task<long?> CreateChat(ChatDTO chat)
        {
            var response = await _httpClient.PostAsJsonAsync(CreateChatUrl, chat);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("No such users");
            }

            var id = JsonSerializer.Deserialize<long>(await response.Content.ReadAsStringAsync());
            return id;
        }
    }
}
