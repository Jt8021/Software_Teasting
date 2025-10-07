using Xunit;
using BankingApp;

namespace xUnitTesting
{
    public class WithdrawInsufficientFunds_Test
    {
        [Fact]
        public void Withdraw_ShouldReturnErrorMessage_ForInsufficientFunds()
        {
            // Arrange
            var account = new Account("123", "John", "Doe", 50m);

            // Act
            account.Withdraw(100m);

            // Assert
            Assert.Equal(50m, account.Balance); // Balance should remain unchanged
        }
    }
}
