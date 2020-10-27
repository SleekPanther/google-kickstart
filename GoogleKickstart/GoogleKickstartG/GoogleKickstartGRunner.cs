using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleKickstartG
{
    public class GoogleKickstartGRunner
    {
        static void Main(string[] args)
        {
            (new GoogleKickstartGRunner()).Run();
        }
        public void Run()
        {
            //Console.WriteLine("G");
            //Kick_Start();   //Wrong answer
            //MaximumCoins(); //Wrong answer
            CombinationLock();
        }

        private void Kick_Start0()
        {
            //int cases = int.Parse(Console.ReadLine());
            int cases = 1;
            for (int c = 1; c < cases + 1; c++)
            {
                Console.Write($"Case #{c}: ");
                int occurences = 0;
                //string str = "AKICKSTARTPROBLEMNAMEDKICKSTART";
                //string str = "STARTUNLUCKYKICK";
                //string str = "KICKXKICKXSTARTXKICKXSTART";
                string str = "KICKSTARTKICK";
                //string str = Console.ReadLine();

                int kickIndex = str.IndexOf("KICK");
                int startIndex = str.IndexOf("START", kickIndex + 1);
                Console.WriteLine($"kick {kickIndex} start {startIndex}");
                while (kickIndex >= 0 && kickIndex < str.Length - 5 - 1)
                {
                    while (startIndex >= 0 && startIndex < str.Length - 1)
                    {
                        occurences++;
                        Console.WriteLine($"kick {kickIndex} start {startIndex}");
                        startIndex = str.IndexOf("START", startIndex + 1);
                    }
                    kickIndex = str.IndexOf("KICK", kickIndex + 1);
                    if (kickIndex >= 0)
                    {
                        startIndex = str.IndexOf("START", kickIndex + 1);
                    }
                }
                // 0 1 2 3 4 5 6 7 8
                // K I C K K I C K
                // K I C K S T A R T
                Console.WriteLine(occurences.ToString());
            }
        }

        private void Kick_Start()
        {
            int cases = int.Parse(Console.ReadLine());
            //int cases = 1;
            for (int c = 1; c < cases + 1; c++)
            {
                Console.Write($"Case #{c}: ");
                int occurences = 0;
                //string str = "AKICKSTARTPROBLEMNAMEDKICKSTART";
                //string str = "STARTUNLUCKYKICK";
                //string str = "KICKXKICKXSTARTXKICKXSTART";

                string str = Console.ReadLine();
                var kicks = new Dictionary<int, byte>();
                var starts = new Dictionary<int, byte>();
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == 'K' && i < str.Length  - 3 && str[i + 1] == 'I' && str[i + 2] == 'C' && str[i + 3] == 'K')
                    {
                        kicks[i] = 1;
                    }
                    else if (str[i] == 'S' && i < str.Length  - 4 && str[i + 1] == 'T' && str[i + 2] == 'A' && str[i + 3] == 'R' && str[i + 4] == 'T')
                    {
                        starts[i] = 1;
                    }
                }

                var startsArr = starts.Keys.ToArray();
                foreach(var kick in kicks.Keys.ToArray())
                {
                    var matches = startsArr.Where(start => start > kick).Count();
                    if (matches > 0)
                    {
                        occurences += matches;
                    }
                }
                Console.WriteLine(occurences.ToString());
            }
        }

        private void MaximumCoins()
        {
            int cases = int.Parse(Console.ReadLine());
            //int cases = 1;
            for (int c = 1; c < cases + 1; c++)
            {
                int dimension = int.Parse(Console.ReadLine());
                //int dimension = 5;
                int[][] m = new int[dimension][];
                int max = int.MinValue;
                int rowIndexWithMax = -1;
                int colIndexlWithMax = int.MinValue;
                int nonCornerMax = int.MinValue;
                int nonCornerRowIndex = -1;
                int nonCornerColIndex = -1;
                for (int i = 0; i < dimension; i++)
                {
                    var row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    m[i] = row;
                    for (int j = 0; j < dimension; j++)
                    {
                        if (m[i][j] > nonCornerMax && !(i == 0 && j == dimension - 1) && !(i == dimension - 1 && j == 0))
                        {
                            nonCornerMax = m[i][j];
                            nonCornerRowIndex = i;
                            nonCornerColIndex = j;
                        }
                    }
                }
                //Console.WriteLine($"max {max} ({rowIndexWithMax}, {colIndexlWithMax}) {Environment.NewLine}nonCornerMax {nonCornerMax} ({nonCornerRowIndex}, {nonCornerColIndex})");

                //rowIndexWithMax = -1;
                //max = int.MinValue;
                //int nonCornerMax = int.MinValue;
                ////Test case 1
                //m[0] = new[] { 1, 2, 5 };
                //m[1] = new[] { 3, 6, 1 };
                //m[2] = new[] { 12, 2, 7 };
                ////Test case 2
                //m[0] = new[] { 0, 0, 0, 0, 0 };
                //m[1] = new[] { 1, 1, 1, 1, 0 };
                //m[2] = new[] { 2, 2, 2, 8, 0 };
                //m[3] = new[] { 1, 1, 1, 0, 0 };
                //m[4] = new[] { 0, 0, 0, 0, 0 };
                //for (int i = 0; i < dimension; i++)
                //{
                //    for(int j = 0; j < dimension; j++)
                //    {
                //        //if (m[i][j] > max)
                //        //{
                //        //    max = m[i][j];
                //        //    rowIndexWithMax = i;
                //        //    colIndexlWithMax = j;
                //        //}
                //        if (m[i][j]>nonCornerMax && !(i == 0 && j == dimension - 1) && !(i == dimension - 1 && j == 0))
                //        {
                //            nonCornerMax = m[i][j];
                //            nonCornerRowIndex = i;
                //            nonCornerColIndex = j;
                //        }
                //    }
                //}
                //Console.WriteLine($"max {max} ({rowIndexWithMax}, {colIndexlWithMax}) {Environment.NewLine}nonCornerMax {nonCornerMax} ({nonCornerRowIndex}, {nonCornerColIndex})");

                int coins = 0;
                //diagonally down and to the right
                for(int i=nonCornerRowIndex, j=nonCornerColIndex; i<dimension && j<dimension; i++, j++){
                    coins += m[i][j];
                }
                //diagonally up and to the left, starting 1 before nonCornerMax
                for (int i = nonCornerRowIndex-1, j = nonCornerColIndex-1; i >=0 && j >= 0; i--, j--)
                {
                    coins += m[i][j];
                }

                Console.Write($"Case #{c}: {coins}");
            }
        }

        private void CombinationLock()
        {
            //int cases = 1;
            int cases = int.Parse(Console.ReadLine());
            for (int c = 1; c < cases + 1; c++)
            {
                var lineParts = Console.ReadLine().Split(' ');
                int w = int.Parse(lineParts[0]);
                int n = int.Parse(lineParts[1]);
                int[] wheels = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                ////Test case 1
                //int w = 3;
                //int n = 5;
                //int[] wheels = new int[] { 2, 3, 4, };
                ////Test case 2
                //int w = 4;
                //int n = 10;
                //int[] wheels = new int[] { 2, 9, 3, 8, };

                int minTurns = int.MaxValue;
                int[] minTurnsForWheelAtCurrentTarget = new int[w];
                for (int target = 0; target < n; target++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        int startingDigit = wheels[i];
                        if (target < startingDigit)
                        {
                            int upAndRollover = (n - startingDigit) + target;
                            int down = startingDigit - target;
                            int targetLessThanCurrent = Math.Min(down, upAndRollover);
                            minTurnsForWheelAtCurrentTarget[i] = targetLessThanCurrent;
                        }
                        else
                        {
                            int downAndRollover = startingDigit + (n - target);
                            int up = target - startingDigit;
                            int targetLessThanCurrent = Math.Min(up, downAndRollover);
                            minTurnsForWheelAtCurrentTarget[i] = targetLessThanCurrent;
                        }
                    }
                    int minForTargetForAllCombinedWheels = minTurnsForWheelAtCurrentTarget.Sum();
                    minTurns = Math.Min(minTurns, minForTargetForAllCombinedWheels);
                    //int end = 0;
                }

                Console.WriteLine($"Case #{c}: {minTurns}");
            }
        }

    }
}
