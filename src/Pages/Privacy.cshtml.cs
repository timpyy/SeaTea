using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private JsonFileProductService productService;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public PrivacyModel(ILogger<PrivacyModel> logger, JsonFileProductService productService) : this(logger)
        {
            this.productService = productService;
        }

        public void OnGet()
        {
        }
    }
}
