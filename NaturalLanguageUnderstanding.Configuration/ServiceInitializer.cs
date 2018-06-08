using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NaturalLanguageUnderstanding.DataBase;
using NaturalLanguageUnderstanding.Logic;

namespace NaturalLanguageUnderstanding.Configuration {
	public interface ServiceInitializer {
		void Initialize(IServiceCollection serviceCollection);
	}

	public class ServiceInitializerImpl : ServiceInitializer {
		private readonly IConfiguration configuration;

		public ServiceInitializerImpl(IConfiguration configuration) {
			this.configuration = configuration;
		}

		public void Initialize(IServiceCollection serviceCollection) {
			InitializeDataBase(serviceCollection);
			InitializeLogical(serviceCollection);
			InitializeRepositories(serviceCollection);
		}

		private void InitializeLogical(IServiceCollection serviceCollection) {
			serviceCollection.AddTransient<WordFromText, WordFromTextImpl>();
		}

		private void InitializeRepositories(IServiceCollection serviceCollection) {
			serviceCollection.AddTransient<WordRepository, WordRepositoryImpl>();
		}

		private void InitializeDataBase(IServiceCollection serviceCollection) {
			serviceCollection.AddDbContext<ApplicationContext>(options => {
				options.UseSqlServer(configuration
					.GetConnectionString("DefaultConnection"));
			});
		}
	}
}
