using System;
using System.Collections.Generic;

namespace AllZombiesApp
{
    class Program
    {
        private static List<Round> rounds = new List<Round>();

        static void Main(string[] args)
        {
            ZombieWalk();
            PrintData();
            CarculateAverage();
            Console.ReadLine();
        }
        
        private static void ZombieWalk()
        {
            for (int x = 1; x < 11; x++)
            {
                int[] houses = new int[100];

                for (int f = 0; f < houses.Length; f++) //This for loop is here to fill the array with the value 1 
                {
                    houses[f] = 1;
                }

                int zombieCounter = 1;
                int humansCounter = 100;
                int roundCounter = 1;
                int humanTurndThisRound;

                while (humansCounter > 0)
                {
                    humanTurndThisRound = 0;
                    for (int i = 0; i < zombieCounter; i++)
                    {
                        Random rnd = new Random();
                        int randomNumber = rnd.Next(0, 100);

                        if (houses[randomNumber] == 1)
                        {
                            houses[randomNumber] = 0;
                            humanTurndThisRound++;
                        }
                    }
                    roundCounter++;
                    zombieCounter += humanTurndThisRound;
                    humansCounter -= humanTurndThisRound;
                }

                rounds.Add(new Round { NumberOfRounds = roundCounter });
            }
        }
        
        private static void PrintData()
        {
            foreach (var round in rounds)
            {
                Console.WriteLine($"Alla människor förvandlades till zombies efter {round.NumberOfRounds} rundor.");
            }
        }

        private static void CarculateAverage()
        {
            double sum = 0;
            double avg = 0;
            double[] numberRounds = new double[rounds.Count];
            int index = 0;

            foreach (var round in rounds)
            {
                numberRounds[index] = round.NumberOfRounds;
                index++;
            }

            for (int i = 0; i < numberRounds.Length; i++)
            {
                sum += numberRounds[i];
            }

            avg = sum / numberRounds.Length;

            Console.WriteLine($"Summan är: {sum}");
            Console.WriteLine($"Snittet är: {avg}");
        }
    }
}
