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

                var people = Enumerable.Range(0, peopleCount).ToList();
                int index = 0;
                int person = 0;
                Console.Write($"Case #{c}:");
                do
                {
                    person = people[index];
                    if (amounts[person] > 0)
                    {
                        amounts[person] -= max;
                    }
                    if (amounts[person] <= 0)
                    {
                        Console.Write($" {person + 1}");
                        people.RemoveAt(index);
                        if (index == people.Count())
                        {
                            index = 0;
                        }
                    }
                    else
                    {
                        index=(index+1)%people.Count();
                    }
                } while (people.Count() > 0);
                Console.WriteLine();
            }
            //bool done = true;
        }

    }
}
