﻿namespace adventofcode2024.Days
{
    public class Day02
    {
        private List<List<int>> _levels = new List<List<int>>();

        public void Day02A()
        {
            int result = 0;

            List<List<int>> levels = new List<List<int>>();

            try
            {
                using (var sr = new StreamReader("..\\..\\..\\PuzzleInputs\\Day02_Input.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] row = line.Split(" ");
                        var level = new List<int>();
                        foreach (string number in row)
                        {
                            level.Add(int.Parse(number));
                        }
                        levels.Add(level);
                        _levels.Add(level);
                    }
                    CountIncreasingAndDecreasing(false);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
        }

        public void Day02B()
        {
            CountIncreasingAndDecreasing(true);
        }

        private void PrintLevels()
        {
            foreach (var level in _levels)
            {
                foreach (var number in level)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }

        private bool IsAllIncreasingOrDecreasing(List<int> level)
        {
            int minThresh = 1;
            int maxThreshold = 3;
            bool isIncreasing = false;
            bool isDecreasing = false;
            for (int i = 0; i < level.Count - 1; i++)
            {
                var right = level[i + 1];
                var left = level[i];
                if (left > right && (left - right <= maxThreshold) && (left - right >= minThresh))
                {
                    isDecreasing = true;
                }
                else if (left < right && (right - left <= maxThreshold) && (right - left >= minThresh))
                {
                    isIncreasing = true;
                }
                else
                {
                    return false;
                }
            }
            return isIncreasing ^ isDecreasing;
        }

        private int CountIncreasingAndDecreasing(bool useDampener = false)
        {
            int count = 0;
            foreach (var level in _levels)
            {
                // Use Dampener or not?
                if (useDampener == true)
                {
                    if (IsAllIncreasingOrDecreasing(level))
                    {
                        count++;
                    }
                    else if (IsDampenable(level))
                    {
                        count++;
                    }
                }
                // No Dampener (Part One)
                else 
                {
                    if (IsAllIncreasingOrDecreasing(level))
                    count++;
                }
            }
            Console.WriteLine("Day 2 - Part Two answer is " + count);
            return count;
        }

        // answer less than 405
        private bool IsDampenable(List<int> level)
        {
            for (int i = 0; i < level.Count; i++)
            {
                var poppedLevel = level.ToList();
                poppedLevel.RemoveAt(i);
                if (IsAllIncreasingOrDecreasing(poppedLevel))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
