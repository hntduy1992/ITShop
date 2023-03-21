﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITShop.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}

        //Product n - n Category
        public IList<ProductInCategory> ProductInCategories { get; set; }
    }
}
