using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace timecomplexity
{
    class Program
    {
         static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("size of the array:");
                var input = Console.ReadLine();
                var numbers = GenerateRandomNumbers(int.Parse(input));

                Stopwatch sw = new Stopwatch();

                sw.Start();
                var tableResult = FindOddNumbeOfTimes_HashTable(numbers);
                sw.Stop();
                Console.WriteLine("{0} numbers, hash table. Elapsed={1}", input, sw.ElapsedMilliseconds);

                sw.Restart();
                var linqResult = FindOddNumbeOfTimes_Linq(numbers);
                sw.Stop();
                Console.WriteLine("{0} numbers, linq. Elapsed={1}", input, sw.ElapsedMilliseconds);

            }
        }


        private static  int[] FindOddNumbeOfTimes_Linq(int[] numbers)
        {
            return numbers.GroupBy(x => x).Select(y => new { Number = y.Key, Count = y.Count() }).Where(z => z.Count % 2 != 0).Select(h=>h.Number).ToArray();
        }

        private static ArrayList FindOddNumbeOfTimes_HashTable(int[] numbers)
        {
            var result = new ArrayList();
            Dictionary<int, int> hmap = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (hmap.ContainsKey(numbers[i]))
                {
                    int val = hmap[numbers[i]];
                    hmap.Remove(numbers[i]);
                    hmap.Add(numbers[i], val + 1);
                }
                else
                    hmap.Add(numbers[i], 1);
            }

            foreach (KeyValuePair<int, int> entry in hmap)
            {
                if (entry.Value % 2 != 0)
                {
                    result.Add(entry.Key);
                }
            }
            return result;
        }

        private static int[] GenerateRandomNumbers(int size)
        {
            var result = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                result[i] = rnd.Next(0, 10);
            }

            return result;
        }
    }

    
}
