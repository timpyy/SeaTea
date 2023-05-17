using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

///<summary>
///The purpose of this file is provide an index for
///each unique record stored because we want to be
///able to identify each record based on their given index
///</summary>
namespace ContosoCrafts.WebSite.Pages
{
    //Uses page model to be modified that implements an
    //index into the page.
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Creates a read only ilogger index model file.
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Index model is set to encapsulate the index model of
        /// iLogger in order to instantitate product service.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        ///Json file product service is returned.
        public JsonFileProductService ProductService { get; }

        public IEnumerable<ProductModel> Products { get; private set; }

        ///OnGet every product is set to be equal to the products
        public void OnGet()
        {
            ///Products is set equal to get products for all products
            ///in product service.
            Products = ProductService.GetProducts();
        }
    }
}