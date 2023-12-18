using AdventOfCode2023;
using Xunit;

namespace AdventOfCode2023Tests
{
    public class TrebuchetTests
    {
        [Fact]
        public void ExtractDigits_ShouldReturnFirstAndLastDigitFromString()
        {
            string line = "1nine6oneeightnine5lfrzmzh7";
            var digit = Trebuchet.ExtractDigits(line);

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
            int result = Trebuchet.CalculateCoordinates(lines);

            // Assert
            Assert.Equal(142, result);
        }
    }
}