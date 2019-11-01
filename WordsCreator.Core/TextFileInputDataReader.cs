using System;
using System.IO;
using System.Collections.Generic;

namespace WordsCreator.Core
{
    /// <summary>
    /// The implementation of IInputDataReader to get data from the text file.
    /// </summary>   
    public class TextFileInputDataReader : IInputDataReader
    {
        /// <summary>
        /// The path to the file.
        /// </summary>
        private string _path;
        
        /// <summary>
        /// Constructor that accepts the file path. 
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public TextFileInputDataReader(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Implements the interface method for text file retrieving.
        /// </summary>
        /// <returns>The list of words from the file.</returns>
        public IEnumerable<string> RetrieveInputData()
        {
            return File.ReadAllLines(_path);
        }

    }
}