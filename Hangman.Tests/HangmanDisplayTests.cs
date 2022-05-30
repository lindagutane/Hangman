using Xunit;

namespace Hangman.Tests
{
    public class HangmanDisplayTests
    {
        #region Case
        private const string FirstCase = @"
                           
                           
                           
                           
                           
                           
                    =========";

        private const string SecondCase = @"
                          +
                          |
                          |
                          |
                          |
                          |
                    =========";

        private const string ThirdCase = @"
                      +---+
                          |
                          |
                          |
                          |
                          |
                    =========";

        private const string FourthCase = @"
                      +---+
                      |   |
                          |
                          |
                          |
                          |
                    =========";

        private const string FifthCase = @"
                      +---+
                      |   |
                      O   |
                          |
                          |
                          |
                    =========";

        private const string SixthCase = @"
                      +---+
                      |   |
                      O   |
                      |   |
                          |
                          |
                    =========";

        private const string SeventhCase = @"
                      +---+
                      |   |
                      O   |
                     /|   |
                          |
                          |
                    =========";

        private const string EightCase = @"
                      +---+
                      |   |
                      O   |
                     /|\  |
                          |
                          |
                    =========";
        private const string NinthCase = @"
                      +---+
                      |   |
                      O   |
                     /|\  |
                     /    |
                          |
                    =========";

        private const string TenthCase = @"
                      +---+
                      |   |
                      O   |
                     /|\  |
                     / \  |
                          |
                    =========";

        #endregion

        [Theory]
        [InlineData(1, FirstCase)]
        [InlineData(2, SecondCase)]
        [InlineData(3, ThirdCase)]
        [InlineData(4, FourthCase)]
        [InlineData(5, FifthCase)]
        [InlineData(6, SixthCase)]
        [InlineData(7, SeventhCase)]
        [InlineData(8, EightCase)]
        [InlineData(9, NinthCase)]
        [InlineData(10, TenthCase)]

        public void GetMan_WhenCorrectNumberOfTries_ThenReturnsCorrectCase(int tries, string result)
        {
            var response = HangmanDisplay.GetMan(tries);

            Assert.Equal(result, response);
        }

        [Fact]
        public void GetMan_WhenIncorrectNumberOfTries_ThenThrowsSystemException()
        {
            Assert.Throws<System.Exception>(() => HangmanDisplay.GetMan(20));
        }
    }
}