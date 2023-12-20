using AdventOfCode._2023;
using Xunit;

namespace AdventOfCode._2023Tests
{
    public class Day2_CubeConundrumTests
    {
        [Fact]
        public void CreateGame_ShouldReturnGame()
        {
            // Arrange
            var line = "Game 1: 23 blue, 1 red; 10 red; 8 red, 1 blue, 1 green; 1 green, 5 blue";

            // Act
            var result = Day2_CubeConundrum.CreateGame(line);
            var firstSet = result.Sets[0];

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(4, result.Sets.Count);
            Assert.Equal(firstSet.Cubes.Count, result.Sets[0].Cubes.Count);
            Assert.Contains(firstSet.Cubes, cube => cube.Key == "blue" && cube.Value == 23);
            Assert.Contains(firstSet.Cubes, cube => cube.Key == "red" && cube.Value == 1);
        }

        [Fact]
        public void CreateSet_ShouldReturnSetWithCubes()
        {
            // Arrange
            string set = "24 blue, 1 red";

            // Act
            var result = Day2_CubeConundrum.CreateSet(set);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Cubes.Count);
            Assert.Contains(result.Cubes, cube => cube.Key == "blue" && cube.Value == 24);
            Assert.Contains(result.Cubes, cube => cube.Key == "red" && cube.Value == 1);
        }

        [Fact]
        public void CreateCube_ShouldReturnTupleWithCorrectCubeColorAndAmount()
        {
            // Arrange
            string cube = "2 red";

            // Act
            var result = Day2_CubeConundrum.CreateCube(cube);

            // Assert
            Assert.Equal("red", result.Item1);
            Assert.Equal(2, result.Item2);
        }

        [Fact]
        public void GetGames_ShouldAddGamesToList()
        {
            // Arrange
            string[] lines = new string[]
            {
                "Game 1: 13 blue, 1 red; 10 red; 8 red, 1 blue, 1 green; 1 green, 5 blue",
                "Game 2: 2 red, 3 green; 5 blue; 4 red, 2 green; 3 blue, 1 red"
            };

            // Act
            Day2_CubeConundrum.GetGames(lines);

            // Assert
            Assert.Equal(2, Day2_CubeConundrum.Games.Count);
            Assert.Equal(1, Day2_CubeConundrum.Games[0].Id);
            Assert.Equal(4, Day2_CubeConundrum.Games[1].Sets.Count);
        }

        [Fact]
        public void IsPossible_ShouldReturnTrue_WhenSetsHaveEnoughCubes()
        {
            // Arrange
            var game = new Game(1);
            game.Sets.Add(new() { Cubes = new() {  { "red", 2 },{ "green", 3 }, { "blue", 4 } } });

            // Act
            var result = game.IsPossible();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPossible_ShouldReturnFalse_WhenSetsDoNotHaveEnoughCubes()
        {
            // Arrange
            var game = new Game(1);
            game.Sets.Add(new() { Cubes = new() { { "red", 17 }, { "green", 5 }, { "blue", 2 } } });

            // Act
            var result = game.IsPossible();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasEnoughRedCubes_ShouldReturnTrue_WhenEnoughRedCubes()
        {
            // Arrange
            var set = new Set();
            set.Cubes.Add("red", 10);

            // Act
            var result = set.HasEnoughRedCubes();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasEnoughRedCubes_ShouldReturnFalse_WhenNotEnoughRedCubes()
        {
            // Arrange
            var set = new Set();
            set.Cubes.Add("red", 15);

            // Act
            var result = set.HasEnoughRedCubes();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasEnoughGreenCubes_ShouldReturnTrue_WhenEnoughGreenCubes()
        {
            // Arrange
            var set = new Set();
            set.Cubes.Add("green", 5);

            // Act
            var result = set.HasEnoughGreenCubes();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasEnoughGreenCubes_ShouldReturnFalse_WhenNotEnoughGreenCubes()
        {
            // Arrange
            var set = new Set();
            set.Cubes.Add("green", 20);

            // Act
            var result = set.HasEnoughGreenCubes();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasEnoughBlueCubes_ShouldReturnTrue_WhenEnoughBlueCubes()
        {
            // Arrange
            var set = new Set();
            set.Cubes.Add("blue", 8);

            // Act
            var result = set.HasEnoughBlueCubes();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasEnoughBlueCubes_ShouldReturnFalse_WhenNotEnoughBlueCubes()
        {
            // Arrange
            var set = new Set();
            set.Cubes.Add("blue", 25);

            // Act
            var result = set.HasEnoughBlueCubes();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasEnoughCubesInTotal_ShouldReturnTrue_WhenEnoughCubesInTotal()
        {
            // Arrange
            var set = new Set();
            set.Cubes.Add("red", 10);
            set.Cubes.Add("green", 5);
            set.Cubes.Add("blue", 8);

            // Act
            var result = set.HasEnoughCubesInTotal();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasEnoughCubesInTotal_ShouldReturnFalse_WhenNotEnoughCubesInTotal()
        {
            // Arrange
            var set = new Set();
            set.Cubes.Add("red", 15);
            set.Cubes.Add("green", 20);
            set.Cubes.Add("blue", 25);

            // Act
            var result = set.HasEnoughCubesInTotal();

            // Assert
            Assert.False(result);
        }
    }
}