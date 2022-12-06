using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code.Days {
    public class Day1 {
        static int Process()
        {
            var input = File.ReadAllLines("data/Day1.txt");
            var elfsCalories = new List<int>();
            var tempCalories = 0;
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    elfsCalories.Add(tempCalories);
                    tempCalories = 0;
                    continue;
                }
                tempCalories += int.Parse(line);
            }
            //return elfsCalories.Max();
            elfsCalories.Sort();
            elfsCalories.Reverse();
            return elfsCalories.Take(3).Sum();
        }
    }
}
