using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    class OrderDetails
    {
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public virtual int OrderId { get; set; }
        public virtual int ProductId { get; set; }
    }
}
