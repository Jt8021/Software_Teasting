using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class DataHandler
    {
        public int MethodUnderTest()
        {
            return 10; // Example return value
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public string GetAccountStatus(decimal balance)
        {
            if (balance < 0) return "Overdrawn";
            if (balance == 0) return "Zero Balance";
            return "In Credit";
        }
    }
}
