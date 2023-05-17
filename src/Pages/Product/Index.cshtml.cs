using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// The purpose of this class is to Manage the index of the
    /// data for a single record because we want to implement the
    /// index from CRUDi system into our website.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Enacapsulates a json product service file to
        /// create an index model for the store.
        /// </summary>
        /// <param name="productService"></param>
        public IndexModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// Product service is get.
        public JsonFileProductService ProductService { get; }

        // Collection of the Data is get and privately set.
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet()
        {
            ///All data is returned.
            Products = ProductService.GetAllData();
        }
    }
}
