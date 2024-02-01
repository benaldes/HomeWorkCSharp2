using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Game
    {
        
        List<Unit> Side1 = new List<Unit>();
        List<Unit> Side2 = new List<Unit>();
        List<WeatherEffect> weatherList = new List<WeatherEffect>();
        
        int Side1Loot = 0;
        int Side2Loot = 0;
        static void Main(string[] args)
        {
            Game game = new Game();
            
            game.InitGame();
        }
        public void InitGame()
        {
            var random = new Random();
            weatherList.Add(WeatherEffect.Rain);
            weatherList.Add(WeatherEffect.Heatwave);
            weatherList.Add(WeatherEffect.Snow);
            weatherList.Add(WeatherEffect.Thunderstorm);
            List<Unit> HumanSide = new List<Unit>();
            List<Unit> FishSide = new List<Unit>();
            
            while(Side1.Count < 3) 
            {
                int rend = random.Next(3);
                switch (rend)
                {
                    case 0:
                        Side1.Add(new HumenSniper());
                        break;
                    case 1:
                        Side1.Add(new HumenGambler());
                        break;
                    case 2:
                        Side1.Add(new HumenWarrior());
                        break;
                }


            }
            while (Side2.Count < 3)
            {
                int rend = random.Next(3);
                switch (rend)
                {
                    case 0:
                        Side2.Add(new FishmanFish());
                        break;
                    case 1:
                        Side2.Add(new FishmanShark());
                        break;
                    case 2:
                        Side2.Add(new FishmanSquid());
                        break;
                }


            }

            StartGame();

        }
        public void StartGame()
        {
            var random = new Random();
            while (Side1.Count > 0 && Side2.Count > 0) 
            {
                int WeatherChance = random.Next(0, 2);
                int Weather = random.Next(0,weatherList.Count);
                int weatherCount = random.Next(0, 3);
                if(WeatherChance == 0)
                {
                    Console.WriteLine($"the Weather is  {weatherList[Weather]} for {weatherCount} turns");
                }
                int index1 = random.Next(0, Side1.Count);
                int index2 = random.Next(0, Side2.Count);
                

                Side1[index1].Attack(Side2[index2]);
                if (Side2[index2].IsDead == true)
                {
                    Side1Loot += Side2[index2].carryingCapacity;
                    Side2.Remove(Side2[index2]);
                }
                    
                index1 = random.Next(0, Side1.Count);
                if(Side2.Count == 0 )
                {
                    break;
                }
                index2 = random.Next(0, Side2.Count);
                Side2[index2].Attack(Side1[index1]);
                if (Side1[index1].IsDead == true)
                {
                    Side2Loot += Side1[index1].carryingCapacity;
                    Side1.Remove(Side1[index1]);
                }

            }
            if(Side1.Count > Side2.Count)
            {
                Console.WriteLine($"Side 1 Won and got {Side1Loot} resources");
            }
            else 
            {
                Console.WriteLine($"Side 2 Won and got {Side2Loot} resources");
            }
        }
    }
}
