using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class RandomFighter<T> where T : struct, IComparable<T>
    {
        private Deck<T> deck;
        private Dice<T> dice;

        private int deckWins, diceWins, ties;
        public RandomFighter(Deck<T> deck, Dice<T> dice) 
        { 
            this.deck = deck;
            this.dice = dice;

            InitializeRandomFighter();
        }

        private void InitializeRandomFighter()
        {
            while(deck.TryDraw(out T card))
            {
                var diceRoll = dice.Roll();

                int result = diceRoll.CompareTo(card);

                switch (result)
                {
                    case 0:
                        ties += 1;
                        break;

                    case 1:
                        diceWins += 1;  
                        break;

                    case -1:
                        deckWins += 1;
                        break;
                }
            }
            Console.WriteLine($"deck wins : {deckWins}");
            Console.WriteLine($"Dice wins : {diceWins}");
            Console.WriteLine($"Ties : {ties}");
        }

        
    }
}
