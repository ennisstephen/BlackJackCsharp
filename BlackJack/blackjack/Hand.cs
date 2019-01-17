using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Hand
    {
        public int HandValue { get; set; }
        public bool HasAnAce { get; set; } //my properties.

        public Hand() //creates the users or players hand.
        {
        }

        public void AddCards(Card card)
        {
            HandValue = HandValue + card.Value;
            if (card.Value == 1)
                HasAnAce = true; //add the value of card to my hand and check for ace.
        }

        public void DisplayValue() //display the value of the hand - cosmetic only.
        {
            if (HandValue < 12 && HasAnAce == true)
                Console.WriteLine("Hand value is " + (HandValue + 10) + " or " + HandValue); //display 2 values of a hand with an ace. if an 11 busts the player don't display higher value.
            else
                Console.WriteLine("Hand value is " + HandValue); //display the value of a hand without an ace.
        }

        public int FinalScore() //calculates the actual value of hand for comparison purposes.
        {
            if (HandValue < 12 && HasAnAce == true)
                return HandValue + 10; //calc the score at the end of a hand if it has a useable ace.
            else
                return HandValue;
        }

        public static void CalculateWinner(int playerFinalScore, int dealerFinalScore, ref int bank, int bet) //calculate winner if neither player busts and change bank.
        {
            Console.WriteLine("Player's Score is " + playerFinalScore);
            Console.WriteLine("Dealer's Score is " + dealerFinalScore);

            if (dealerFinalScore == playerFinalScore)
                Console.WriteLine("PUSH"); //a draw - no change to bank

            else if (dealerFinalScore < playerFinalScore) //player wins bank increases.
            {
                bank = bank + bet;
                Console.WriteLine("Player wins - (Bank +€" + bet + ")");
            }
            else //players loses bank decreases.
            {
                bank = bank - bet;
                Console.WriteLine("Dealer wins - (Bank -€" + bet + ")");

            }
            Console.WriteLine("New Bank Balance: €" + bank);
        }
    }
}
