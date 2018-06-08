using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NaturalLanguageUnderstanding.Data;

namespace NaturalLanguageUnderstanding.DataBase {
	public class ApplicationContext : DbContext {
		private readonly IConfiguration configuration;

		public ApplicationContext(IConfiguration configuration) {
			this.configuration = configuration;
			Database.EnsureCreated();
		}

		public DbSet<Word> Words { get; set; }

		protected override void OnConfiguring(
			DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer(configuration
				.GetConnectionString("natural-language-understanding"));
		}
	}
}
