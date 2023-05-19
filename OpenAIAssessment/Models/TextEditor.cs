namespace OpenAIAssessment.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TextEditor
    {
        [Key]
        public int TextId { get; set; }

        [Column("fkHistoryId")]
        public int HistoryId { get; set; }

        public string Text { get; set; }

        public bool IsBot { get; set; }
    }
}
