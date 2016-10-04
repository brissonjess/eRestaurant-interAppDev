using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using System.ComponentModel;
using eRestaurantSystem.DAL;
using eRestaurantSystem.Data.Entities;
using eRestaurantSystem.Data.DTOs;
using eRestaurantSystem.Data.POCOs;
#endregion 

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class ItemsController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<MenuCategoryFoodItemsDTO> MenuCategoryFoodItemsDTO_Get()
        {
            using (var context = new eRestaurantContext())
            {
                var results = from food in context.Items
                              group food by new { food.MenuCategory.Description } into tempdataset
                              select new MenuCategoryFoodItemsDTO
                              {
                                  MenuCategoryDescription = tempdataset.Key.Description,

                                  FoodItems = (from x in tempdataset
                                              select new FoodItemCounts
                                              {
                                                  ItemID = x.ItemID,
                                                  FoodDescription = x.Description,
                                                  CurrentPrice = x.CurrentPrice,
                                                  //TimeServed = x.BillItems.Count()
                                                  TimeServed = 10
                                              }).ToList()
                                              //since FoodItems is not IEnummerable or IQueryable you have to convert it to a list by using ToList() method
                              };
                return results.ToList();
            }


        }
    }
    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public List<MenuCategoryFoodItemsPOCO> MenuCategoryFoodItemsPOCO_Get()
    {
        using (var context = new eRestaurantContext())
        {

            var results = from food in context.Items
                          orderby food.MenuCategory.Description
                          select new MenuCategoryFoodItemsPOCO
                          {
                              MenuCategoryDescription = food.MenuCategory.Description,
                              ItemID = food.ItemID,
                              FoodDescription = food.Description,
                              CurrentPrice = food.CurrentPrice,
                              //TimeServed = food.BillItems.Count()
                              TimeServed = 10
                          };
            return results.ToList();
        }
    }
}
   
}
