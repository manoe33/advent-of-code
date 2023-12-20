namespace AdventOfCode._2023
{
    public static class Day2_CubeConundrum
    {
        public static void Solve()
        {
            Console.WriteLine("Solving cube conundrum!");
            string[] lines = File.ReadAllLines("inputs/day2.txt");
            //int answer = CalculateChecksum(lines);

            //Console.WriteLine($"Answer: {answer}");  // 56465
        }

        //public static void Solve()
        //{
        //    Console.WriteLine("Solving cube conundrum!");
        //    string[] lines = File.ReadAllLines("inputs/day2.txt");
        //    int answer = CalculateChecksum(lines);

        //    Console.WriteLine($"Answer: {answer}");  // 56465
        //}

        //public static int CalculateChecksum(string[] lines)
        //{
        //    var answer = 0;

        //    foreach (var line in lines)
        //    {
        //        var digits = ExtractDigits(line);
        //        var checksum = CalculateChecksum(digits);
        //        answer += checksum;
        //    }

        //    return answer;
        //}

        //public static int CalculateChecksum(int[] digits)
        //{
        //    var checksum = 0;
        //    var min = digits[0];
        //    var max = digits[0];

        //    foreach (var digit in digits)
        //    {
        //        if (digit < min)
        //        {
        //            min = digit;
        //        }

        //        if (digit > max)
        //        {
        //            max = digit;
        //        }
        //    }

        //    checksum = max - min;
        //    return checksum;
        //}

        //public static int[] ExtractDigits(string line)
        //{
        //    var digits = line.Split("\t");
        //    var numbers = new int[digits.Length];

        //    for (int i = 0; i < digits.Length; i++)
        //    {
        //        numbers[i] = int.Parse(digits[i]);
        //    }

        //    return numbers;
        //}
    }
}
