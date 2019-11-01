using System;
using System.Collections.Generic;

namespace WordsCreator.Core
{
    /// <summary>
    /// Incaplusates the business logic for processing word parts 
    /// and generating the right combinations.
    /// </summary>
    public class WordsProcessor
    {
        private readonly int Max_Word_Length;
        /// <summary>
        /// The input data words list.
        /// </summary>
        private IEnumerable<string> _wordPartsList;
        
        /// <summary>
        /// Keeps the word groups.
        /// In this implementation all the words from the source are allocated 
        /// in groups by the word length.
        /// The dictionary key is the number of symbols in string for processing purposes.
        /// </summary>
        private IDictionary<int, IList<string>> _wordPartsGroups;
        
        /// <summary>
        /// Reprsents a list of tuples.
        /// Each tuple contains 2 int values for group indexes.
        /// First item and second item could potentially match the right combination.
        /// This is the reason for creating this field.  
        /// </summary>
        private IList<Tuple<int, int>> _pairWordPartsGroupKeys;
        
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="maxLength">The max number of symbols in the word for generating combinations.</param>
        /// <param name="wordPartsList">The input data list of words to process.</param>
        public WordsProcessor(int maxLength, IEnumerable<string> wordPartsList)
        {
            Max_Word_Length = maxLength;
            _wordPartsList = wordPartsList;
            _wordPartsGroups = new Dictionary<int, IList<string>>();
        }

        /// <summary>
        /// As part of the algorithm- word groups are created.
        /// The group criteria- number of symbols in string.
        /// Filles _wordPartsGroups with the necessary keys.
        /// </summary>
        private void CreateWordGroups()
        {
            for(int i = 1; i <= Max_Word_Length; i++)
            {
                _wordPartsGroups.Add(i, new List<string>());
            }
        }

        /// <summary>
        /// As part of the algorithm- the pair of groups with potential combination match is created.
        /// Filles _pairWordPartsGroupKeys for future usage in the algorithm.
        /// </summary>
        private void CreatePairWordGroupKeys()
        {
            int numberOfPairedGroups = Max_Word_Length / 2;
            int descendingCounter = Max_Word_Length;
            _pairWordPartsGroupKeys = new List<Tuple<int, int>>();
            for(int i = 1; i <= numberOfPairedGroups; i++ )
            {
                _pairWordPartsGroupKeys.Add(new Tuple<int, int>(--descendingCounter, i));
            }
        }

        /// <summary>
        /// Filling the word groups from the input data.
        /// Filles _wordPartsGroups field with words. 
        /// </summary>
        private void FillWordGroups()
        {
            foreach(string word in _wordPartsList)
            {
                string trimmedWord = word.Trim();
                int wordLength = trimmedWord.Length;
                if(wordLength <= Max_Word_Length && !string.IsNullOrEmpty(trimmedWord))
                {
                    _wordPartsGroups[wordLength].Add(word);
                }
            }
        }

        /// <summary>
        /// Generates the combinations for the paired groups.
        /// </summary>
        /// <param name="groupPair">The group pair that could contain a combination.</param>
        /// <param name="wordToCompare">The word we are searching the right combination for.</param>
        /// <returns>The list of combinations that match the criteria.</returns>
        private IList<Tuple<string, string>> GetGroupPairCombinations(Tuple<int, int> groupPair, string wordToCompare)
        {
            IList<Tuple<string, string>> groupPairResult = new List<Tuple<string, string>>();
            IList<string> firstWordsGroup = _wordPartsGroups[groupPair.Item1];
            IList<string> secondWordsGroup = _wordPartsGroups[groupPair.Item2];
            foreach(string wordFirst in firstWordsGroup)
            {
                foreach(string wordSecond in secondWordsGroup)
                {
                    if(string.Equals((wordFirst + wordSecond ), wordToCompare))
                    {
                        groupPairResult.Add(new Tuple<string, string>(wordFirst, wordSecond));
                    }
                    else
                        if(string.Equals((wordSecond + wordFirst), wordToCompare) && groupPair.Item1 != groupPair.Item2)
                        {
                            groupPairResult.Add(new Tuple<string, string>(wordSecond, wordFirst));
                        }
                }
            }
            return groupPairResult;
        }
        
        /// <summary>
        /// Method to be called from the client code.
        /// Contains the implementation algorithm for generation word combinations.
        /// </summary>
        /// <returns>The list of word combinations that meet the criteria.</returns>
         public IEnumerable<Tuple<string, string>> GenerateWordCombinations()
         {
             List<Tuple<string, string>> result = new List<Tuple<string, string>>();
             CreateWordGroups();
             FillWordGroups();
             CreatePairWordGroupKeys();
             IList<string> completeWords = _wordPartsGroups[Max_Word_Length];
             foreach(string entireWord in completeWords)
             {
                 foreach(Tuple<int, int> pairGroup in _pairWordPartsGroupKeys)
                 {
                     result.AddRange(GetGroupPairCombinations(pairGroup, entireWord)); 
                 }
             }
            return result;
         }


    }
}