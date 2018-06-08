using System.Threading.Tasks;
using NaturalLanguageUnderstanding.Configuration;

namespace NaturalLanguageUnderstanding.ConsoleApplication {
	public class Program {
		public static void Main(string[] args) {
			Configurator.Initialize("appsettings.json");
			var startup = Configurator.SetEntryPointAndBuild<Startup, StartupImpl>();
			Task.WaitAll(startup.Execute());
		}
	}
}
