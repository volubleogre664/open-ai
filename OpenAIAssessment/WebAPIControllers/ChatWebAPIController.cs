namespace OpenAIAssessment.WebAPIControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using OpenAIAssessment.Interfaces;
    using OpenAIAssessment.Models;

    public class ChatWebAPIController : Controller
    {
        private readonly IChatService chatService;

        public ChatWebAPIController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions, int historyId, bool isNewChat)
        {
            var response = this.chatService.GetChatResponse(new Input { HistoryId = historyId, IsNewChat = isNewChat });

            return this.Ok(DataSourceLoader.Load(response, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {

            var input = JsonConvert.DeserializeObject<Input>(values);

            if (input == null)
                return this.BadRequest(new[] { input });
            
            var response = await this.chatService.PostChatResponse(input);

            return this.Ok(response);
        }
    }
}
