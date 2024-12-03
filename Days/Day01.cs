namespace adventofcode2024.Days
{

    public class Day01
    {
        public List<int> _left = new List<int>();
        public List<int> _right = new List<int>();
        public void Day01A()
        {
            int result = 0;

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            try
            {
                using (var sr = new StreamReader("..\\..\\..\\PuzzleInputs\\Day01\\Day01A.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] numbers = line.Split("   ");
                        left.Add(int.Parse(numbers[0]));
                        right.Add(int.Parse(numbers[1]));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }

            // Sort the lefts and right values
            left.Sort();
            right.Sort();

            this._left = left;
            this._right = right;

            for (int i = 0; i < left.Count; i++)
            {
                int difference = Math.Abs(left[i] - right[i]);
                result += difference;
            }
            Console.WriteLine("The answer is " + result);
        }

        /// <summary>
        /// Add up each number in the left left, after multiplying it by number of times that number appears in the right list
        /// Create a hash set of the right list
        /// Search through left lift to see if its in right dictionary, if so then add * number of times it appears in right list
        /// </summary>
        public int Day01B()
        {
            var rightCount = CreateKeyValuePairs(this._right);
            var result = 0;
            foreach (int i in this._left)
            {
                if (rightCount.ContainsKey(i))
                {
                   result += i * rightCount[i];
                }
            }
            Console.WriteLine("Day01B = "+ result);
            return result;
        }

        public Dictionary<int, int> CreateKeyValuePairs(List<int> list)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int i in list)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i] += 1;
                }
                else
                {
                    dict.Add(i, 1);
                }
            }
            return dict;
        }
    }
}
