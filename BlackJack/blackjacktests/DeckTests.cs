using System;
using NUnit.Framework;
using BlackJack;

namespace BlackJackTests
{
    class DeckTests
    {
        [Test]
        public void Deck_Contrains52() //check to see if i'm creating a full 52 card deck.
        {
            //Arange
            Deck deck = new Deck();
            int sizeOfDeck = deck.ShuffledDeck.Length;
            bool returnsExpectedValue;

            //Act
            if (sizeOfDeck == 52)
                returnsExpectedValue = true;
            else
                returnsExpectedValue = false;

            //Assert
            Assert.IsTrue(returnsExpectedValue);
        }
    }
}