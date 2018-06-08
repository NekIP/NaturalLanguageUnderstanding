using Microsoft.EntityFrameworkCore;
using NaturalLanguageUnderstanding.Data;

namespace NaturalLanguageUnderstanding.DataBase {
	public interface WordRepository : Repository<Word> {}
	public class WordRepositoryImpl 
		: RepositoryImpl<Word>, WordRepository {

		public WordRepositoryImpl(ApplicationContext dataBase) 
			: base(dataBase) { }

		protected override DbSet<Word> Table => 
			DataBase.Words;
	}
}
