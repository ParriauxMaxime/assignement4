using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    class Order
    {
        [Column("orderid")]
        public int Id { get; set; }
        [Column("orderdate")]
        public DateTime Date { get; set; }
        [Column("requireddate")]
        public DateTime Required { get; set; }
        [Column("shippeddate")]
        public DateTime Shipped { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
