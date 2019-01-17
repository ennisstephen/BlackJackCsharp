using System;
using NUnit.Framework;
using BlackJack;

namespace BlackJackTests
{
    class CardTests
    {
        [Test]
        public void BlackJack_FinalScore_ReturnsCorrectValue([Values(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13)] int input) //check all cards have the correct value
        {
            //Arange
            Card card = new Card(1, input);
            bool returnsExpectedValue;

            //Act
            if (input < 11 && card.Value == input)
                returnsExpectedValue = true;
            else if (input > 10 && card.Value == 10)
                returnsExpectedValue = true;
            else
                returnsExpectedValue = false;

            //Assert
            Assert.IsTrue(returnsExpectedValue);
        }
    }
}