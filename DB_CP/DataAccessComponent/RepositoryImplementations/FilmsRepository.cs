using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessComponent
{
    public class FilmsRepository : IFilmsRepository, IDisposable
    {
        private readonly Context db;

        public FilmsRepository(Context createdDb)
        {
            db = createdDb;
        }

        public void Add(Film item)
        {
            item.FilmId = db.Films.Count() + 1;
            db.Films.Add(item);
            db.SaveChanges();
        }

        public List<Film> ReadAll()
        {
            return db.Films.Count() > 0 ? db.Films.ToList() : null;
        }

        public Film ReadById(int id)
        {
            return db.Films.Find(id);
        }

        public void Update(Film item)
        {
            db.Films.Update(item);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Films.RemoveRange(ReadAll());
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            db.Films.Remove(ReadById(id));
            db.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            db.Films.Remove(FindByName(name));
            db.SaveChanges();
        }

        public Film FindByName(string name)
        {
            return db.Films.FirstOrDefault(search => search.FilmName == name);
        }

        public List<Film> GetFilmsByGenre(string genre)
        {
            IQueryable<Film> films = db.Films.Where(f => f.Genre.GenreName == genre);
            return films.Count() > 0 ? films.ToList() : null;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
