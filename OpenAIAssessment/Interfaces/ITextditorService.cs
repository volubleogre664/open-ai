
namespace OpenAIAssessment.Interfaces
{
    using OpenAIAssessment.Models;
    
    public interface ITextEditorService
    {
        Task<List<TextEditor>> PostTextEditorResponse(Input input);

        List<TextEditor> GetTextEditorResponse(Input input);
    }
}