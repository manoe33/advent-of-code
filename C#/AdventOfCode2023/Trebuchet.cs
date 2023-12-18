using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    public class Trebuchet
    {
        public static void Fire()
        {
            Console.WriteLine("Firing trebuchet!");
            string[] lines = File.ReadAllLines("input.txt");

            foreach (var line in lines)
            {
                string resultString = null;
                try
                {
                    var regex = new Regex(@"[^\d]");
                    //var regex = new Regex(@"\d+");
                    resultString = regex.Replace(line, "");
                    Console.WriteLine(resultString);
                }
                catch (ArgumentException ex)
                {
                    // Syntax error in the regular expression
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}