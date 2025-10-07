using Xunit;
using BankingApp;

namespace xUnitTesting
{
    public class Transfer_Test
    {
        [Fact]
        public void Transfer_ShouldTransferFundsBetweenAccounts()
        {
            // Arrange
            var accountSender = new Account("101", "Alice", "Smith", 500m);
            var accountReceiver = new Account("102", "Bob", "Brown", 200m);

            // Act
            accountSender.Transfer(accountReceiver, 150m);

            // Assert
            Assert.Equal(350m, accountSender.Balance); // 500 - 150
            Assert.Equal(350m, accountReceiver.Balance); // 200 + 150
        }
    }
}
