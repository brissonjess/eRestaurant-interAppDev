using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.Data.Entity;
using eRestaurantSystem.Data.Entities;
#endregion

namespace eRestaurantSystem.DAL
{
    internal class eRestaurantContext:DbContext
    {
        public eRestaurantContext():base("eRestaurantDB")
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<MenuCategory> NewCategories { get; set; }

    }
}
