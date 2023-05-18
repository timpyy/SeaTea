using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// The purpose of this class is to set a json file product service
    /// that creates a web host environment.
    /// </summary>
    public class JsonFileProductService
    {
        /// <summary>
        /// Create JsonFileProductService on the webHostEnvironment
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            //Webhost environment is called. 
            WebHostEnvironment = webHostEnvironment;
        }

        ///Define a getter for WebHostEnvironment
        public IWebHostEnvironment WebHostEnvironment { get; }

        ///Establish the file path to products.json, where all the products are stored
        private string JsonFileName
        {
            ///Returns the root path of the web
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }
        /// <summary>
        /// Method that goes through products.json and deserializes/returns all
        /// product data that is contained within
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                ///Deserializes the product data that is contained.
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        ///Method that returns all ProductModel objects from products.json
        public IEnumerable<ProductModel> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                ///Retuns all the product model objects from products json.
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Add Rating
        /// 
        /// Take in the product ID and the rating
        /// If the rating does not exist, add it
        /// Save the update
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            if (products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = products.First(x => x.Id == productId).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.Id == productId).Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Private method that Saves All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {
            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData()
        {
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Store Name",
                Description = "Enter Store Address",
                Neighborhood = "Enter Seattle Neighborhood",
                Url = "Enter Store URL",
                Image = "Enter Store Image URL",
                Phone = "Enter Store's Phone Number",
                OnlineMenuLink = "Enter URL to Store's menu",
            };

            //Get the current set, and append the new record to it
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ProductModel UpdateData(ProductModel data)
        {
            var products = GetAllData();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }
            // Update the data to the new passed in values
            productData.Title = data.Title;
            productData.Description = data.Description.Trim();
            productData.Neighborhood = data.Neighborhood;
            productData.Url = data.Url;
            productData.Image = data.Image;
            productData.Phone = data.Phone;
            productData.OnlineMenuLink = data.OnlineMenuLink;

            SaveData(products);

            return productData;
        }
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }
    }
}