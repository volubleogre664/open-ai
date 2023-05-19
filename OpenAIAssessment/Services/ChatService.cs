namespace OpenAIAssessment.Services
{
    using System.Text;
    using System.Threading.Tasks;
    
    using Newtonsoft.Json;
    using OpenAIAssessment.Data;
    using OpenAIAssessment.Interfaces;
    using OpenAIAssessment.Models;

    public class ChatService : IChatService
    {
        private readonly string apiKey;
        private readonly string baseUrl;
        private readonly HttpClient httpClient;

        private readonly ApplicationDbContext dbContext;

        public ChatService(ApplicationDbContext dbContext)
        {
            this.apiKey = "API_KEY_HERE";
            this.baseUrl = "https://api.openai.com/v1/chat/completions";
            this.httpClient = new HttpClient();
            this.dbContext = dbContext;
            this.httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.apiKey}");
        }

        public List<Chat> GetChatResponse(Input input)
        {
            return this.dbContext.Chats.ToList().Select(_ => _).Where(_ => _.HistoryId == input.HistoryId).ToList();
        }

        public async Task<List<Chat>> PostChatResponse(Input input)
        {
            // var requestMessage = this.GenerateRequestMessage(message);

            var content = this.GenerateRequestContent(input.Message);

            var response = await this.httpClient.PostAsync(this.baseUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                return new List<Chat>();
            }

            var result = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(result))
                throw new Exception("No response from OpenAI");

            var chatResults = JsonConvert.DeserializeObject<ChatWrapper>(result);

            // Handle chatResults null here
            if (chatResults == null)
                throw new Exception("No response from OpenAI");

            var chats = chatResults.Choices.Select(_ => _.Message).ToList();
            var historyId = input.HistoryId;

            if (input.IsNewChat && input.HistoryId == 0)
            {
                var history = new History
                {
                    Content = input.Message,
                };

                this.dbContext.Histories.Add(history);
                await this.dbContext.SaveChangesAsync();

                input.HistoryId = history.HistoryId;
            }

            foreach (var chat in chats)
            {
                chat.HistoryId = input.HistoryId;
                chat.IsBot = true;
            }

            chats.Insert(0, new Chat
            {
                HistoryId = input.HistoryId,
                Content = input.Message,
                IsBot = false,
            });

            await this.dbContext.Chats.AddRangeAsync(chats);
            await this.dbContext.SaveChangesAsync();

            return chats;
        }

        private StringContent GenerateRequestContent(string message)
        {
            var requestBody = JsonConvert.SerializeObject(new 
            {
                model = "gpt-3.5-turbo",
                messages = new[] { new { role = "user", content = message } },
            });

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            return content;
        }
    }
}