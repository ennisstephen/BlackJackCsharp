using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        public Card[] ShuffledDeck = new Card[52]; //array which holds shuffled deck

        public Deck() //construct an unshuffled array of 52 cards.
        {
            Card[] unshuffledDeck = new Card[52];

            for (int i = 0; i < 52; i++)
            {
                if (i <= 12)
                {
                    Card card = new Card(1, (i + 1));
                    unshuffledDeck[i] = card;
                }
                if (i > 12 && i <= 25)
                {
                    Card card = new Card(2, (i - 12));
                    unshuffledDeck[i] = card;
                }
                if (i > 25 && i <= 38)
                {
                    Card card = new Card(3, (i - 25));
                    unshuffledDeck[i] = card;
                }
                if (i > 38 && i <= 51)
                {
                    Card card = new Card(4, (i - 38));
                    unshuffledDeck[i] = card; //13 hards of each suit (52 cards) put into an array.
                }
            }
            this.ShuffledDeck = ShuffleDeck(unshuffledDeck); //create a shuffled deck of 52 cards and return it.

        }

        public static Card[] ShuffleDeck(Card[] unshuffledDeck) //method to create a shuffled deck. decided to use method instead of put this in the constructor because didn't want to overcomplicate my constructor.

        {
            Card[] shuffledArray = new Card[52]; //my shuffled array
            Random rand = new Random(); //need this to shuffle
            int myRand; //this is for my Random.Next

            int j = 0;
            while (j < 52) //my loop
            {
                myRand = rand.Next(52); //shuffle
                if (shuffledArray[myRand] == null) //will keep shuffling until it finds a null space in the list
                {
                    shuffledArray[myRand] = unshuffledDeck[j]; //put the card in the empty space
                    j++; //need this to eventually break out of my while loop
                }
            }
            return shuffledArray;
        }

        public void PrintRemainderOfShuffledDeck(int cardCount) //allows my user to print the remainder of the deck at the end of his/her hand.
        {
            cardCount++; //we need to move the cardCount up one
            for (int i = 0; i < 52 - cardCount; i++)
                Console.WriteLine(ShuffledDeck[i]); //print the rest of the cards in the deck
        }
    }
}

