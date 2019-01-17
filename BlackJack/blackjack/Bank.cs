using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Bank
    {
        public int Balance; //not using a property as I want to use this with the REF keyword in my program

        public Bank() //parameterless constructor
        {
            this.Balance = 1000;
            Console.WriteLine("Error Processing Bank Amount. Default balance given: €" + Balance);
        }

        public Bank(string balanceInput) //counstructor i'm going to use, parses user input.
        {
            bool balanceParse = Int32.TryParse(balanceInput, out int balance);
            if (balanceParse)
            {
                this.Balance = balance;
            }
            else
            {
                this.Balance = 1000;
                Console.WriteLine("Error Processing Bank Amount. Default balance given: €" + Balance);
            }
        }

        public void DisplayBalance() //display balance at the start and end of hand - user sees net effect of his bet.
        {
            Console.WriteLine("Players Balance is €" + Balance);
            Console.WriteLine("Good Luck!");
        }
    }
}

