using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessComponent
{
    public class DirectorsRepository : IDirectorsRepository, IDisposable
    {
        private readonly Context db;

        public DirectorsRepository(Context createdDb)
        {
            db = createdDb;
        }

        public void Add(Director item)
        {
            item.DirectorId = db.Directors.Count() + 1;
            db.Directors.Add(item);
            db.SaveChanges();
        }

        public List<Director> ReadAll()
        {
            return db.Directors.Count() > 0 ? db.Directors.ToList() : null;
        }

        public Director ReadById(int id)
        {
            return db.Directors.Find(id);
        }

        public void Update(Director item)
        {
            db.Directors.Update(item);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Directors.RemoveRange(ReadAll());
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            db.Directors.Remove(ReadById(id));
            db.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            db.Directors.Remove(FindByName(name));
            db.SaveChanges();
        }
        public Director FindByName(string name)
        {
            return db.Directors.FirstOrDefault(search => search.DirectorName == name);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
