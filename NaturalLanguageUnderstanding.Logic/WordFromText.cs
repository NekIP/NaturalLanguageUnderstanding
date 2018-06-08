using System.Collections.Generic;
using System.Text.RegularExpressions;
using NaturalLanguageUnderstanding.Data;

namespace NaturalLanguageUnderstanding.Logic {
	public interface WordFromText {
		List<Word> Extract(string text);
	}
	public class WordFromTextImpl : WordFromText {
		private const string wordsPattern = @"\w";

		public List<Word> Extract(string text) {

			var wordsFinder = new Regex(wordsPattern);
			var matches = wordsFinder.Matches(text);
			/*foreach (Match match in matches) {
				match.Value
			}*/
			throw new System.NotImplementedException();
		}
	}
}
