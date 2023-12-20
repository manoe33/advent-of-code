using System.Text.RegularExpressions;

namespace AdventOfCode._2023
{
    public static class Day1_Trebuchet
    {
        public static void Fire()
        {
            Console.WriteLine("Firing trebuchet!");
            string[] lines = File.ReadAllLines("inputs/day1.txt");
            int answer = CalculateCoordinates(lines);

            Console.WriteLine($"Answer: {answer}");  // 56465
        }

        public static int CalculateCoordinates(string[] lines)
        {
            var answer = 0;

            foreach (var line in lines)
            {
                var digit = ExtractDigits(line);
                answer += int.Parse(digit);
            }

            return answer;
        }

        public static string ExtractDigits(string line)
        {
            var regex = new Regex(@"[^\d]");
            //var regex = new Regex(@"\d+");
            var digits = regex.Replace(line, "");
            var first = digits[0];
            var last = digits[^1];
            var digit = $"{first}{last}";
            Console.WriteLine(digit);
            return digit;


            //string resultString = null;
            //try
            //{
            //    var regex = new Regex(@"[^\d]");
            //    //var regex = new Regex(@"\d+");
            //    resultString = regex.Replace(line, "");
            //    Console.WriteLine(resultString);
            //}
            //catch (ArgumentException ex)
            //{
            //    // Syntax error in the regular expression
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
