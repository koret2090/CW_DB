using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessComponent
{
    public class StudiosRepository : IStudiosRepository, IDisposable
    {
        private readonly Context db;

        public StudiosRepository(Context createdDb)
        {
            db = createdDb;
        }

        public void Add(Studio item)
        {
            item.StudioId = db.Studios.Count() + 1;
            db.Studios.Add(item);
            db.SaveChanges();
        }

        public List<Studio> ReadAll()
        {
            return db.Studios.Count() > 0 ? db.Studios.ToList() : null;
        }

        public Studio ReadById(int id)
        {
            return db.Studios.Find(id);
        }

        public void Update(Studio item)
        {
            db.Studios.Update(item);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Studios.RemoveRange(ReadAll());
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            db.Studios.Remove(ReadById(id));
            db.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            db.Studios.Remove(FindByName(name));
            db.SaveChanges();
        }

        public Studio FindByName(string name)
        {
            return db.Studios.FirstOrDefault(search => search.StudioName == name);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
