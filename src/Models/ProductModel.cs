using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    ///<summary>
    ///The purpose of this class is to Create a Product Model
    ///where the specifics of a data such as image, url, title, description
    ///neighborhood, online menu link, phone and ratings will be used
    ///because we want to store our data for boba consistently to be able
    ///to implement CRUDi methods when needed.
    ///</summary>
    public class ProductModel
    {
        //Defining the various attributes that a Product Model holds for the id
        public string Id { get; set; }
        //Gets and sets the maker for the store.
        public string Maker { get; set; }
        
        //Gets and sets image for the store.
        public string Image { get; set; }
        //Gets and sets a link for the store.
        public string Url { get; set; }
        //Gets and sets the store title.
        public string Title { get; set; }
        //Provides a description about the boba store.
        public string Description { get; set; }
        //Provides a description about the location of the store.
        public string Neighborhood { get; set; }
        //Provides the menu link for a store.
        public string OnlineMenuLink { get; set; }
        //Gives the contact info of a store.
        public string Phone { get; set; }
        //Provides the ratings of a store.
        public int[] Ratings { get; set; }

        /// <summary>
        /// Overrides in order to serialize the product model of
        /// the jsole serializer class.
        /// </summary>
        /// <returns></returns>
        /// 

        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        public override string ToString() =>
            JsonSerializer.Serialize<ProductModel>(this);

 
    }
}