using System;
using System.Threading.Tasks;
using NaturalLanguageUnderstanding.DataBase;

namespace NaturalLanguageUnderstanding.ConsoleApplication {
	public interface Startup {
		Task Execute();
	}
	public class StartupImpl : Startup {
		public StartupImpl(WordRepository wordRepository) {

		}

		public async Task Execute() {
			Console.WriteLine("hello");
			Console.ReadKey();
		}
	}
}
