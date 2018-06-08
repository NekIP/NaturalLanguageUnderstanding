namespace NaturalLanguageUnderstanding.Data {
	public class Word : Entity {
		public string Value { get; set; }
		public float Weight { get; set; }

		public Word(string value) {
			Value = value;
		}

		public Word(string value, 
			float weight) {
			Value = value;
			Weight = weight;
		}
	}
}
