namespace OpenAIAssessment.Models
{
    using Newtonsoft.Json;

    public class Input
    {

        public string Message { get; set; }

        public string Instruction { get; set; }

        public int HistoryId { get; set; }

        public bool IsNewChat { get; set; }
    }
}