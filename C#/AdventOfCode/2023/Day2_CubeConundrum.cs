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
            string[] lines = File.ReadAllLines("inputs/day2.txt");
            GetGames(lines);

            Console.WriteLine($"Answer: {GetSum()}");  // 2439
        }

        public static int GetSum()
        {
            // oh wait!! Al sets should be possible
            var possibleGames = Games.Where(game => game.IsPossible());
            var sum = possibleGames.Sum(game => game.Id);

            return sum;
        }

        public static void GetGames(string[] lines)
        {
            // line = "Game 1: 1 blue, 1 red; 10 red; 8 red, 1 blue, 1 green; 1 green, 5 blue"
            foreach (var line in lines)
                Games.Add(CreateGame(line));
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
                newSet.Cubes.Add(newCube.Key, newCube.Value);
            }

            return newSet;
        }

        public static KeyValuePair<string, int> CreateCube(string cube)
        {
            var split = cube.Split(" ");
            var amount = int.Parse(split[0]);
            var color = split[1].Trim();

            return new(color, amount);
        }
    }

    public class Game
    {
        public int Id { get; set; }

        public List<Set> Sets { get; set; } = new();

        public Game(int id) => Id = id;

        public bool IsPossible() => Sets.TrueForAll(set => set.HasEnoughCubesInTotal());
    }

    public class Set
    {
        public Dictionary<string, int> Cubes { get; set; } = new();

        public bool HasEnoughRedCubes()
        {
            var cubes = GetCubesByColor("red");

            if (cubes.ToList().Count > 0)
                return cubes.Any(cube => HasEnoughCubesForColor(cube, Day2_CubeConundrum.AmountOfRedCubes));
            else
                return true;
        }

        public bool HasEnoughGreenCubes()
        {
            var cubes = GetCubesByColor("green");

            if (cubes.ToList().Count > 0)
                return cubes.Any(cube => HasEnoughCubesForColor(cube, Day2_CubeConundrum.AmountOfGreenCubes));
            else
                return true;
        }

        public bool HasEnoughBlueCubes()
        {
            var cubes = GetCubesByColor("blue");

            if (cubes.ToList().Count > 0)
                return cubes.Any(cube => HasEnoughCubesForColor(cube, Day2_CubeConundrum.AmountOfBlueCubes));
            else
                return true;
        }

        public IEnumerable<KeyValuePair<string, int>> GetCubesByColor(string color) => Cubes.Where(cube => cube.Key == color);

        public static bool HasEnoughCubesForColor(KeyValuePair<string, int> cube, int amount) => cube.Value <= amount;

        public bool HasEnoughCubesInTotal() => HasEnoughRedCubes() && HasEnoughGreenCubes() && HasEnoughBlueCubes();
    }
}
