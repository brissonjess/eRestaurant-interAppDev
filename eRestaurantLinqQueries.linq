<Query Kind="Expression" />

from food in Items
	group food by new {food.MenuCategory.Description} into tempdataset
	select new{
				MenuCategoryDescription = tempdataset.Key.Description,
				
				FoodItems = from x in tempdataset
							select new{
										ItemID = x.ItemID,
										FoodDescription = x.Description,
										CurrentPrice = x.CurrentPrice,
										//TimeServed = x.BillItems.Count()
										TimeServed = 10
							};
	}
	
	
from food in Items
	orderby food.MenuCategory.Description
	select new{
				MenuCategoryDescription = food.MenuCategory.Description,
				ItemID = food.ItemID,
				FoodDescription = food.Description,
				CurrentPrice = food.CurrentPrice,
				TimeServed = food.BillItems.Count()
	}