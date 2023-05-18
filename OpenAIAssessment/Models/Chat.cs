namespace OpenAIAssessment.Models
{
    using Newtonsoft.Json;

    public class Chat
    {
        public string Content { get; set; }

        [JsonIgnore]
        public bool IsBot { get; set; }
    }
}
