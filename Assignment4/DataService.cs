using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {
        NorthwindContext db = new NorthwindContext();

        public Order GetOrder(int Id)
        {
            var order = db.Orders.Include(x => x.OrderDetails).FirstOrDefault(y => y.Id == Id);

            foreach (var od in order.OrderDetails)
            {
                od.Order = order;
                od.Product = db.Products.Include(x => x.Category).FirstOrDefault(y => y.Id == od.ProductId);
            }
            return order;
        }

        public static void Main(string[] args)
        {
            
            DataService dv = new DataService();
            var order = dv.GetOrder(10248);
            Console.WriteLine(order.ShipCity);
            foreach (var od in order.OrderDetails)
            {
                Console.WriteLine(od.Product.Name + ", " + od.Product.Category.Name);
                
            }
        }

    }
}
