using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ContosoCrafts.WebSite.Models
{
    ///<summary>
    ///The purpose of this file class
    ///is to make the search filter work
    ///because we want to be able to work the filter requirement
    ///from the data stored.
    ///</summary>
    public enum ProductTypeEnum
    {
        //Sets enum undefined to 0.
        Undefined = 0,
        //Sets amature to 1.
        Amature = 1,
        //Sets antique to 5.
        Antique = 5,
        //Sets collectable to 130.
        Collectable = 130,
        //Sets commercial to 55.
        Commercial = 55,
    }


    /// <summary>
    /// The purpose of the product type enum extensions class
    /// is to be able to add functionality to specific enum type.
    /// </summary>
    public static class ProductTypeEnumExtensions
    {
        //Provides the display name of using the product data.
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                //Amature class is set to hand made items.
                ProductTypeEnum.Amature => "Hand Made Items",
                //Antique class is set to antiques.
                ProductTypeEnum.Antique => "Antiques",
                //Collectable class is set collectables.
                ProductTypeEnum.Collectable => "Collectables",
                //Commercial class is set to commercial goods.
                ProductTypeEnum.Commercial => "Commercial goods",

                // Default, Unknown
                _ => "",
            };
        }
    }
}