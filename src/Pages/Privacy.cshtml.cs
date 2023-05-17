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
    ///Uses page model to be modified that implements an
    ///Privacy into the page.
    public class PrivacyModel : PageModel
    {
        /// <summary>
        /// Creates a readonly for the iLogger using the Privacy Model.
        /// </summary>
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Creates a class to encapsulate the privacy model of
        /// illoger along with json file to set _logger variable
        /// equal to logger.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger,
            JsonFileProductService productService)
        {
            //Logger is set equal to _logger from encasuplation
            _logger = logger;
           
        }

        /// <summary>
        /// Empty class file for onGet for testing purposes.
        /// </summary>
        public void OnGet()
        {
            
        }
    }
}

