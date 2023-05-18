namespace OpenAIAssessment.Services
{
    using System.Text;
    using System.Threading.Tasks;
    
    using Newtonsoft.Json;

    using OpenAIAssessment.Interfaces;
    using OpenAIAssessment.Models;

    public class ChatService : IChatService
    {
        private readonly string apiKey;
        private readonly string baseUrl = "https://api.openai.com/v1/chat/completions";
        // private readonly string baseUrl = "https://api.openai.com/v1/engines/gpt-3.5-turbo/completions";
        private readonly HttpClient httpClient;

        public ChatService(string? apiKey = null)
        {
            this.apiKey = "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";
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.apiKey}");
        }

        public async Task<List<Chat>> GetChatResponse(string message)
        {
            // var requestMessage = this.GenerateRequestMessage(message);

            var requestBody = JsonConvert.SerializeObject(new 
            {
                model = "gpt-3.5-turbo",
                messages = new[] { new { role = "user", content = message } },
            });

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await this.httpClient.PostAsync(this.baseUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(result))
                    throw new Exception("No response from OpenAI");

                var chatResults = JsonConvert.DeserializeObject<ChatWrapper>(result);

                // Handle chatResults null here
                if (chatResults == null)
                    throw new Exception("No response from OpenAI");

                var chats = chatResults.Choices.Select(_ => _.Message).ToList();

                foreach (var chat in chats)
                {
                    chat.IsBot = true;
                }

                return chats;
            }

            return new List<Chat>();
        }

        private HttpRequestMessage GenerateRequestMessage(string message)
        {
            var requestBody = JsonConvert.SerializeObject(new 
            {
                model = "gpt-3.5-turbo",
                messages = JsonConvert.SerializeObject(new List<object> { new { role = "user", content = message } }),
            });

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            return new(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
            {
                Content = content,
            };
        }
    }
}