using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code.Days {
    public class Day3 {
        public int Part1()
        {
            var input = File.ReadAllLines("data/Day3.txt");
            var points = 0;

            foreach (var line in input)
            {
                var lenght = line.Length;
                var part1 = line.Substring(0, lenght / 2);
                var part2 = line.Substring(lenght / 2, lenght / 2);

                var part1Array = part1.ToArray();
                var part2Array = part2.ToArray();

                var duplicates = part1Array.Intersect(part2Array);
                foreach(var item in duplicates) {
                    points += GetPoint(item);
                }
            }

            return points;
        }

        public int Part2()
        {
            var input = File.ReadAllLines("data/Day3.txt");
            var points = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var line1 = input[i].ToArray();
                var line2 = input[++i].ToArray();
                var line3 = input[++i].ToArray();

                var group = line1.Intersect(line2);
                group = group.Intersect(line3);
                points += GetPoint(group.First());
            }

            return points;
        }

        private int GetPoint(char item)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
            var index = Array.IndexOf(alphabet, item);
            return index+1;

        }
    }
}
