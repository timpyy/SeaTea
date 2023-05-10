using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages
{
    // <summary>
    // The purpose of this class is to Manage the index of the
    // data for a single record because we want to implement the
    // index from CRUDi system into our website.
    // </summary>
    public class ListingModel : PageModel
    {

        public ListingModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Data Service
        public JsonFileProductService ProductService { get; }

        // Collection of the Data
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet()
        {
        }
    }
}
