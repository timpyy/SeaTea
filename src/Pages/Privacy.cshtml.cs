using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    //<summary>
    //The purpose of this file is to provide
    //a constructor for the privacy model
    //in order to run a unit because
    //we want to get a 100% unit test cover.
    //</summary>
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
