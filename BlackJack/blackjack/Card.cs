using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        private string Face { get; set; }
        public int Value { get; set; } //my properties
        private string Suit { get; set; }

        public Card() //parameterless constructor for best practices.
        {
            this.Suit = "Invalid Suit";
            this.Face = "Invalid Value";
            this.Value = 100; //give a value that busts player if no arguments provided.

        }

        public Card(int suit, int face) //constructor i'll use.
        {
            if (suit == 1)
                this.Suit = "of Spades";
            else if (suit == 2)
                this.Suit = "of Clubs";
            else if (suit == 3)
                this.Suit = "of Hearts";
            else if (suit == 4)
                this.Suit = "of Diamonds"; //use an int to get my suit.
            else
                this.Suit = "Invalid suit";

            if (face == 1)
            {
                this.Face = "Ace";
                Value = 1;
            }
            else if (face == 11)
            {
                this.Face = "Jack";
                Value = face - 1;
            }
            else if (face == 12)
            {
                this.Face = "Queen";
                Value = face - 2;
            }
            else if (face == 13)
            {
                this.Face = "King";
                Value = face - 3; //use an int to get my face...big cards.
            }
            else
            {
                this.Face = face.ToString();
                Value = face;  //use an int to get my face...small cards.
            }
        }

        public static void DealCard(Card card) //cosmestics of dealing a card
        {
            Console.WriteLine("Card dealt is " + card); //deal my card.
        }

        public override string ToString()
        {
            return String.Format(Face + " " + Suit); //allow me to print cards to console easily - use this in DealCard method.
        }
    }
}