namespace OpenAIAssessment.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using OpenAIAssessment.Data;
    using OpenAIAssessment.Interfaces;
    using OpenAIAssessment.Models;

    public class HistoryService : IHistoryService
    {
        private readonly ApplicationDbContext context;

        public HistoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<History> GetHistory(string page)
        {
            return page switch
            {
                "texteditor" => this.GetTextEditHistory(),
                "chat" => this.GetChatHistory(),
                _ => new List<History>()
            };
        }

        private List<History> GetChatHistory()
        {
            var history = this.context.Histories.ToList();
            var chats = this.context.Chats.ToList().Select(_ => _.HistoryId).ToList();

            return history.Where(_ => chats.Contains(_.HistoryId)).ToList();
        }

        private List<History> GetTextEditHistory()
        {
            var history = this.context.Histories.ToList();
            var edits = this.context.TextEdits.ToList().Select(_ => _.HistoryId).ToList();

            return history.Where(_ => edits.Contains(_.HistoryId)).ToList();
        }
    }
}