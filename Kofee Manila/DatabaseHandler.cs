using LiteDB;
using System;
using System.Data;
using System.Linq;

namespace Kofee_Manila
{
    public class DatabaseHandler
    {
        private string databasePath = @"Orders.db";

        public class Order
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Cost { get; set; }
        }

        public DataTable GetOrders()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("product", typeof(string));
            dataTable.Columns.Add("qty", typeof(int));
            dataTable.Columns.Add("cost", typeof(double));

            using (var db = new LiteDatabase(databasePath))
            {
                var orders = db.GetCollection<Order>("Orders").FindAll();
                foreach (var order in orders)
                {
                    dataTable.Rows.Add(order.Id, order.ProductName, order.Quantity, order.Cost);
                }
            }

            return dataTable;
        }

        public void AddOrders(string product, int quantity, double cost)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var orders = db.GetCollection<Order>("Orders");
                var order = orders.FindOne(o => o.ProductName == product);

                if (order != null)
                {
                    order.Quantity += quantity;
                    order.Cost += cost;
                    orders.Update(order);
                }
                else
                {
                    orders.Insert(new Order
                    {
                        ProductName = product,
                        Quantity = quantity,
                        Cost = cost
                    });
                }
            }
        }

        public void ClearOrders()
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var orders = db.GetCollection<Order>("Orders");
                orders.DeleteAll();
            }
        }

        public void RemoveOrder(int id)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var orders = db.GetCollection<Order>("Orders");
                orders.Delete(id);
            }
        }

        public void UpdateQuantityAndCost(int id, int quantity, double cost)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var orders = db.GetCollection<Order>("Orders");
                var order = orders.FindById(id);
                if (order != null)
                {
                    order.Quantity = quantity;
                    order.Cost = cost;
                    orders.Update(order);
                }
            }
        }

        public double GetTotalAmount()
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var orders = db.GetCollection<Order>("Orders");
                return orders.FindAll().Sum(o => o.Cost);
            }
        }

        private bool ProductExists(string product)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var orders = db.GetCollection<Order>("Orders");
                return orders.Exists(o => o.ProductName == product);
            }
        }

        private (int Id, int Quantity, double Cost) GetProductDetails(string product)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var orders = db.GetCollection<Order>("Orders");
                var order = orders.FindOne(o => o.ProductName == product);
                if (order != null)
                {
                    return (order.Id, order.Quantity, order.Cost);
                }
                throw new Exception("Product not found.");
            }
        }
    }
}
