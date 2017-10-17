using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment4
{
    public class DataService
    {
        NorthwindContext db = new NorthwindContext();

        // Order 

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

        public List<dynamic> GetOrdersByShipName(string ShipName)
        {
            return db.Orders.Where(x => x.ShipName.Equals(ShipName)).Select(x => new { x.Id, x.Date, x.ShipName, x.ShipCity }).ToList<dynamic>();
        }

        public List<dynamic> GetOrders()
        {
            return db.Orders.Select(x => new { x.Id, x.Date, x.ShipName, x.ShipCity }).ToList<dynamic>();
        }

        // Order details

        public List<OrderDetails> GetOrderDetailsByOrderId(int Id)
        {
            return db.OrderDetails.Where(x => x.OrderId == Id).Include(x => x.Product).Include(x => x.Order).ToList<OrderDetails>();
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int Id)
        {
            return db.OrderDetails.Where(x => x.ProductId == Id).Include(x => x.Product).Include(x => x.Order).ToList<OrderDetails>();
        }

        // Product

        public Product GetProduct(int Id)
        {
            return db.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == Id);
        }

        public List<Product> GetProductsBySubstring(string query)
        {
            return db.Products.Include(x => x.Category).Where(x => x.Name.ToLower().Contains(query.ToLower())).ToList<Product>();
        }

        public List<Product> GetProductsByCategoryId(int Id)
        {
            return db.Products.Include(x => x.Category).Where(x => x.Category.Id == Id).ToList<Product>();
        }

        // Category

        public Category GetCategory(int Id)
        {
            return db.Categories.Find(Id);
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList<Category>();
        }

        public Category AddCategory(string Name, string Description)
        {
            Category category = new Category { Name = Name, Description = Description };
            category = db.Categories.Add(category).Entity;
            db.SaveChanges();
            return category;            
        }

        public bool UpdateCategory(int Id, string Name, String Description)
        {
            Category category = db.Categories.Find(Id);
            if (category == null) return false;
            else
            {
                category.Name = Name;
                category.Description = Description;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteCategory(int Id)
        {
            Category category = db.Categories.Find(Id);
            if (category == null) return false;
            else
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
        }

    }
}
