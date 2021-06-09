using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessComponent
{
	public interface CrudRepository<T>
	{
		void Add(T item);
		List<T> ReadAll();
		T ReadById(int id);
		T FindByName(string name);
		void Update(T item);
		void DeleteAll();
		void DeleteById(int id);
		void DeleteByName(string name);
	}
}
