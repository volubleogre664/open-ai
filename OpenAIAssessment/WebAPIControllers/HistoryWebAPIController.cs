
namespace OpenAIAssessment.WebAPIControllers
{
    using Microsoft.AspNetCore.Mvc;
    
    using OpenAIAssessment.Interfaces;

    public class HistoryWebAPIController : Controller
    {
        private readonly IHistoryService historyService;

        public HistoryWebAPIController(IHistoryService historyService)
        {
            this.historyService = historyService;
        }

        [HttpGet]
        public IActionResult Get(string page)
        {
            var response = this.historyService.GetHistory(page);

            return this.Ok(response);
        }
    }
}