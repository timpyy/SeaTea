using System.Diagnostics;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

/// <summary>
/// The purpose of this file is to provide
/// or display error if a error does occur
/// when running the file.
/// </summary>

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Creates an error model from the page model class
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        ///Initiates requestId as a string and sets the id.
        public string RequestId { get; set; }

        /// <summary>
        /// Inititates a boolen request for ShowRequestID.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;
        //private JsonFileProductService productService;

        /// <summary>
        /// Provides the error model if error does occur.
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            ///Logger is set to _logger class error model.
            _logger = logger;
        }

       
        ///Provides the error message.
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}