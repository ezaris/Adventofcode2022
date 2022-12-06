using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code.Days {
    public class Day4 {
        public int Part1()
        {
            var input = File.ReadAllLines("data/Day4.txt");
            var count = 0;

            foreach (var line in input)
            {
                var elfs = line.Split(',');
                var elf1 = elfs[0];
                var elf2 = elfs[1];
                var elf1List = GetRange(elf1);
                var elf2List = GetRange(elf2);
                if (elf1List.All(i => elf2List.Contains(i))) count++;
                else if (elf2List.All(i => elf1List.Contains(i))) count++;
            }

            return count;
        }

        private List<int> GetRange(string patern)
        {
            var list = new List<int>();

            var range = patern.Split('-');
            var start = int.Parse(range[0]);
            var end = int.Parse(range[1]);

            for (int i = start; i <= end; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}
