namespace OpenAIAssessment.Services
{
    using System.Text;
    
    using Newtonsoft.Json;

    using OpenAIAssessment.Data;
    using OpenAIAssessment.Interfaces;
    using OpenAIAssessment.Models;

    public class TextEditorService : ITextEditorService
    {
        private readonly ApplicationDbContext context;
        private readonly string apiKey;
        private readonly string baseUrl;
        private readonly HttpClient httpClient;

        public TextEditorService(ApplicationDbContext context)
        {
            this.apiKey = "API_KEY_HERE";
            this.baseUrl = "https://api.openai.com/v1/edits";
            this.httpClient = new HttpClient();
            this.context = context;
            this.httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.apiKey}");
        }

        public List<TextEditor> GetTextEditorResponse(Input input)
        {
            return this.context.TextEdits.ToList().Select(_ => _).Where(_ => _.HistoryId == input.HistoryId).ToList();
        }

        public async Task<List<TextEditor>> PostTextEditorResponse(Input input)
        {
            var content = this.GenerateRequestContent(input);

            var response = await this.httpClient.PostAsync(this.baseUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                return new List<TextEditor>();
            }

            var result = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(result))
                throw new Exception("No response from OpenAI");

            var textEditorResults = JsonConvert.DeserializeObject<TextEditorWrapper>(result);

            // Handle textEditorResults null here
            if (textEditorResults == null)
                throw new Exception("No response from OpenAI");

            var textEdits = textEditorResults.Choices;

            var history = new History() { Content = input.Message };

            if (history.Content.Length > 40)
            {
                history.Content = history.Content.Substring(0, 40);
            }

            this.context.Histories.Add(history);
            await this.context.SaveChangesAsync();

            textEdits.ForEach(_ => {
                _.IsBot = true;
                _.HistoryId = history.HistoryId;
            });

            textEdits.Insert(0, new TextEditor() { Text = input.Message, IsBot = false, HistoryId = history.HistoryId });

            await this.context.TextEdits.AddRangeAsync(textEdits);
            await this.context.SaveChangesAsync();

            return textEdits;
        }

        private StringContent GenerateRequestContent(Input input)
        {
            var requestBody = JsonConvert.SerializeObject(new 
            {
                model = "text-davinci-edit-001",
                input = input.Message,
                instruction = input.Instruction,
            });

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            return content;
        }
    }
}