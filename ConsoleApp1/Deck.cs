using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Deck<T> where T : struct, IComparable<T>  
    {
        public int Size;
        public int Remaining;

        private List<T> deck;
        private List<T> discardPile;

        public Deck(List<T> deck) 
        {
            Size = deck.Count;
            Remaining = Size;
            InitializeDeck(deck);
        }

        private void InitializeDeck(List<T> deck)
        {
            this.deck = deck;
            discardPile = new List<T>();

        }
        public void Shuffle()
        {
            Random random = new Random();
            deck = deck.OrderBy(x => random.Next()).ToList();
        }

        public void Reshuffle()
        {
            foreach(T item in discardPile)
            {
                deck.Add(item);
            }
            Remaining = Size;
        }

        public bool TryDraw(out T card)
        {
            if (deck.Count == 0)
            {
                card = default;
                return false;
            }

            card = deck[0];
            deck.RemoveAt(0);
            discardPile.Add(card);
            Remaining -= 1;
            return true;
        }

        public T Peek()
        {
            if (deck.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty.");
            }

            return deck[0];
        }
    }
}
