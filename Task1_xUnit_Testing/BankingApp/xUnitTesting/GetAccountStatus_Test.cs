using Xunit;
using BankingApp;

namespace xUnitTesting
{
    public class GetAccountStatus_Test
    {
        [Fact]
        public void GetAccountStatus_ShouldReturnOverdrawn_ForNegativeBalance()
        {
            // Arrange
            var dataHandler = new DataHandler();
            decimal balance = -50m;

            // Act
            string status = dataHandler.GetAccountStatus(balance);

            // Assert
            Assert.Equal("Overdrawn", status);
        }

        [Fact]
        public void GetAccountStatus_ShouldReturnZeroBalance_ForZeroBalance()
        {
            // Arrange
            var dataHandler = new DataHandler();
            decimal balance = 0m;

            // Act
            string status = dataHandler.GetAccountStatus(balance);

            // Assert
            Assert.Equal("Zero Balance", status);
        }

        [Fact]
        public void GetAccountStatus_ShouldReturnInCredit_ForPositiveBalance()
        {
            // Arrange
            var dataHandler = new DataHandler();
            decimal balance = 100m;

            // Act
            string status = dataHandler.GetAccountStatus(balance);

            // Assert
            Assert.Equal("In Credit", status);
        }
    }
}
