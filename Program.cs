using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowsAndBulls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("guess the 4 digit number");
                Random rand = new Random();
                HashSet<int> genNumbers = new HashSet<int>();
                int[] RanNumber = new int[4];
                for (int i = 0; i < RanNumber.Length; i++)
                {
                    int randomNumber;
                    do
                    {
                        randomNumber = rand.Next(0, 10);
                    }
                    while (genNumbers.Contains(randomNumber));

                    RanNumber[i] = randomNumber;
                    genNumbers.Add(randomNumber);
                }
                int attempts = 0;
                while (true)
                {
                    attempts++;
                    Console.WriteLine($"Attempt #{attempts}:");
                    string input = Console.ReadLine();
                    if (input.Length != 4 || !int.TryParse(input, out _))
                    {
                        Console.WriteLine("number is not 4 digits");
                        continue;
                    }
                    int[] guess = new int[4];
                    for (int i = 0; i < guess.Length; i++)
                    {
                        guess[i] = Convert.ToInt32(input[i].ToString());
                    }
                    int cows = 0;
                    int bull = 0;
                    for (int i = 0; i < guess.Length; i++)
                    {
                        if (guess[i] == RanNumber[i])
                        {
                            bull++;
                        }
                        else if (genNumbers.Contains(guess[i]))
                        {
                            cows++;
                        }
                    }
                    Console.WriteLine($"Cows: {cows}, Bulls: {bull}");
                    if (bull == 4)
                    {
                        Console.WriteLine("that is correct");
                    }
                }
            }
        }
    }
}
