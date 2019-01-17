using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black; //inver color scheme
            Console.OutputEncoding = System.Text.Encoding.UTF8; //needed for euro symbol

            Console.Write("Please enter desired player balance: €");
            Bank bank = new Bank(Console.ReadLine()); //give the player a bank balance to play with
            Console.WriteLine();
            string menuInput;

            while (bank.Balance > 0)//we'll play until the player is broke or quits
            {
                Deck MyDeck = new Deck(); //deck of 52 cards using my class.
                Hand myHand = new Hand(); //players hand
                Hand dealerHand = new Hand(); //dealers hand
                int cardCount = 1; //tells my list what card is next
                int bet = 0; //reset my bet to 0


                Console.WriteLine("*****NEW HAND*****");
                Console.WriteLine("*****DEALER STANDS ON SOFT 17*****"); //means dealer sticks on 17 whether holding an ace or not.
                bank.DisplayBalance();

                do
                {
                    bet = Bet();
                    if (bet > bank.Balance)
                        Console.WriteLine("Can't bet more than balance");
                } while (bet > bank.Balance); //loop to get a bet amount less than bank

                Console.WriteLine();
                Card.DealCard(MyDeck.ShuffledDeck[0]);
                myHand.AddCards(MyDeck.ShuffledDeck[0]);

                Card.DealCard(MyDeck.ShuffledDeck[1]);
                myHand.AddCards(MyDeck.ShuffledDeck[1]);
                myHand.DisplayValue(); //deal 2 cards to player, add them to hand value, then display value.

                while (myHand.HandValue < 21) //player can twist until he hits 21 or goes bust.
                {
                    bool twist = StickOrTwist(ref cardCount); //bool stick or twist. cardcount increases with each twist to keep my place in the deck.
                    if (twist == true)
                    {
                        Card.DealCard(MyDeck.ShuffledDeck[cardCount]);
                        myHand.AddCards(MyDeck.ShuffledDeck[cardCount]);
                        myHand.DisplayValue(); //deal 1 card to player, add them to hand value, then display value - takes into account if hand has ace.
                    }
                    else
                        break; //when twist == false - BREAK out of while loop.
                }

                Console.WriteLine();
                if (myHand.FinalScore() > 21)
                {
                    Console.WriteLine("Player Busts - Dealer Wins"); //end the hand if player has bust.
                    Console.WriteLine("Dealer wins - (Bank -€" + bet + ")");
                    bank.Balance = bank.Balance - bet;
                    Console.WriteLine("New Bank Balance: €" + bank.Balance); //display new balance.
                }
                else //if the players hasn't bust...dealer plays
                {
                    Console.WriteLine("Dealer's Hand");
                    cardCount++;
                    Card.DealCard(MyDeck.ShuffledDeck[cardCount]);
                    dealerHand.AddCards(MyDeck.ShuffledDeck[cardCount]);

                    cardCount++;
                    Card.DealCard(MyDeck.ShuffledDeck[cardCount]);
                    dealerHand.AddCards(MyDeck.ShuffledDeck[cardCount]);
                    dealerHand.DisplayValue(); //deal next two cards in the deck to dealer, add to his handvalue and display.

                    while (dealerHand.FinalScore() < 17) //dealer keeps hitting until he's 17 or more, my method checks for ace.
                    {
                        cardCount++;
                        Card.DealCard(MyDeck.ShuffledDeck[cardCount]);
                        dealerHand.AddCards(MyDeck.ShuffledDeck[cardCount]);
                        dealerHand.DisplayValue();

                        if (dealerHand.HandValue > 21)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Dealer Busts - Player Wins"); //if dealer busts player wins.
                            Console.WriteLine("Player wins - (Bank +€" + bet + ")");
                            bank.Balance = bank.Balance + bet;
                            Console.WriteLine("New Bank Balance: €" + bank.Balance); //dis[lay new balance
                        }
                    }
                }

                Console.WriteLine();

                if (myHand.FinalScore() < 22 && dealerHand.FinalScore() < 22)
                    Hand.CalculateWinner(myHand.FinalScore(), dealerHand.FinalScore(), ref bank.Balance, bet); //displays who won if neither player busts.

                Console.WriteLine();
                menuInput = Menu(); //menu on finishing hand. checks what players wants to do.

                if (menuInput == "X") //quit
                    break;

                if (menuInput == "D") //prints remainding cards in deck to the screen.
                {
                    Console.WriteLine();
                    MyDeck.PrintRemainderOfShuffledDeck(cardCount);
                    Console.WriteLine();
                    Console.WriteLine("Press Any key to play again");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (menuInput == "P") //play again
                    Console.Clear();
            }
        }

        public static bool StickOrTwist(ref int CardCount) //checks if user wants to stick or twist.
        {
            string selection;

            while (true)
            {
                Console.Write("Stick or Twist? (s/t)");

                selection = Console.ReadLine().ToLower();
                if (selection == "t")
                {
                    CardCount++; //deals next card if we twist.
                    return true;
                }
                else if (selection == "s") //stick. moves on to dealers hand.
                    return false;
            }
        }

        public static int Bet() //takes users bet amount preference.
        {
            bool betParse; //try parse in order to stop programming crashing with bad user input.
            int betAmount;
            Console.Write("Enter bet amount: €");
            betParse = Int32.TryParse(Console.ReadLine(), out betAmount);

            if (betParse)
                return betAmount;
            else
            {
                Console.WriteLine("Invalid bet amount: Default bet of €5 placed.");
                return 5;
            }
        }

        public static string Menu() //menu displayed to user to see what they want to do next. restricts user to 3 options.
        {
            Console.WriteLine("P to play again | D to display remainder of deck | X to quit");
            while (true)
            {
                string userInput = Console.ReadLine().ToUpper();
                if (userInput == "P")
                    return "P";
                else if (userInput == "D")
                    return "D";
                else if (userInput == "X")
                    return "X";
                else
                    Console.WriteLine("Invalid Input - Please try Again");
            }
        }
    }
}
