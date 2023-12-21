using AdventOfCode._2023;
using Xunit;

namespace AdventOfCode._2023Tests
{
    public class Day2_CubeConundrumTests
    {
        [Fact]
        public void GetSum_ShouldReturnCorrectSum()
        {
            // Arrange
            Day2_CubeConundrum.Games.Clear();
            Day2_CubeConundrum.Games.AddRange(new List<Game>()
            {
                // game where all sets are have enough cubes
                new Game(1)
                {
                    Sets = new()
                    {
                        new() { Cubes = new() {  { "blue", 1 },{ "red", 1 } } },
                        new() { Cubes = new() { { "red", 10 } } },
                        new() { Cubes = new() { { "red", 8 }, { "blue", 1 }, { "green", 1 } } },
                        new() { Cubes = new() { { "green", 1 }, { "blue", 5 } } }
                    }
                },
                // game where some sets are have enough cubes
                new Game(16)
                {
                    Sets = new()
                    {
                        new() { Cubes = new() {  { "blue", 1 },{ "red", 1 } } },
                        new() { Cubes = new() { { "red", 20 } } },
                        new() { Cubes = new() { { "red", 8 }, { "blue", 1 }, { "green", 1 } } },
                        new() { Cubes = new() { { "green", 1 }, { "blue", 5 } } }
                    }
                },
                // game where all sets are have enough cubes
                new Game(48)
                {
                    Sets = new()
                    {
                        new() { Cubes = new() {  { "blue", 1 },{ "red", 1 } } },
                        new() { Cubes = new() { { "red", 3 } } },
                        new() { Cubes = new() { { "red", 11 }, { "blue", 13 }, { "green", 1 } } },
                        new() { Cubes = new() { { "green", 1 }, { "blue", 5 } } }
                    }
                },
                // game where no sets are have enough cubes
                new Game(67)
                {
                    Sets = new()
                    {
                        new() { Cubes = new() {  { "blue", 99 },{ "red", 30 } } },
                        new() { Cubes = new() { { "red", 17 } } },
                        new() { Cubes = new() { { "red", 18 }, { "blue", 49 }, { "green", 76 } } },
                        new() { Cubes = new() { { "green", 100 }, { "blue", 56 } } }
                    }
                }
            });


            var expected = 1 + 48;

            // Act
            var result = Day2_CubeConundrum.Part1();

            // Assert
            Assert.Equal(expected, result);
        }

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
            Assert.Equal("red", result.Key);
            Assert.Equal(2, result.Value);
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
        public void IsPossible_ShouldReturnTrue_WhenAllSetsHaveEnoughCubes()
        {
            // Arrange
            var game = new Game(1)
            {
                Sets = new()
                {
                    new() { Cubes = new() {  { "blue", 1 },{ "red", 1 } } },
                    new() { Cubes = new() { { "red", 10 } } },
                    new() { Cubes = new() { { "red", 8 }, { "blue", 1 }, { "green", 1 } } },
                    new() { Cubes = new() { { "green", 1 }, { "blue", 5 } } }
                }
            };

            // Act
            var result = game.IsPossible();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPossible_ShouldReturnFalse_WhenSomeSetsDoNotHaveEnoughCubes()
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
            var set = new Set() { Cubes = new() { { "red", 15 }, { "green", 20 }, { "blue", 25 } } };

            // Act
            var result = set.HasEnoughCubesInTotal();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SetGetMaxRedCubes_ShouldReturnMaxRedCubes()
        {
            // Arrange
            var set = new Set() { Cubes = new() { { "red", 5 }, { "blue", 3 }, { "green", 2 } } };

            // Act
            var result = set.GetMaxRedCubes();

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void SetGetMaxGreenCubes_ShouldReturnMaxGreenCubes()
        {
            // Arrange
            var set = new Set() { Cubes = new() { { "red", 5 }, { "blue", 3 }, { "green", 2 } } };

            // Act
            var result = set.GetMaxGreenCubes();

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void SetGetMaxBlueCubes_ShouldReturnMaxBlueCubes()
        {
            // Arrange
            var set = new Set() { Cubes = new() { { "red", 5 }, { "green", 2 } } };

            // Act
            var result = set.GetMaxBlueCubes();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void GameGetMaxRedCubes_ShouldReturnMaxRedCubes()
        {
            // Arrange
            var game = new Game(1);
            game.Sets.Add(new Set { Cubes = { { "red", 5 }, { "green", 3 }, { "blue", 2 } } });
            game.Sets.Add(new Set { Cubes = { { "red", 8 }, { "green", 1 }, { "blue", 4 } } });
            game.Sets.Add(new Set { Cubes = { { "red", 2 }, { "green", 6 }, { "blue", 1 } } });

            // Act
            var result = game.GetMaxRedCubes();

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void GameGetMaxGreenCubes_ShouldReturnMaxGreenCubes()
        {
            // Arrange
            var game = new Game(1);
            game.Sets.Add(new Set { Cubes = { { "red", 5 }, { "green", 3 }, { "blue", 2 } } });
            game.Sets.Add(new Set { Cubes = { { "red", 8 }, { "green", 1 }, { "blue", 4 } } });
            game.Sets.Add(new Set { Cubes = { { "red", 2 }, { "green", 6 }, { "blue", 1 } } });

            // Act
            var result = game.GetMaxGreenCubes();

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void GameGetMaxBlueCubes_ShouldReturnMaxBlueCubes()
        {
            // Arrange
            var game = new Game(1);
            game.Sets.Add(new Set { Cubes = { { "red", 5 }, { "green", 3 }, { "blue", 2 } } });
            game.Sets.Add(new Set { Cubes = { { "red", 8 }, { "green", 1 }, { "blue", 4 } } });
            game.Sets.Add(new Set { Cubes = { { "red", 2 }, { "green", 6 }, { "blue", 1 } } });

            // Act
            var result = game.GetMaxBlueCubes();

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void GetPower_ReturnsCorrectPower()
        {
            // Arrange
            var game = new Game(1);
            game.Sets.Add(new() { Cubes = new() { { "red", 3 }, { "green", 2 }, { "blue", 4 } } });

            // Act
            var result = game.GetPower();
            var expected = 3 * 2 * 4;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetPowers_MultipliesColors()
        {
            // Arrange
            var game = new Game(23);
            game.Sets.Add(new() { Cubes = new() { { "red", 3 }, { "green", 2 }, { "blue", 4 } } });
            game.Sets.Add(new() { Cubes = new() { { "red", 31 }, { "green", 12 }, { "blue", 2 } } });

            // Act
            var result = game.GetPower();
            var expected = 31 * 12 * 4;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Returns_Answers()
        {
            // Arrange
            string[] lines = {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            };

            Day2_CubeConundrum.Games.Clear();
            Day2_CubeConundrum.GetGames(lines);

            // Act
            var result = Day2_CubeConundrum.Part2();

            // Assert
            Assert.Equal(2286, result);
        }
    }
}