using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GoogleKickstartF
{
    class Program
    {
        static void Main(string[] args)
        {
            ATMQueue();

        }

        public static void ATMQueue()
        {
            int cases = int.Parse(Console.ReadLine());
            //int cases = 2;
            for (int c = 1; c < cases + 1; c++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int peopleCount = line[0];
                int max = line[1];
                var amounts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                //int max = 6;
                //int peopleCount = 5;
                //var amounts = new int[] { 9, 10, 4, 7, 2 };

                //var leftOrder = new List<int>();
                var people = Enumerable.Range(0, peopleCount).ToList();

                Console.Write($"Case #{c}:");
                do
                {
                    int person = people[0];
                    people.RemoveAt(0);
                    if (amounts[person] > 0)
                    {
                        amounts[person] -= max;
                    }
                    if (amounts[person] <= 0)
                    {
                        //leftOrder.Add(person + 1);
                        Console.Write($" {person + 1}");
                    }
                    else
                    {
                        people.Add(person);
                    }
                } while (people.Count() > 0);
                Console.WriteLine();
                //Console.WriteLine($"Case #{c}: {string.Join(" ", leftOrder)}");
            }
            //bool done = true;
        }

    }
}
