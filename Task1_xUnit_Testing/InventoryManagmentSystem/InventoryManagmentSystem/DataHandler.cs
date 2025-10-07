using IMSApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem
{
    public class DataHandler
    {
        private InventoryManager _inventoryManager;

        public DataHandler()
        {
            _inventoryManager = new InventoryManager();
        }

        public bool AddProductToInventory(string id, string name, int stockLevel, decimal price)
        {
            var product = new Product(id, name, stockLevel, price);
            _inventoryManager.AddProduct(product);
            return _inventoryManager.GetProductById(id) != null;
        }

        public bool UpdateProductInInventory(string id, int stockLevel, decimal price)
        {
            return _inventoryManager.UpdateProduct(id, stockLevel, price);
        }

        public bool RemoveProductFromInventory(string id)
        {
            return _inventoryManager.RemoveProduct(id);
        }

        public Product RetrieveProductById(string id)
        {
            return _inventoryManager.GetProductById(id);
        }

        public List<Product> RetrieveAllProducts()
        {
            // Exposing internal list of products for testing purposes.
            var allProducts = new List<Product>();

            var productProperties = typeof(InventoryManager).GetField("products", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (productProperties != null)
            {
                allProducts = (List<Product>)productProperties.GetValue(_inventoryManager);
            }

            return allProducts;
        }
    }
}
