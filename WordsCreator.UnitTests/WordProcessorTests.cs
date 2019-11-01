using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using WordsCreator.Core;

namespace WordsCreator.UnitTests
{
    public class WordProcessorTests
    {
        
        [Theory]
        [InlineData(6,3)]
        [InlineData(5,0)]
        public void WordProcessorTests_BasicCase(int maxWordLength, int expected)
        {
            
            List<string> words = new List<string>()
            {
                { "bas" },
                { "alt" },
                {"basalt"},
                {"b"},
                {"asalt"},
                {"basal"},
                {"t"}
            };
            var processor = new WordsProcessor(maxWordLength, words);
            IEnumerable<Tuple<string, string>> gluedWords = processor.GenerateWordCombinations();
            int result = gluedWords.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void WordProcessorTests_EmptyList()
        {
            int maxWordLength = 6;
            List<string> words = new List<string>();
            var processor = new WordsProcessor(maxWordLength, words);
            IEnumerable<Tuple<string, string>> gluedWords = processor.GenerateWordCombinations();
            Assert.True(gluedWords.Count() == 0);
        }

        [Fact]
        public void WordProcessorTests_EmptyWordsAndGaps()
        {
            int maxWordLength = 6;
            
            List<string> words = new List<string>()
            {
                { string.Empty },
                { string.Empty },
                { string.Empty },
                { string.Empty },
                { string.Empty },
                {" "},
                {" "}
            };
            var processor = new WordsProcessor(maxWordLength, words);
            IEnumerable<Tuple<string, string>> gluedWords = processor.GenerateWordCombinations();
            Assert.True(gluedWords.Count() == 0);
        }

    }
}
