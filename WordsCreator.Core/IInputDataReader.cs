using System;
using System.Collections.Generic; 

namespace WordsCreator.Core
{
    /// <summary>
    /// Interface to be used for retrieving source data and returning the list 
    /// of strings for further processing.
    /// </summary>
    public interface IInputDataReader
    {
        /// <summary>
        /// Method to be implemented to take the data from the particular datasource(textfile, database etc).
        /// The interface implementation class is a place for input source data retrieving logic
        /// to return the list of strings which client code expects.  
        /// </summary>
        /// <returns>The list of words from the source.</returns>
        IEnumerable<string> RetrieveInputData();
    }
}
