using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    // <summary>
    // The purpose of this class is to Manage the create of the
    // data for a single record because we want to implement the
    // create from CRUDi system into our website.
    // </summary>
    public class CreateModel : PageModel
    {
        // Data middle tier where the previous data are stored in.
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show for create.
        public ProductModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet()
        {
            //Creates the new record.
            Product = ProductService.CreateData();

            return RedirectToPage("./Update", new { Id = Product.Id });
        }
    }
}
