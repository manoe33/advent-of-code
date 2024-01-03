using AdventOfCode._2023;
using Xunit;

namespace AdventOfCode._2023Tests
{
    public class Day1_TrebuchetTests
    {
        [Fact]
        public void ExtractDigits_ShouldReturnFirstAndLastDigitFromString()
        {
            string line = "1nine6oneeightnine5lfrzmzh7";
            var digit = Day1_Trebuchet.ExtractDigits(line);

            Assert.Equal("17", digit);
        }

        [Fact]
        public void CalculateCoordinates_ShouldReturnSumOfDigits()
        {
            // Arrange
            string[] lines = new string[]
            {
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet"
            };

            // Act
            int result = Day1_Trebuchet.Part1(lines);

            // Assert
            Assert.Equal(142, result);
        }

        [Fact]
        public void Bla()
        {
            // Arrange
            var line = "zoneight234";

            // Act
            var result = Day1_Trebuchet.ExtractDigitsAndText(line);

            // Assert
            //Assert.Equal("oneeight", result);


            // nu vind ie er maar 1, mss toch mss n replace doen?
            Assert.Null(result);
        }
    }
}