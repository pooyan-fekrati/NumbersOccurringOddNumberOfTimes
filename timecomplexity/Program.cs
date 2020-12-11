using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace timecomplexity
{
    class Program
    {
        static void Main(string[] args)
        {

            var _1000numbers = GenerateRandomNumbers(1000);
            var _10000numbers = GenerateRandomNumbers(10000);
            var _100000numbers = GenerateRandomNumbers(100000);
            var _1000000numbers = GenerateRandomNumbers(1000000);

            Stopwatch sw = new Stopwatch();


            // 1000 numbers
            sw.Start();
            var _1000hashTableResult = FindOddNumbeOfTimes_HashTable(_1000numbers);
            sw.Stop();
            Console.WriteLine("1000 bumbers, hash table. Elapsed={0}", sw.ElapsedMilliseconds);

            sw.Reset();

            sw.Start();
            var _1000linqResult = FindOddNumbeOfTimes_Linq(_1000numbers);
            sw.Stop();
            Console.WriteLine("1000 bumbers, ling. Elapsed={0}", sw.ElapsedMilliseconds);

            sw.Reset();

            // 10000 numbers
            sw.Start();
            var _10000hashTableResult = FindOddNumbeOfTimes_HashTable(_10000numbers);
            sw.Stop();
            Console.WriteLine("10000 bumbers, hash table. Elapsed={0}", sw.ElapsedMilliseconds);

            sw.Reset();

            sw.Start();
            var _10000linqResult = FindOddNumbeOfTimes_Linq(_10000numbers);
            sw.Stop();
            Console.WriteLine("10000 bumbers, ling. Elapsed={0}", sw.ElapsedMilliseconds);

            sw.Reset();

            // 100000 numbers
            sw.Start();
            var _100000hashTableResult = FindOddNumbeOfTimes_HashTable(_100000numbers);
            sw.Stop();
            Console.WriteLine("100000 bumbers, hash table. Elapsed={0}", sw.ElapsedMilliseconds);

            sw.Reset();

            sw.Start();
            var _100000linqResult = FindOddNumbeOfTimes_Linq(_100000numbers);
            sw.Stop();
            Console.WriteLine("100000 bumbers, ling. Elapsed={0}", sw.ElapsedMilliseconds);

            sw.Reset();

            // 1000000 numbers
            sw.Start();
            var _1000000hashTableResult = FindOddNumbeOfTimes_HashTable(_1000000numbers);
            sw.Stop();
            Console.WriteLine("1000000 bumbers, hash table. Elapsed={0}", sw.ElapsedMilliseconds);

            sw.Reset();

            sw.Start();
            var _1000000linqResult = FindOddNumbeOfTimes_Linq(_1000000numbers);
            sw.Stop();
            Console.WriteLine("1000000 bumbers, ling. Elapsed={0}", sw.ElapsedMilliseconds);

            Console.ReadLine();
        }


        private static int[] FindOddNumbeOfTimes_Linq(int[] numbers)
        {
            return numbers.GroupBy(x => x).Select(y => new { Number = y.Key, Count = y.Count() }).Where(z => z.Count % 2 != 0).Select(h=>h.Number).ToArray();
        }

        private static int[] FindOddNumbeOfTimes_HashTable(int[] numbers)
        {
            var result = new List<int>();
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
            return result.ToArray();
        }

        private static int[] GenerateRandomNumbers(int size)
        {
            var result = new int[size];
            for (int i = 0; i < size; i++)
            {
                Random rnd = new Random();
                result[i] = rnd.Next(0, 10);
            }

            return result;
        }
    }

    
}
