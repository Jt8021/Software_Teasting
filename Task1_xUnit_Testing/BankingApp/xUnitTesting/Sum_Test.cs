using Xunit;
using BankingApp;

namespace xUnitTesting
{
    public class Sum_Test
    {
      [Fact]
        public void Sum_ShouldReturnCorrectSum_ForPositiveIntegers()
        {
          // Arrange
          var dataHandler = new DataHandler();
          int a = 5;
          int b = 3;

          // Act
          int result = dataHandler.Sum(a, b);

          // Assert
          Assert.Equal(8, result);
        }

        [Fact]
        public void Sum_ShouldReturnCorrectSum_ForNegativeIntegers()
        {
          // Arrange
          var dataHandler = new DataHandler();
          int a = -5;
          int b = -3;

          // Act
          int result = dataHandler.Sum(a, b);

          // Assert
          Assert.Equal(-8, result);
        }

        [Fact]
        public void Sum_ShouldReturnZero_ForZeroValues()
        {
          // Arrange
          var dataHandler = new DataHandler();
          int a = 0;
          int b = 0;

          // Act
          int result = dataHandler.Sum(a, b);

          // Assert
          Assert.Equal(0, result);
        }    
    }
}
