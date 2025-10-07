using System.Collections.Generic;
using Xunit;
using IMSApp;
using InventoryManagmentSystem;

namespace xUnitTesting
{
    public class AddProductToInventory_Test
    {
        [Fact]
        public void AddProductToInventory_ShouldAddProductCorrectly()
        {
            // Arrange
            var dataHandler = new DataHandler();
            string productId = "201";
            string productName = "Keyboard";
            int stockLevel = 15;
            decimal price = 50.00m;

            // Act
            bool result = dataHandler.AddProductToInventory(productId, productName, stockLevel, price);

            // Assert
            Assert.True(result);
            var product = dataHandler.RetrieveProductById(productId);
            Assert.NotNull(product);
            Assert.Equal(productId, product.ProductID);
            Assert.Equal(productName, product.Name);
            Assert.Equal(stockLevel, product.StockLevel);
            Assert.Equal(price, product.Price);
        }
    }
}