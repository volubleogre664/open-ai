namespace OpenAIAssessment.WebAPIControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using OpenAIAssessment.Interfaces;
    using OpenAIAssessment.Models;

    public class TextEditorWebAPIController : Controller
    {
        private readonly ITextEditorService textEditorService;

        public TextEditorWebAPIController(ITextEditorService textEditorService)
        {
            this.textEditorService = textEditorService;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions, int historyId)
        {
            var response = this.textEditorService.GetTextEditorResponse(new Input { HistoryId = historyId });

            return this.Ok(DataSourceLoader.Load(response, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {

            var input = JsonConvert.DeserializeObject<Input>(values);

            if (input == null)
                return this.BadRequest(new[] { input });

            var response = await this.textEditorService.PostTextEditorResponse(input);

            return this.Ok(response);
        }
    }
}
