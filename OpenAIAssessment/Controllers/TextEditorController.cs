namespace OpenAIAssessment.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TextEditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
