using AdventOfCode._2023;
using Xunit;

namespace AdventOfCode._2023Tests
{
    public class Day2_CubeConundrumTests
    {
        [Fact]
        public void CreateSet_ShouldReturnSetWithCorrectCubes()
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
        public void CreateGame_ShouldWorkCorrectly()
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
        public void GetGames_Should_AddGamesToList()
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
    }
}