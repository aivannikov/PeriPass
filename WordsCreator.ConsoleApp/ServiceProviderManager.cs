using System;
using WordsCreator.Core;
using Microsoft.Extensions.DependencyInjection;

namespace WordsCreator.ConsoleApp
{

    /// <summary>
    ///  The purpose of the class is to give service provider thus impelemnting 
    ///  Dependency injection pattern.
    /// Service provider instance has a global scope.
    /// </summary>
    public static class ServiceProviderManager
    {

        /// <summary>
        /// IServiceProvider instane that is given to the client code.
        /// </summary>
        private static IServiceProvider _ServiceProvider;
        
        /// <summary>
        /// Gives service provider instance to the client code.
        /// Instance is created once per application run.
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider GetServiceProvider()
        {
            if(_ServiceProvider == null)
            {
                _ServiceProvider = ConfigureServices();
            }
            return _ServiceProvider;
        }

        /// <summary>
        /// Initializes the dependencies and returns service provider. 
        /// </summary>
        /// <returns>IServiceProvider instance with dependencies</returns>
        private static IServiceProvider ConfigureServices()
        {
                var collection = new ServiceCollection();
                collection.AddScoped<IInputDataReader>(c => new TextFileInputDataReader(@"InputData/input.txt"));
                return collection.BuildServiceProvider();
        }

    }
}