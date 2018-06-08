using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace NaturalLanguageUnderstanding.DataBase {
	public abstract class RepositoryImpl<T> 
		: Repository<T> where T : class {

		public RepositoryImpl(ApplicationContext dataBase) {
			DataBase = dataBase;
		}

		protected ApplicationContext DataBase { get; private set; }
		protected IQueryable<T> Entities => Table.AsNoTracking();
		protected abstract DbSet<T> Table { get; }

		public void Insert(T entity) {
			var result = Table.Add(entity);
			result.State = EntityState.Detached;
			DataBase.SaveChanges();
		}
		public void Insert(IEnumerable<T> entities) {
			foreach (var entity in entities) {
				Insert(entity);
			}
		}
		public List<T> List() =>
			Entities.ToList();

		public List<T> List(Expression<Func<T, bool>> predicate) =>
			Entities.Where(predicate).ToList();

		public void Remove(T entity) {
			Table.Remove(entity);
			DataBase.SaveChanges();
		}

		public void Remove(IEnumerable<T> entities) {
			foreach (var entity in entities) {
				Remove(entity);
			}
		}

		public void Update(T entity) {
			var attached = Table.Attach(entity);
			attached.State = EntityState.Modified;
			DataBase.SaveChanges();
			attached.State = EntityState.Detached;
		}

		public void Update(IEnumerable<T> entities) {
			foreach (var entity in entities) {
				Update(entity);
			}
		}
	}
}
