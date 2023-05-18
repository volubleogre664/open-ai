namespace OpenAIAssessment.Interfaces
{
    using OpenAIAssessment.Models;

    public interface IChatService
    {
        Task<List<Chat>> GetChatResponse(string message);
    }
}