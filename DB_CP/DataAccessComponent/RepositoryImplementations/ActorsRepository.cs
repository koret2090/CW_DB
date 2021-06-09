using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessComponent
{
    public class ActorsRepository : IActorsRepository, IDisposable
    {
        private readonly Context db;

        public ActorsRepository(Context createdDb)
        {
            db = createdDb;
        }

        public void Add(Actor item)
        {
            item.ActorId = db.Actors.Count() + 1;
            db.Actors.Add(item);
            db.SaveChanges();
        }

        public List<Actor> ReadAll()
        {
            return db.Actors.Count() > 0 ? db.Actors.ToList() : null;
        }

        public Actor ReadById(int id)
        {
            return db.Actors.Find(id);
        }

         public void Update(Actor item)
        {
            db.Actors.Update(item);
            db.SaveChanges();
        }
          
        public void DeleteAll()
        {
            db.Actors.RemoveRange(ReadAll());
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            db.Actors.Remove(ReadById(id));
            db.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            db.Actors.Remove(FindByName(name));
            db.SaveChanges();
        }

        public Actor FindByName(string name)
        {
            return db.Actors.FirstOrDefault(search => search.ActorName == name);
        }

        public List<Actor> GetActorsByGenre(string genre)
        {
            IQueryable<Actor> actors = db.Actors.Where(act => act.Film.Genre.GenreName == genre);
            return actors.Count() > 0 ? actors.ToList() : null;
        }

        public List<Actor> GetActorsByFilm(string name)
        {
            IQueryable<Actor> actors = db.Actors.Where(act => act.Film.FilmName == name);
            return actors.Count() > 0 ? actors.ToList() : null;
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
