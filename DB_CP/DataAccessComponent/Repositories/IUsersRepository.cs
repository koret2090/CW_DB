using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessComponent
{
    public interface IUsersRepository: CrudRepository<User>
    {
        void AddFavouriteActor(string actorName, int userId);

        void AddFavouriteGenre(string genreName, int userId);

        void DeleteFavouriteActor(string actorName, int userId);

        void DeleteFavouriteGenre(string genreName, int userId);

        public List<Recommends> GetRecommendFilms(int userId);

        public List<Genre> GetFavouriteGenres(User user);

        public List<Actor> GetFavouriteActors(User user);
    }
}
