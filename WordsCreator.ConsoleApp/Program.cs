using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using WordsCreator.Core;



namespace WordsCreator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputDataReader reader = ServiceProviderManager.GetServiceProvider().GetService<IInputDataReader>();
            IEnumerable<string> inputData = reader.RetrieveInputData().Distinct();
            var processor = new WordsProcessor(6, inputData);
            IEnumerable<Tuple<string, string>> res = processor.GenerateWordCombinations();

            
            foreach(var r in res)
            {
                Console.WriteLine(ConsoleViewTemplate.Apply(r.Item1, r.Item2));    
            }
            
        }
        
    }
}
