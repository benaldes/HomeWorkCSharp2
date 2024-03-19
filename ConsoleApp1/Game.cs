namespace ConsoleApp1
{
    internal class Game
    {

       
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> deckCards = new List<int>();
            for (int i = 0; i < 40; i++) 
            {
                deckCards.Add(random.Next(21));
            }

            Deck<int> deck = new Deck<int> (deckCards);
            Dice dice = new Dice(1,20,0);
            RandomFighter<int> randomFighter = new RandomFighter<int>(deck,dice);

            
        }
       

      
    }
}
