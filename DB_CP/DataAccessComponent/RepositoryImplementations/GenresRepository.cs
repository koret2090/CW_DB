using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessComponent
{
    public class GenresRepository : IGenresRepository, IDisposable
    {
        private readonly Context db;

        public GenresRepository(Context createdDb)
        {
            db = createdDb;
        }

        public void Add(Genre item)
        {
            item.GenreId = db.Genres.Count() + 1;
            db.Genres.Add(item);
            db.SaveChanges();
        }

        public List<Genre> ReadAll()
        {
            return db.Genres.Count() > 0 ? db.Genres.ToList() : null;
        }

        public Genre ReadById(int id)
        {
            return db.Genres.Find(id);
        }

        public void Update(Genre item)
        {
            db.Genres.Update(item);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Genres.RemoveRange(ReadAll());
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            db.Genres.Remove(ReadById(id));
            db.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            db.Genres.Remove(FindByName(name));
            db.SaveChanges();
        }

        public Genre FindByName(string name)
        {
            return db.Genres.FirstOrDefault(search => search.GenreName == name);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
