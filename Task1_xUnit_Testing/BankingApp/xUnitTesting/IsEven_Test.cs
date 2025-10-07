using Xunit;
using BankingApp;

namespace xUnitTesting
{
    public class IsEven_Test
    {
        [Fact]
        public void IsEven_ShouldReturnTrue_ForEvenNumber()
        {
            // Arrange
            var dataHandler = new DataHandler();
            int number = 4;

            // Act
            bool result = dataHandler.IsEven(number);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEven_ShouldReturnFalse_ForOddNumber()
        {
            // Arrange
            var dataHandler = new DataHandler();
            int number = 5;

            // Act
            bool result = dataHandler.IsEven(number);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsEven_ShouldReturnTrue_ForZero()
        {
            // Arrange
            var dataHandler = new DataHandler();
            int number = 0;

            // Act
            bool result = dataHandler.IsEven(number);

            // Assert
            Assert.True(result);
        }
    }
}
