﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
   public class Products
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public decimal Price{ get; set; }
        public string? Image{  get; set; }

        [ForeignKey(nameof(Category))]
        public int Category_Id { get; set; }
        
        public virtual Categories? Category { get; set; }
        
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; } = new HashSet<OrderDetails>();
    }
}
