using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code.Days {
    public class Day5 {
        //        [G]         [D]     [Q]
        //[P]     [T]         [L] [M] [Z]
        //[Z] [Z] [C]         [Z] [G] [W]
        //[M] [B] [F]         [P] [C] [H] [N]
        //[T] [S] [R]     [H] [W] [R] [L] [W]
        //[R] [T] [Q] [Z] [R] [S] [Z] [F] [P]
        //[C] [N] [H] [R] [N] [H] [D] [J] [Q]
        //[N] [D] [M] [G] [Z] [F] [W] [S] [S]
        //1   2   3   4   5   6   7   8   9

        public string Part1()
        {
            char[][] data = new char[9][];
            data[0] = "NCRTMZP".ToCharArray();
            data[1] = "DNTSBZ".ToCharArray();
            data[2] = "MHQRFCTG".ToCharArray();
            data[3] = "GRZ".ToCharArray();
            data[4] = "ZNRH".ToCharArray();
            data[5] = "FHSWPZLD".ToCharArray();
            data[6] = "WDZRCGM".ToCharArray();
            data[7] = "SJFLHWZQ".ToCharArray();
            data[8] = "SQPWN".ToCharArray();

            var moves = GetMoves();
            var newData = MoveElements(moves, data);

            var result = string.Empty;
            for (int i = 0; i < newData.Length; i++)
            {
                var column = newData[i];
                result += newData[i][column.Length-1];
            }
            

            return result;
        }

        public string Part2()
        {
            char[][] data = new char[9][];
            data[0] = "NCRTMZP".ToCharArray();
            data[1] = "DNTSBZ".ToCharArray();
            data[2] = "MHQRFCTG".ToCharArray();
            data[3] = "GRZ".ToCharArray();
            data[4] = "ZNRH".ToCharArray();
            data[5] = "FHSWPZLD".ToCharArray();
            data[6] = "WDZRCGM".ToCharArray();
            data[7] = "SJFLHWZQ".ToCharArray();
            data[8] = "SQPWN".ToCharArray();

            var moves = GetMoves();
            var newData = MoveElementsWithCrateMover9001(moves, data);

            var result = string.Empty;
            for (int i = 0; i < newData.Length; i++)
            {
                var column = newData[i];
                result += newData[i][column.Length - 1];
            }


            return result;
        }

        private List<Sequence> GetMoves() {
            var input = File.ReadAllLines("data/Day5.txt");
            var moves = new List<Sequence>();

            foreach (var line in input)
            {
                var lineArray = line.Split(' ');
                var sewquense = new Sequence()
                {
                    Move = int.Parse(lineArray[1]),
                    From = int.Parse(lineArray[3]),
                    To = int.Parse(lineArray[5])

                };
                moves.Add(sewquense);
            }

            return moves;
        }

        private char[][] MoveElements(List<Sequence> moves, char[][] data)
        {
            moves.ForEach(m =>
            {
                
                for (int i = 0; i < m.Move; i++)
                {
                    var from = m.From - 1;
                    var to = m.To - 1;

                    var column = data[from];
                    var item = column.Last();
                    Array.Resize(ref data[to], data[to].Length+1);
                    data[to][data[to].Length-1] = item;
                    data[from] = column.Take(column.Length - 1).ToArray();
                }
            });

            return data;
        }

        private char[][] MoveElementsWithCrateMover9001(List<Sequence> moves, char[][] data)
        {
            moves.ForEach(m =>
            {
                var tempList = new List<char>();
                var from = m.From - 1;
                var to = m.To - 1;

                for (int i = 0; i < m.Move; i++)
                {
                    

                    var column = data[from];
                    var item = column.Last();
                    //Array.Resize(ref data[to], data[to].Length + 1);
                    //data[to][data[to].Length - 1] = item;
                    data[from] = column.Take(column.Length - 1).ToArray();
                    tempList.Add(item);
                }
                tempList.Reverse();
                tempList.ForEach(i =>
                {
                    Array.Resize(ref data[to], data[to].Length + 1);
                    data[to][data[to].Length - 1] = i;
                });
            });

            return data;
        }
        

        class Sequence {
            public int Move {get; set;}
            public int From {get; set;}
            public int To {get; set;}

        }
    }
}
