using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

///<summary>
///The purpose of this file is provide an Privacy for
///each unique record stored because we want to be
///able to identify each record based on their given Privacy
///</summary>/
namespace ContosoCrafts.WebSite.Pages
{
    //Uses page model to be modified that implements an
    //Privacy into the page.
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
           
        }

        

        public void OnGet()
        {
            
        }
    }
}

