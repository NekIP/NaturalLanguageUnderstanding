using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NaturalLanguageUnderstanding.DataBase {
	public interface Repository<T> where T : class {
		List<T> List();
		List<T> List(Expression<Func<T, bool>> predicate);
		void Insert(T entity);
		void Insert(IEnumerable<T> entities);
		void Update(T entity);
		void Update(IEnumerable<T> entities);
		void Remove(T entity);
		void Remove(IEnumerable<T> entities);
	}
}
