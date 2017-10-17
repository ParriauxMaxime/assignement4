using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    class Product
    {
        [Column("productid")]
        public int Id { get; set; }
        [Column("productname")]
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        [Column("quantityunit")]
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
