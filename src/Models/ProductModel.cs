using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    //Create a Product Model
    public class ProductModel
    {
        //Defining the various attributes that a Product Model holds
        public string Id { get; set; }
        public string Maker { get; set; }
        
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OnlineMenuLink { get; set; }
        public string Phone { get; set; }
        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

 
    }
}