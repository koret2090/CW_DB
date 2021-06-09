using System;
using BusinessLogicComponent;
using DataAccessComponent;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Generic;


namespace TechnicalUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder cfg = new ConfigurationBuilder();
            var _config = cfg
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            TechUI ui = new TechUI();
            ui.Run();
        }   
    }

    class TechUI
    {
        public const int SHOW_NUMBER = 49;

        private GuestController _guest;
        private UserController _user;
        private AdminController _admin;

        private Context _context;


        public TechUI()
        {
            _context = new Context();
            IActorsRepository actorsRepository = new ActorsRepository(_context);
            IDirectorsRepository directorsRepository = new DirectorsRepository(_context);
            IFilmsRepository filmsRepository = new FilmsRepository(_context);
            IGenresRepository genresRepository = new GenresRepository(_context);
            IStudiosRepository studiosRepository = new StudiosRepository(_context);
            IUsersRepository usersRepository = new UsersRepository(_context);

            _guest = new GuestController(genresRepository, actorsRepository, filmsRepository);
            _user = new UserController(genresRepository, actorsRepository, filmsRepository, usersRepository);
            _admin = new AdminController(genresRepository, actorsRepository, filmsRepository, 
                usersRepository, directorsRepository, studiosRepository);


        }

        public void Run()
        {
            int choice = 100;

            while(choice > 0)
            {
                Console.WriteLine("TechUI checking\n" +
                    "1 - Guest\n" +
                    "2 - User\n" +
                    "3 - Admin\n" +
                    "0 - Выход\n" +
                    "Ваш выбор: ");
                
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CheckGuest();
                        break;
                    case 2:
                        CheckUser();
                        break;
                    case 3:
                        CheckAdmin();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Неверно введен номер");
                        break;

                }    
            }
        }

        void CheckGuest()
        {
            int choice = 100;

            while (choice > 0)
            {
                Console.WriteLine("TechUI checking\n" +
                    "1 - Показать всех актеров\n" +
                    "2 - Показать все фильмы\n" +
                    "3 - Показать все жанры\n" +
                    "4 - Получить актера по id\n" +
                    "5 - Получить фильм по id\n" +
                    "6 - Получить фильмы по жанру\n" +
                    "7 - Получить актеров по жанру\n" +
                    "8 - Получить актеров по фильму\n" +
                    "9 - Получить фильм по названию\n" +
                    "10 - Получить актера по имени\n" +
                    "0 - Выход в предыдущее меню\n" +
                    "Ваш выбор: ");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        GetAllActors();
                        break;
                    case 2:
                        GetAllFilms();
                        break;
                    case 3:
                        GetAllGenres();
                        break;
                    case 4:
                        GetActorById();
                        break;
                    case 5:
                        GetFilmById();
                        break;
                    case 6:
                        GetFilmsByGenre();
                        break;
                    case 7:
                        GetActorsByGenre();
                        break;
                    case 8:
                        GetActorsByFilm();
                        break;
                    case 9:
                        GetFilmByName();
                        break;
                    case 10:
                        GetActorByName();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Неверно введен номер");
                        break;
                }
            }
        }

        void GetAllActors()
        {
            List<Actor> actors = _guest.GetAllActors();
            if (actors != null)
            {
                int counter = 0;
                foreach (Actor actor in actors)
                {
                    Console.WriteLine(Convert.ToString(actor.ActorId) + " " +
                        Convert.ToString(actor.FilmId) + " " +
                        Convert.ToString(actor.ActorName) + " " +
                        Convert.ToString(actor.Age) + " " +
                        Convert.ToString(actor.Sex) + " " +
                        Convert.ToString(actor.Nationality) + " " +
                        Convert.ToString(actor.Fee) + " " +
                        Convert.ToString(actor.Awards));
                        
                    counter++;
                    if (counter > SHOW_NUMBER)
                        break;
                }
                
            }
            else
            {
                Console.WriteLine("Актеры не найдены");
            }
        }

        void GetAllFilms()
        {
            List<Film> films = _guest.GetAllFilms();
            if (films != null)
            {
                int counter = 0;
                foreach (Film film in films)
                {
                    Console.WriteLine(Convert.ToString(film.FilmId) + " " +
                        Convert.ToString(film.StudioId) + " " +
                        Convert.ToString(film.GenreId) + " " +
                        Convert.ToString(film.DirectorId) + " " +
                        Convert.ToString(film.FilmName) + " " +
                        Convert.ToString(film.ReleaseDate) + " " +
                        Convert.ToString(film.Budget) + " " +
                        Convert.ToString(film.Fees) + " " +
                        Convert.ToString(film.AvgPrice));

                    counter++;
                    if (counter > SHOW_NUMBER)
                        break;
                }                
            }
            else
            {
                Console.WriteLine("Фильмы не найдены");
            }
        }

        void GetAllGenres()
        {
            List<Genre> genres = _guest.GetAllGenres();
            if (genres != null)
            {
                foreach (Genre genre in genres)
                {
                    Console.WriteLine(Convert.ToString(genre.GenreId) + " " +
                        Convert.ToString(genre.GenreName));
                }     
            }
            else
            {
                Console.WriteLine("Фильмы не найдены");
            }
        }

        void GetActorById()
        {
            Console.WriteLine("Введите id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            Actor actor = _guest.GetActorById(id);
            if (actor != null)
            {
                Console.WriteLine(Convert.ToString(actor.ActorId) + " " +
                           Convert.ToString(actor.FilmId) + " " +
                           Convert.ToString(actor.ActorName) + " " +
                           Convert.ToString(actor.Age) + " " +
                           Convert.ToString(actor.Sex) + " " +
                           Convert.ToString(actor.Nationality) + " " +
                           Convert.ToString(actor.Fee) + " " +
                           Convert.ToString(actor.Awards));
            }
            else
            {
                Console.WriteLine("Актер не найден");
            }
        }

        void GetFilmById()
        {
            Console.WriteLine("Введите id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Film film = _guest.GetFilmById(id);
            if (film != null)
            {
                Console.WriteLine(Convert.ToString(film.FilmId) + " " +
                            Convert.ToString(film.StudioId) + " " +
                            Convert.ToString(film.GenreId) + " " +
                            Convert.ToString(film.DirectorId) + " " +
                            Convert.ToString(film.FilmName) + " " +
                            Convert.ToString(film.ReleaseDate) + " " +
                            Convert.ToString(film.Budget) + " " +
                            Convert.ToString(film.Fees) + " " +
                            Convert.ToString(film.AvgPrice));
            }
            else
            {
                Console.WriteLine("Фильм не найден");
            }
        }

        void GetFilmsByGenre()
        {
            Console.WriteLine("Введите название жанра: ");
            string genreName = Console.ReadLine();

            List<Film> films = _guest.GetFilmsByGenre(genreName);
            if (films != null)
            {
                int counter = 0;

                foreach (Film film in films)
                {
                    Console.WriteLine(Convert.ToString(film.FilmId) + " " +
                        Convert.ToString(film.StudioId) + " " +
                        Convert.ToString(film.GenreId) + " " +
                        Convert.ToString(film.DirectorId) + " " +
                        Convert.ToString(film.FilmName) + " " +
                        Convert.ToString(film.ReleaseDate) + " " +
                        Convert.ToString(film.Budget) + " " +
                        Convert.ToString(film.Fees) + " " +
                        Convert.ToString(film.AvgPrice));

                    counter++;
                    if (counter > SHOW_NUMBER)
                        break;
                }
                
            }
            else
            {
                Console.WriteLine("Фильмы не найдены");
            }
        }

        void GetActorsByGenre()
        {
            Console.WriteLine("Введите название жанра: ");
            string genreName = Console.ReadLine();

            List<Actor> actors = _guest.GetActorsByGenre(genreName);
            if (actors != null)
            {
                int counter = 0;

                foreach (Actor actor in actors)
                {
                    Console.WriteLine(Convert.ToString(actor.ActorId) + " " +
                        Convert.ToString(actor.FilmId) + " " +
                        Convert.ToString(actor.ActorName) + " " +
                        Convert.ToString(actor.Age) + " " +
                        Convert.ToString(actor.Sex) + " " +
                        Convert.ToString(actor.Nationality) + " " +
                        Convert.ToString(actor.Fee) + " " +
                        Convert.ToString(actor.Awards));

                    counter++;
                    if (counter > SHOW_NUMBER)
                        break;
                }               
            }
            else
            {
                Console.WriteLine("Актеры не найдены");
            }
        }

        void GetActorsByFilm()
        {
            Console.WriteLine("Введите название фильма: ");
            string filmName = Console.ReadLine();

            List<Actor> actors = _guest.GetActorsByFilm(filmName);
            if (actors != null)
            {
                int counter = 0;
                foreach (Actor actor in actors)
                {
                    Console.WriteLine(Convert.ToString(actor.ActorId) + " " +
                        Convert.ToString(actor.FilmId) + " " +
                        Convert.ToString(actor.ActorName) + " " +
                        Convert.ToString(actor.Age) + " " +
                        Convert.ToString(actor.Sex) + " " +
                        Convert.ToString(actor.Nationality) + " " +
                        Convert.ToString(actor.Fee) + " " +
                        Convert.ToString(actor.Awards));

                    counter++;
                    if (counter > SHOW_NUMBER)
                        break;
                }               
            }
            else
            {
                Console.WriteLine("Актеры не найдены");
            }
        }

        void GetActorByName()
        {
            Console.WriteLine("Введите имя и фамилию актера: ");
            string actorName = Console.ReadLine();

            Actor actor = _guest.GetActorByName(actorName);
            if (actor != null)
            {
                Console.WriteLine(Convert.ToString(actor.ActorId) + " " +
                           Convert.ToString(actor.FilmId) + " " +
                           Convert.ToString(actor.ActorName) + " " +
                           Convert.ToString(actor.Age) + " " +
                           Convert.ToString(actor.Sex) + " " +
                           Convert.ToString(actor.Nationality) + " " +
                           Convert.ToString(actor.Fee) + " " +
                           Convert.ToString(actor.Awards));
            }
            else
            {
                Console.WriteLine("Актер не найден");
            }
        }

        void GetFilmByName()
        {
            Console.WriteLine("Введите название фильма: ");
            string filmName = Console.ReadLine();

            Film film = _guest.GetFilmByName(filmName);
            if (film != null)
            {
                Console.WriteLine(Convert.ToString(film.FilmId) + " " +
                            Convert.ToString(film.StudioId) + " " +
                            Convert.ToString(film.GenreId) + " " +
                            Convert.ToString(film.DirectorId) + " " +
                            Convert.ToString(film.FilmName) + " " +
                            Convert.ToString(film.ReleaseDate) + " " +
                            Convert.ToString(film.Budget) + " " +
                            Convert.ToString(film.Fees) + " " +
                            Convert.ToString(film.AvgPrice));
            }
            else
            {
                Console.WriteLine("Фильм не найден");
            }
        }

        void CheckUser()
        {
            int choice = 100;

            while (choice > 0)
            {
                Console.WriteLine("TechUI checking\n" +
                    "1 - Добавить любимого актера\n" +
                    "2 - Добавить любимый жанр\n" +   
                    "3 - Удалить любимого актера\n" +
                    "4 - Удалить любимый жанр\n" +
                    "0 - Выход в предыдущее меню\n" +
                    "Ваш выбор: ");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddFavouriteActor();
                        break;
                    case 2:
                        AddFavouriteGenre();
                        break;
                    case 3:
                        DeleteFavouriteActor();
                        break;
                    case 4:
                        DeleteFavouriteGenre();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Неверно введен номер");
                        break;
                }
            }
        }

        void AddFavouriteActor()
        {
            Console.WriteLine("Введите имя и фамилию актера: ");
            string actorName = Console.ReadLine();

            Console.WriteLine("Введите ваш UserID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Actor actor = _guest.GetActorByName(actorName);
            if (actor != null)
            {
                _user.AddFavouriteActor(actor.ActorName, userId);
                Console.WriteLine("Актер добавлен в любимые");
            }
            else
            {
                Console.WriteLine("Актер не найден");
            }
        }

        void AddFavouriteGenre()
        {
            Console.WriteLine("Введите название жанра: ");
            string genreName = Console.ReadLine();

            Console.WriteLine("Введите ваш UserID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Genre genre = _user.GetGenreByName(genreName);
            if (genre != null)
            {
                _user.AddFavouriteGenre(genre.GenreName, userId);
                Console.WriteLine("Жанр добавлен в любимые");
            }
            else
            {
                Console.WriteLine("Жанр не найден");
            }
        }

        void DeleteFavouriteActor()
        {
            Console.WriteLine("Введите имя и фамилию актера: ");
            string actorName = Console.ReadLine();

            Console.WriteLine("Введите ваш UserID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Actor actor = _guest.GetActorByName(actorName);
            if (actor != null)
            {
                _user.DeleteFavouriteActor(actor.ActorName, userId);
                Console.WriteLine("Актер удален из любимых");
            }
            else
            {
                Console.WriteLine("Актер не найден");
            }
        }

        void DeleteFavouriteGenre()
        {
            Console.WriteLine("Введите название жанра: ");
            string genreName = Console.ReadLine();

            Console.WriteLine("Введите ваш UserID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Genre genre = _user.GetGenreByName(genreName);
            if (genre != null)
            {
                _user.DeleteFavouriteGenre(genre.GenreName, userId);
                Console.WriteLine("Жанр удален из любимых");
            }
            else
            {
                Console.WriteLine("Жанр не найден");
            }
        }

        void CheckAdmin()
        {
            int choice = 100;

            while (choice > 0)
            {
                Console.WriteLine("TechUI checking\n" +
                    "1 - Добавить фильм\n" +
                    "2 - Обновить информацию о фильме\n" +
                    "3 - Удалить фильм по id\n" +
                    "4 - Удалить фильм по названию\n" +
                    "0 - Выход в предыдущее меню\n" +
                    "Ваш выбор: ");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddFilm();
                        break;
                    case 2:
                        UpdateFilm();
                        break;
                    case 3:
                        DeleteFilmById();
                        break;
                    case 4:
                        DeleteFilmByName();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Неверно введен номер");
                        break;
                }
            }
        }

        void AddFilm()
        {
            Console.WriteLine("Введите название фильма: ");
            string filmName = Console.ReadLine();
            Film film = new Film { FilmName = filmName };
            _admin.AddFilm(film);

            Console.WriteLine("Фильм добавлен");
        }

        void UpdateFilm()
        {
            Console.WriteLine("Введите название фильма: ");
            string filmName = Console.ReadLine();

            Console.WriteLine("Введите новый бюджет для изменения: ");
            int newBudget = Convert.ToInt32(Console.ReadLine());

            Film film = _admin.GetFilmByName(filmName);
            if (film != null)
            {
                film.Budget = newBudget;
                _admin.UpdateFilm(film);
                Console.WriteLine("Информация о фильме обновлена");
            }
            else
            {
                Console.WriteLine("Нет такого фильма");
            }
        }

        void DeleteFilmById()
        {
            Console.WriteLine("Введите id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Film film = _admin.GetFilmById(id);
            if (film != null)
            {
                _admin.DeleteFilmById(id);
                Console.WriteLine("Фильм удален");
            }
            else
            {
                Console.WriteLine("Нет такого фильма");
            }
        }

        void DeleteFilmByName()
        {
            Console.WriteLine("Введите название фильма: ");
            string filmName = Console.ReadLine();

            Film film = _admin.GetFilmByName(filmName);
            if (film != null)
            {
                _admin.DeleteFilmByName(filmName);
                Console.WriteLine("Информация о фильме обновлена");
            }
            else
            {
                Console.WriteLine("Нет такого фильма");
            }
        }
    }
}
