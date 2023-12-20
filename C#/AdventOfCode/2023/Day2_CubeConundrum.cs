namespace AdventOfCode._2023
{
    public static class Day2_CubeConundrum
    {
        public static List<Game> Games { get; set; } = new();

        // 12 red cubes
        // 13 green cubes
        // 14 blue cubes
        public static void Solve()
        {
            Console.WriteLine("Solving cube conundrum!");
            string[] lines = File.ReadAllLines("inputs/day2.txt");

            GetGames(lines);
            var bla = "";
        }

        private static void GetGames(string[] lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                Games.Add(CreateGame(line));
            }
        }

        private static Game CreateGame(string line)
        {
            var idSplit = line.Replace("Game ", "").Split(": ");
            var id = int.Parse(idSplit[0]);
            var game = new Game(id);
            var sets = idSplit[1].Split("; ");

            // set = "1 blue, 1 red"
            foreach (var set in sets)
                game.Sets.Add(CreateSet(set));

            return game;
        }

        public static Set CreateSet(string set)
        {
            var newSet = new Set();
            var cubes = set.Split(", ");

            // cube = "1 blue"
            foreach (var cube in cubes)
                newSet.Cubes.Add(CreateCube(cube));

            return newSet;
        }

        public static Cube CreateCube(string cube)
        {
            var split = cube.Split(" ");
            var amount = int.Parse(split[0]);
            var color = split[1].Trim();

            return new Cube(amount, color);
        }
    }

    public class Game
    {
        public int Id { get; set; }

        public List<Set> Sets { get; set; } = new();

        public Game(int id) => Id = id;
    }

    public class Set
    {
        public List<Cube> Cubes { get; set; } = new();
    }

    public class Cube
    {
        public int Amount { get; set; }

        public string Color { get; set; }

        public Cube(int amount, string color)
        {
            Amount = amount;
            Color = color;
        }
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
