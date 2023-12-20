using System.Drawing;
using System.Linq;

namespace AdventOfCode._2023
{
    public static class Day2_CubeConundrum
    {
        public static int AmountOfRedCubes { get; set; } = 12;

        public static int AmountOfGreenCubes { get; set; } = 13;

        public static int AmountOfBlueCubes { get; set; } = 14;

        public static List<Game> Games { get; set; } = new();


        public static void Solve()
        {
            Console.WriteLine("Solving cube conundrum!");
            string[] lines = File.ReadAllLines("inputs/day2.txt");

            GetGames(lines);

            var sum = Games
                .Where(game => game.IsPossible())
                .Sum(game => game.Id);


            Console.WriteLine($"Answer: {sum}");  // 4673 = too high
        }

        public static void GetGames(string[] lines)
        {
            // line = "Game 1: 1 blue, 1 red; 10 red; 8 red, 1 blue, 1 green; 1 green, 5 blue"
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                Games.Add(CreateGame(line));
            }
        }

        public static Game CreateGame(string line)
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

            foreach (var cube in cubes)
            {
                var newCube = CreateCube(cube);
                newSet.Cubes.Add(newCube.Item1, newCube.Item2);
            }

            return newSet;
        }

        public static Tuple<string, int> CreateCube(string cube)
        {
            var split = cube.Split(" ");
            var amount = int.Parse(split[0]);
            var color = split[1].Trim();

            return Tuple.Create(color, amount);
        }
    }

    public class Game
    {
        public int Id { get; set; }

        public List<Set> Sets { get; set; } = new();

        public Game(int id) => Id = id;

        public bool IsPossible() => Sets.Exists(set => set.HasEnoughCubesInTotal());
    }

    public class Set
    {
        public Dictionary<string, int> Cubes { get; set; } = new();

        public bool HasEnoughRedCubes() => Cubes.Where(cube => cube.Key == "red").Any(cube => cube.Value <= Day2_CubeConundrum.AmountOfRedCubes);

        public bool HasEnoughGreenCubes() => Cubes.Where(cube => cube.Key == "green").Any(cube => cube.Value <= Day2_CubeConundrum.AmountOfGreenCubes);

        public bool HasEnoughBlueCubes() => Cubes.Where(cube => cube.Key == "blue").Any(cube => cube.Value <= Day2_CubeConundrum.AmountOfBlueCubes);

        public bool HasEnoughCubesInTotal() => HasEnoughRedCubes() && HasEnoughGreenCubes() && HasEnoughBlueCubes();
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
