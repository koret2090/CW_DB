using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent;
using System.Linq;

namespace BusinessLogicComponent
{
    public abstract class AbstractController
    {
        protected IGenresRepository _genresRepository;
        protected IActorsRepository _actorsRepository;
        protected IFilmsRepository _filmsRepository;
        //protected User _userInfo;

        public AbstractController(IGenresRepository genres, IActorsRepository actors, IFilmsRepository films)
        {
            _genresRepository = genres;
            _actorsRepository = actors;
            _filmsRepository = films;
        }
        public List<Actor> GetAllActors()
        {
            return _actorsRepository.ReadAll();
        }

        public List<Film> GetAllFilms()
        {
            return _filmsRepository.ReadAll();
        }

        public List<Genre> GetAllGenres()
        {
            return _genresRepository.ReadAll();
        }

        public Actor GetActorById(int id)
        {
            return _actorsRepository.ReadById(id);
        }

        public Film GetFilmById(int id)
        {
            return _filmsRepository.ReadById(id);
        }

        public List<Film> GetFilmsByGenre(string genre)
        {
            return _filmsRepository.GetFilmsByGenre(genre);
        }

        public List<Actor> GetActorsByGenre(string genre)
        {
            return _actorsRepository.GetActorsByGenre(genre);
        }

        public List<Actor> GetActorsByFilm(string name)
        {
            return _actorsRepository.GetActorsByFilm(name);
        }

        public Film GetFilmByName(string name)
        {
            return _filmsRepository.FindByName(name);
        }

        public Actor GetActorByName(string name)
        {
            return _actorsRepository.FindByName(name);
        }
    }
}
