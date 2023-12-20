using AdventOfCode._2023;
using Xunit;

namespace AdventOfCode._2023Tests
{
    public class Day2_CubeConundrumTests
    {
        [Fact]
        public void CreateCube_ShouldReturnCubeWithCorrectAmountAndColor()
        {
            // Arrange
            string cube = "31 red";

            // Act
            var result = Day2_CubeConundrum.CreateCube(cube);

            // Assert
            Assert.Equal(31, result.Amount);
            Assert.Equal("red", result.Color);
        }

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
            Assert.Contains(result.Cubes, cube => cube.Amount == 24 && cube.Color == "blue");
            Assert.Contains(result.Cubes, cube => cube.Amount == 1 && cube.Color == "red");
        }

        //[Fact]
        //public void CreateGame_ShouldWorkCorrectly()
        //{
        //    // Arrange
        //    var expectedGame = new Game(); // Replace with your actual Game object and its initialization
        //    var gameService = new GameService(); // Replace with your actual service and its initialization

        //    // Act
        //    var result = gameService.CreateGame();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(expectedGame, result); // Replace with your actual assertion logic
        //}
    }
}