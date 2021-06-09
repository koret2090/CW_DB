using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent;

namespace BusinessLogicComponent
{
    public class UserController : AbstractController
    {
        IUsersRepository _usersRepository;
        public UserController(IGenresRepository genres, IActorsRepository actors, IFilmsRepository films, IUsersRepository usersRep) :
            base(genres, actors, films)
        {
            _usersRepository = usersRep;
        }

        public void AddFavouriteActor(string name, int user_id)
        {
            _usersRepository.AddFavouriteActor(name, user_id);
        }

        public void AddFavouriteGenre(string name, int user_id)
        {
            _usersRepository.AddFavouriteGenre(name, user_id);
        }

        public void DeleteFavouriteActor(string name, int user_id)
        {
            _usersRepository.DeleteFavouriteActor(name, user_id);
        }

        public void DeleteFavouriteGenre(string name, int user_id)
        {
            _usersRepository.DeleteFavouriteGenre(name, user_id);
        }

        public Genre GetGenreByName(string name)
        {
            return _genresRepository.FindByName(name);
        }

        public List<Genre> GetFavouriteGenres(User user)
        {
            return _usersRepository.GetFavouriteGenres(user);
        }

        public List<Actor> GetFavouriteActors(User user)
        {
            return _usersRepository.GetFavouriteActors(user);
        }

        public List<Recommends> GetRecommendFilms(int user_id)
        {
            return _usersRepository.GetRecommendFilms(user_id);
        }
    }
}
