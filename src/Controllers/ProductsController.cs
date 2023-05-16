using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    ///<summary>
    ///The purpose of this class is for product service to be
    ///controlled when requsted because we want to be able to
    ///request correctly per record.
    ///</summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            //sets ProductService equals to productSerivce
            ProductService = productService;
        }

        /// <summary>
        /// Gets the product json file product service.
        /// </summary>
        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            //returns the products using the product service class.
            return ProductService.GetProducts();
        }

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ///Adds the rating using the product id of the store
            ///with request to the current rating
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }
        /// <summary>
        /// Provides a rating request using the productid and rating.
        /// </summary>
        //found in each record data.
        public class RatingRequest
        {
            //Gets and sets productID.
            public string ProductId { get; set; }
            //Gets and sets rating.
            public int Rating { get; set; }
        }
    }
}