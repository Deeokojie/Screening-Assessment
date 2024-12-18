using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace DeeWebAppAssessment.Pages
{
    public class ClicksModel : PageModel
    {
        public int ClickCount { get; set; }

        public void OnGet()
        {
            // Retrieve click count from the session, default to 0 if not set
            ClickCount = HttpContext.Session.GetInt32("ClickCount") ?? 0;
        }
    }
}