using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hangman.Tests
{
    public class BaseListOfWordsTests
    {

        [Theory]
        [InlineData("hello", "bu")]
        public void GetRandomWord_WhenGetsListOfWords_ThenReturnsRandomWord(params string[] words)
        {
            var wordsList = words.ToList();

            string response = BaseListOfWords.GetRandomWord(wordsList);

            Assert.Contains(response, wordsList);
        }
    }
}
