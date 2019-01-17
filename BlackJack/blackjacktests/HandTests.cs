using System;
using NUnit.Framework;
using BlackJack;

namespace Tests
{
    class HandTests
    {
        [Test]

        public void BlackJack_HandWithAce_GivesCorrectValue([Values(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21)] int value) //check to see a hand gives the correct value when it contains an ace.
        {
            //Arange
            Hand hand = new Hand();
            hand.HandValue = value;
            bool returnsExpectedValue;
            hand.HasAnAce = true;
            int finalScore = hand.FinalScore();

            //Act
            if (value < 12 && finalScore == value + 10)
                returnsExpectedValue = true;
            else if (value > 11 && finalScore == value)
                returnsExpectedValue = true;
            else
                returnsExpectedValue = false;

            //Assert
            Assert.IsTrue(returnsExpectedValue);
        }
    }
}