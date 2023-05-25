using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages.Product
{
    // <summary>
    // The purpose of this class is to Manage the Read of the
    // data for a single recor because we want to implement the
    // read from CRUDi system into our website.
    // </summary>
    public class ReadModel : PageModel
    {
        // Data middletier where the data is obtained from.
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show for reading.
        public ProductModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            //If invalid URL for read page provided, redirect to Index
            if (Product == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}