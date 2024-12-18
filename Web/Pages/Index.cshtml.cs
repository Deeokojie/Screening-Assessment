using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DeeWebAppAssessment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Click Counter Property
        public int ClickCount { get; set; }

        // String Reversal Properties
        [BindProperty]
        public string InputText { get; set; }

        public string ReversedString { get; set; }
        public string ReversedWords { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Retrieve Click Count from session
            ClickCount = HttpContext.Session.GetInt32("ClickCount") ?? 0;
            _logger.LogInformation("Session ClickCount: {ClickCount}", ClickCount);
        }

        public IActionResult OnPost(string submitButton)
        {
            // Handle Increment Button
            if (submitButton == "increment")
            {
                ClickCount = (HttpContext.Session.GetInt32("ClickCount") ?? 0) + 1;
                HttpContext.Session.SetInt32("ClickCount", ClickCount);
                _logger.LogInformation("Session ClickCount: {ClickCount}", ClickCount);
            }
            // Handle Reverse Button
            else if (submitButton == "reverse" && !string.IsNullOrEmpty(InputText))
            {
               
                ReversedString = new string(InputText.Reverse().ToArray());
                ReversedWords = string.Join(" ", InputText.Split(' ').Reverse());
            }

            // Reload session value to persist ClickCount
            ClickCount = HttpContext.Session.GetInt32("ClickCount") ?? 0;
            return Page();
        }
    }
}