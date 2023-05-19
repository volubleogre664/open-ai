namespace OpenAIAssessment.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using Newtonsoft.Json;

    public class Chat
    {
        [Key]
        public int ChatId { get; set; }

        [Column("fkHistoryId")]
        public int HistoryId { get; set; }

        public string Content { get; set; }

        [JsonIgnore]
        public bool IsBot { get; set; }
    }
}
