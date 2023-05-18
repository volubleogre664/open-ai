namespace OpenAIAssessment.WebAPIControllers
{
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
        public async Task<IActionResult> Get(string message)
        {
            var response = await this.chatService.GetChatResponse(message);

            return this.Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {

            var input = JsonConvert.DeserializeObject<Input>(values);
            
            var response = await this.chatService.GetChatResponse(input.Message);

            return this.Ok(response);
        }
    }
}
