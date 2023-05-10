using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    // <summary>
    // The purpose of this class is to Manage the deletion of the
    // data for a single record because we want to implement the
    // delete from CRUDi system into our website.
    // </summary>
    public class DeleteModel : PageModel
    {
        // Data middletier that holds that following data.
        public JsonFileProductService ProductService { get; }

        
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public DeleteModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        [BindProperty]
        public ProductModel Product { get; set; }

        
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            //Gets the data that matches the data for deletion.
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        //Provides the result after the deletion of a record
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Deletes the data selected.
            ProductService.DeleteData(Product.Id);

            //Goes back to the data with the deletion completion.
            return RedirectToPage("/Listing");
        }
    }
}
