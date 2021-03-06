﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4.PartII
{
    public class Order
    {
        [Column("OrderId")]
        public int Id { get; set; }
        [Column("OrderDate")]
        public DateTime Date { get; set; }
        [Column("RequiredDate")]
        public DateTime Required { get; set; }
        // Added in PartII
        // needs to be nullable or else fails the test because Shipped can be null
        [Column("ShippedDate")]
        public DateTime? Shipped { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
