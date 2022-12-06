using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code.Days {
    public class Day2 {
        public int Part1()
        {
            var input = File.ReadAllLines("data/Day2.txt");
            var points = 0;

            foreach (var line in input)
            {
                var elfChoose = line.Substring(0, 1);
                var myChoose = line.Substring(2, 1);
                points += CalculateRound(elfChoose, myChoose);
            }

            return points;
        }

        public int Part2()
        {
            var input = File.ReadAllLines("data/Day2.txt");
            var points = 0;

            foreach (var line in input)
            {
                // X -  lose
                // Y - draw
                // Z - win

                var elfChoose = line.Substring(0, 1);
                var gameResult = line.Substring(2, 1);
                var gameResultConvert = ConvertChooseToResult(gameResult);
                var myChoose = GetChoodeByResult(elfChoose, gameResultConvert);
                points += CalculateRound(elfChoose, myChoose);
            }

            return points;
        }

        static int CalculateRound(string player1, string player2)
        {
            player1 = ConvertChoose(player1);
            var points = GetPointsForRound(player1, player2);
            points += GetPointsForChoose(player2);
            return points;
        }

        private static string ConvertChoose(string choose)
        {
            switch (choose)
            {
                case "A":
                    return "X";
                case "B":
                    return "Y";
                case "C":
                    return "Z";
            }
            return string.Empty;
        }

        private static RoundResult? ConvertChooseToResult(string choose)
        {
            switch (choose)
            {
                case "X":
                    return RoundResult.Lose;
                case "Y":
                    return RoundResult.Draw;
                case "Z":
                    return RoundResult.Win;
            }
            return null;
        }

        private static int GetPointsForRound(string player1, string player2)
        {
            switch (GetRoundResult(player1, player2))
            {
                case RoundResult.Win:
                    return 6;
                case RoundResult.Draw:
                    return 3;
                case RoundResult.Lose:
                    return 0;
            }

            return 0;
        }

        private static int GetPointsForChoose(string choose)
        {
            switch (choose)
            {
                case "X":
                    return 1;
                case "Y":
                    return 2;
                case "Z":
                    return 3;
            }

            return 0;
        }

        private static RoundResult GetRoundResult(string player1, string player2)
        {
            if (player1.Equals(player2)) return RoundResult.Draw;
            if ((player1 == "X" && player2 == "Y")
                || (player1 == "Y" && player2 == "Z")
                || (player1 == "Z" && player2 == "X")) return RoundResult.Win;
            return RoundResult.Lose;
        }

        private static string GetChoodeByResult(string player1, RoundResult? result)
        {
            player1 = ConvertChoose(player1);
            switch (player1)
            {
                case "X":
                    if (result.Value == RoundResult.Win) return "Y";
                    if (result.Value == RoundResult.Draw) return "X";
                    if (result.Value == RoundResult.Lose) return "Z";
                    return "";
                case "Y":
                    if (result.Value == RoundResult.Win) return "Z";
                    if (result.Value == RoundResult.Draw) return "Y";
                    if (result.Value == RoundResult.Lose) return "X";
                    return "";
                case "Z":
                    if (result.Value == RoundResult.Win) return "X";
                    if (result.Value == RoundResult.Draw) return "Z";
                    if (result.Value == RoundResult.Lose) return "Y";
                    return "";
            }
            return string.Empty;

        }

        private enum RoundResult {
            Win,
            Lose,
            Draw
        }
    }
}
