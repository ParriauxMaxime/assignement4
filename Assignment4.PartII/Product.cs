using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4.PartII
{
    public class Product
    {
        [Column("ProductId")]
        public int Id { get; set; }
        [Column("ProductName")]
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        [Column("QuantityUnit")]
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        
        // Added in PartII
        public string CategoryName => Category.Name;
        public string ProductName => Name;
    }
}
