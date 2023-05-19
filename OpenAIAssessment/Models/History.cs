namespace OpenAIAssessment.Models {
    using System.ComponentModel.DataAnnotations;

    public class History
    {
        [Key]
        public int HistoryId { get; set; }

        public string Content { get; set; }
    }
}