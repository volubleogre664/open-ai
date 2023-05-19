namespace OpenAIAssessment.Interfaces
{
    using OpenAIAssessment.Models;

    public interface IChatService
    {
        Task<List<Chat>> PostChatResponse(Input input);

        List<Chat> GetChatResponse(Input input);
    }
}