using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessComponent
{
    public class UsersRepository : IUsersRepository, IDisposable
    {
        private readonly Context db;

        public UsersRepository(Context createdDb)
        {
            db = createdDb;
        }

        public void Add(User item)
        {
            item.UserId = db.Users.Count() + 1;
            db.Users.Add(item);
            db.SaveChanges();
        }

        public List<User> ReadAll()
        {
            return db.Users.Count() > 0 ? db.Users.ToList() : null;
        }

        public User ReadById(int id)
        {
            return db.Users.Find(id);
        }

        public void Update(User item)
        {
            db.Users.Update(item);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Users.RemoveRange(ReadAll());
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            db.Users.Remove(ReadById(id));
            db.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            db.Users.Remove(FindByName(name));
            db.SaveChanges();
        }

        public User FindByName(string name)
        {
            return db.Users.FirstOrDefault(search => search.Login == name);
        }
        
        public void AddFavouriteActor(string actorName, int userId)
        {
            Actor actor = db.Actors.FirstOrDefault(search => search.ActorName == actorName);
            if (actor != null)
            {
                UserActor link = new UserActor { ActorId = actor.ActorId, UserId = userId };
                if (db.UserActors.FirstOrDefault(
                    search => search.ActorId == link.ActorId && search.UserId == link.UserId) == null)
                {
                    string command = "INSERT INTO user_actors VALUES ( " + Convert.ToString(link.UserId) +
                        ", " + Convert.ToString(link.ActorId) + ");";
                    db.Database.ExecuteSqlRaw(command);
                    //db.UserGenres.Add(link);
                    db.SaveChanges();
                }
            }     
        }   

        public void AddFavouriteGenre(string genreName, int userId)
        {
            Genre genre = db.Genres.FirstOrDefault(search => search.GenreName == genreName);
            if (genre != null)
            {
                UserGenre link = new UserGenre { GenreId = genre.GenreId, UserId = userId };
                if (db.UserGenres.FirstOrDefault(
                    search => search.GenreId == link.GenreId && search.UserId == link.UserId) == null)
                {
                    string command = "INSERT INTO user_genres VALUES ( " + Convert.ToString(link.UserId) +
                        ", " + Convert.ToString(link.GenreId) + ");";
                    db.Database.ExecuteSqlRaw(command);
                    //db.UserGenres.Add(link);
                    db.SaveChanges();
                }   
            }
        }

        public List<Recommends> GetRecommendFilms(int userId)
        {
            IQueryable<Recommends> films = db.get_recommended_films(userId);

            return films.Count() > 0 ? films.ToList() : null;
        }

        public void DeleteFavouriteActor(string actorName, int userId)
        {
            Actor actor = db.Actors.FirstOrDefault(search => search.ActorName == actorName);
            if (actor != null)
            {
                UserActor link = db.UserActors.FirstOrDefault(search => search.ActorId == actor.ActorId
                    && search.UserId == userId);
                if (link != null)
                {
                    string command = "DELETE FROM user_actors where user_id = " + Convert.ToString(link.UserId) +
                        "and actor_id = " + Convert.ToString(link.ActorId) + ";";
                    db.Database.ExecuteSqlRaw(command);
                    //db.UserActors.Remove(link);
                    //db.Entry(link).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteFavouriteGenre(string genreName, int userId)
        {
            Genre genre = db.Genres.FirstOrDefault(search => search.GenreName == genreName);
            if (genre != null)
            {
                UserGenre link = db.UserGenres.FirstOrDefault(search => search.GenreId == genre.GenreId
                    && search.UserId == userId);
                if (link != null)
                {
                    string command = "DELETE FROM user_genres where user_id = " + Convert.ToString(link.UserId) +
                        "and genre_id = " + Convert.ToString(link.GenreId) + ";";
                    db.Database.ExecuteSqlRaw(command);
                    db.SaveChanges();
                }
            }
        }

        public List<Genre> GetFavouriteGenres(User user)
        {
            IQueryable<Genre> genres = db.Genres.Where(searchGenre => searchGenre.GenreId ==
                (db.UserGenres.FirstOrDefault(search => search.GenreId == searchGenre.GenreId && search.UserId == user.UserId)).GenreId);

            return genres.Count() > 0 ? genres.ToList() : null;
        }

        public List<Actor> GetFavouriteActors(User user)
        {
            IQueryable<Actor> actors = db.Actors.Where(searchActor => searchActor.ActorId ==
                (db.UserActors.FirstOrDefault(search => search.ActorId == searchActor.ActorId && search.UserId == user.UserId)).ActorId);

            return actors.Count() > 0 ? actors.ToList() : null;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
