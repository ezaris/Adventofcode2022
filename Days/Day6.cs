using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code.Days {
    public class Day6 {
        public int Part1()
        {
            var input = File.ReadAllLines("data/Day6.txt").First();
            var marker = FindStart(input);
            //var marker = FindStart("mjqjpqmgbljsphdztnvjfqwrcgsmlb");

            return marker;
        }

        private int FindStart(string blob)
        {
            var messageLenght = 14;
            for (int i = 0; i < blob.Length; i++)
            {
                var part = blob.Substring(i, messageLenght);
                if (part.Distinct().Count() == messageLenght)
                    return i+ messageLenght;
            }
            return 0;
        }
    }
}
