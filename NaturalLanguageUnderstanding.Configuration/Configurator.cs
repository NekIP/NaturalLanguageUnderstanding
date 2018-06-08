using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NaturalLanguageUnderstanding.Configuration {
	public static class Configurator {
		private static ServiceCollection serviceCollection = new ServiceCollection();

		public static void Initialize(string configurtionFileName) {
			InitializeConfiguration(configurtionFileName);
			InitializeServices();
		}

		private static void InitializeServices() {
			var serviceProvider = serviceCollection
				.AddTransient<ServiceInitializer, ServiceInitializerImpl>()
				.BuildServiceProvider();
			var serviceInitializer = serviceProvider.GetService<ServiceInitializer>();
			serviceInitializer.Initialize(serviceCollection);
		}

		private static void InitializeConfiguration(string fileName) {
			var configuration = new ConfigurationBuilder()
				.AddJsonFile(fileName)
				.Build();
			serviceCollection.AddSingleton<IConfiguration>(configuration);
		}

		public static TAbstraction SetEntryPointAndBuild<TAbstraction, TImplementation>()
			where TAbstraction : class 
			where TImplementation : class, TAbstraction {
			var serviceProvider = serviceCollection
				.AddTransient<TAbstraction, TImplementation>()
				.BuildServiceProvider();
			return serviceProvider.GetService<TAbstraction>();
		}
	}
}
