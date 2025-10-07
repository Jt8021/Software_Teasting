using System;
using System.Collections.Generic;

namespace IMSApp
{
    public class Product
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public int StockLevel { get; set; }
        public decimal Price { get; set; }

        public Product(string id, string name, int stockLevel, decimal price)
        {
            ProductID = id;
            Name = name;
            StockLevel = stockLevel;
            Price = price;
        }
    }

    public class InventoryManager
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine($"Product {product.Name} added.");
        }

        public bool UpdateProduct(string id, int newStockLevel, decimal newPrice)
        {
            Product product = products.Find(p => p.ProductID == id);
            if (product != null)
            {
                product.StockLevel = newStockLevel;
                product.Price = newPrice;
                Console.WriteLine($"Product {product.Name} updated.");
                return true;
            }
            return false;
        }

        public bool RemoveProduct(string id)
        {
            Product product = products.Find(p => p.ProductID == id);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine($"Product {product.Name} removed.");
                return true;
            }
            return false;
        }

        public Product GetProductById(string id)
        {
            return products.Find(p => p.ProductID == id);
        }

        public void MonitorStockLevels()
        {
            foreach (var product in products)
            {
                if (product.StockLevel < 5)
                {
                    Console.WriteLine($"Low stock alert for {product.Name}!");
                }
            }
        }

        public void GenerateReport()
        {
            Console.WriteLine("Inventory Report:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} | {product.Name} | Stock: {product.StockLevel} | Price: {product.Price:C}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();

            manager.AddProduct(new Product("101", "Laptop", 10, 1500.00m));
            manager.AddProduct(new Product("102", "Mouse", 2, 25.00m));
            manager.UpdateProduct("102", 5, 22.50m);
            manager.RemoveProduct("101");

            manager.MonitorStockLevels();
            manager.GenerateReport();
        }
    }
}
