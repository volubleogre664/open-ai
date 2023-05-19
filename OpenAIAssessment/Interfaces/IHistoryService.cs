namespace OpenAIAssessment.Interfaces
{
    using OpenAIAssessment.Models;

    public interface IHistoryService
    {
        List<History> GetHistory(string page);
    }
}