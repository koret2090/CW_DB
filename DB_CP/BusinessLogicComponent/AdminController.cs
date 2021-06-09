using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent;


namespace BusinessLogicComponent
{
    public class AdminController : AbstractController
    {
        IUsersRepository _usersRepository;
        IStudiosRepository _studiosRepository;
        IDirectorsRepository _directorsRepository;
        public AdminController(IGenresRepository genres, IActorsRepository actors, IFilmsRepository films, 
            IUsersRepository usersRep, IDirectorsRepository dirsRep, IStudiosRepository studiosRep) :
            base(genres, actors, films)
        {
            _usersRepository = usersRep;
            _studiosRepository = studiosRep;
            _directorsRepository = dirsRep;
        }

        public void DeleteAllFilms()
        {
            _filmsRepository.DeleteAll();
        }

        public void DeleteFilmById(int id)
        {
            _filmsRepository.DeleteById(id);
        }

        public void DeleteFilmByName(string name)
        {
            _filmsRepository.DeleteByName(name);
        }

        public void AddFilm(Film film)
        {
            _filmsRepository.Add(film);
        }

        public void UpdateFilm(Film changedFilm)
        {
            _filmsRepository.Update(changedFilm);
        }

        public void DeleteAllActors()
        {
            _actorsRepository.DeleteAll();
        }

        public void DeleteActorById(int id)
        {
            _actorsRepository.DeleteById(id);
        }

        public void DeleteActorByName(string name)
        {
            _actorsRepository.DeleteByName(name);
        }

        public void AddActor(Actor actor)
        {
            _actorsRepository.Add(actor);
        }

        public void UpdateActor(Actor changedActor)
        {
            _actorsRepository.Update(changedActor);
        }

        public void DeleteAllDirectors()
        {
            _directorsRepository.DeleteAll();
        }

        public void DeleteDirectorById(int id)
        {
            _directorsRepository.DeleteById(id);
        }

        public void DeleteDirectorByName(string name)
        {
            _directorsRepository.DeleteByName(name);
        }

        public void AddDirector(Director director)
        {
            _directorsRepository.Add(director);
        }

        public void UpdateDirector(Director changedDirector)
        {
            _directorsRepository.Update(changedDirector);
        }

        public void DeleteAllStudios()
        {
            _studiosRepository.DeleteAll();
        }

        public void DeleteStudioById(int id)
        {
            _studiosRepository.DeleteById(id);
        }

        public void DeleteStudioByName(string name)
        {
            _studiosRepository.DeleteByName(name);
        }

        public void AddStudio(Studio studio)
        {
            _studiosRepository.Add(studio);
        }

        public void UpdateStudio(Studio changedStudio)
        {
            _studiosRepository.Update(changedStudio);
        }

        public void DeleteAllGenres()
        {
            _genresRepository.DeleteAll();
        }

        public void DeleteGenreById(int id)
        {
            _genresRepository.DeleteById(id);
        }

        public void DeleteGenreByName(string name)
        {
            _genresRepository.DeleteByName(name);
        }

        public void AddGenre(Genre genre)
        {
            _genresRepository.Add(genre);
        }

        public void DeleteAllUsers()
        {
            _usersRepository.DeleteAll();
        }

        public void DeleteUserById(int id)
        {
            _usersRepository.DeleteById(id);
        }

        public void DeleteUserByName(string name)
        {
            _usersRepository.DeleteByName(name);
        }

        public void AddUser(User user)
        {
            _usersRepository.Add(user);
        }

        public void UpdateUser(User changedUser)
        {
            _usersRepository.Update(changedUser);
        }

        public List<Director> GetAllDirectors()
        {
            return _directorsRepository.ReadAll();
        }

        public List<Studio> GetAllStudios()
        {
            return _studiosRepository.ReadAll();
        }

        public List<User> GetAllUsers()
        {
            return _usersRepository.ReadAll();
        }
    }
}
