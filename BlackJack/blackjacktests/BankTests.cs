using System;
using NUnit.Framework;
using BlackJack;

namespace BlackJackTests
{

    class BankTests
    {
        [Test]
        public void Bank_Input_InputsCorrectValue([Values("1000", "2000", "3000", "4000", "5000")] string input) //check to see if bank inputs increase my bank balance.
        {
            //Arange
            Bank bank = new Bank(input);
            int userInput = Int32.Parse(input);
            bool returnsExpectedValue;

            //Act
            if (bank.Balance == userInput)
                returnsExpectedValue = true;
            else
                returnsExpectedValue = false;

            //Assert
            Assert.IsTrue(returnsExpectedValue);
        }
    }
}
