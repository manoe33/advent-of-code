using System.Text.RegularExpressions;

namespace AdventOfCode._2023
{
    public static class Day1_Trebuchet
    {
        public static void Fire()
        {
            Console.WriteLine("Firing trebuchet!");
            string[] lines = File.ReadAllLines("inputs/day1.txt");

            Console.WriteLine($"Answer part 1: {Part1(lines)}");  // 56465
            Console.WriteLine($"Answer part 2: {Part2(lines)}");
        }

        public static int Part1(string[] lines)
        {
            var answer = 0;

            foreach (var line in lines)
            {
                var digit = ExtractDigits(line);
                answer += int.Parse(digit);
            }

            return answer;
        }

        public static int Part2(string[] lines)
        {
            foreach (var line in lines)
            {
                ExtractDigitsAndText("zoneight234");
            }

            return 0;
        }

        public static string ExtractDigits(string line)
        {
            var regex = new Regex(@"[^\d]");
            //var regex = new Regex(@"\d+");
            var digits = regex.Replace(line, "");
            Console.WriteLine(digits);
            var first = digits[0];
            var last = digits[^1];
            var digit = $"{first}{last}";
            Console.WriteLine(digit);
            return digit;
        }

        //public static MatchCollection ExtractDigitsAndText(string line)
        public static string ExtractDigitsAndText(string line)
        {
            // okay, so now you have a regex that filters out the digits.
            // but now that's not what I want.

            // if you do find a written out number, you can replace the string (-minus first and last char into a digit)..

            //okay, so first replace all numbers with a digit
            var regex = new Regex(@"one|two|three|four|five|six|seven|eight|nine");
            var match = regex.Match(line);
            var innerString = match.Value.Substring(1, match.Value.Length - 2);

            var bla = $"{match.Value.Substring(0, 1)}1{match.Value.Substring(match.Value.Length - 1, 1)}";

            //ohja, moet je dan wel replacen met de digit slimmerik. 1e en laatste char van de match
            var blaa = line.Replace(match.Value, innerString);

            var tibo = "";
            // the bla part should now be replaced with the digit

            //regex.Replace(line, match.)

            // todo: replace the innerstring of the match with 9


            //var digits = regex.Replace(line, "9");

            return line;


            //var regex = new Regex(@"[^\d]");
            ////var regex = new Regex(@"\d+");
            //var digits = regex.Replace(line, "");
            //var first = digits[0];
            //var last = digits[^1];
            //var digit = $"{first}{last}";
            //Console.WriteLine(digit);
            //return digit;
        }
    }
}
