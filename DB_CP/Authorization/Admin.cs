using DataAccessComponent;
using BusinessLogicComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Authorization
{
    public partial class Admin : Form
    {
        private readonly AdminController _admin;
        public Admin(AdminController admin)
        {
            _admin = admin;

            InitializeComponent();
        }

        
        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addFilmBtn_Click(object sender, EventArgs e)
        {            
            if (filmFilmIdBox.Text == "" || filmFilmNameBox.Text == "")
            {
                MessageBox.Show("Поля Film ID и Название должны быть заполнены");
                return;
            }

            Film film = new Film
            {
                FilmId = Convert.ToInt32(filmFilmIdBox.Text),
                FilmName = filmFilmNameBox.Text,
            };

            if (filmStudioIdBox.Text != "")
                film.StudioId = Convert.ToInt32(filmStudioIdBox.Text);
            
            if (filmGenreIdBox.Text != "")
                film.GenreId = Convert.ToInt32(filmGenreIdBox.Text);
            
            if (filmDirectorIdBox.Text != "")
                film.DirectorId = Convert.ToInt32(filmDirectorIdBox.Text);
           
            if (filmBudgetBox.Text != "")
            {
                int budget = Convert.ToInt32(filmBudgetBox.Text);
                if (budget > 20000 && budget < 250000000)
                {
                    film.Budget = budget;
                }
                else
                {
                    MessageBox.Show("Бюджет должен быть в диапазоне от 20000 до 250000000");
                    return;
                }
            }                
            
            if (filmFeesBox.Text != "")
            {
                int fees = Convert.ToInt32(filmFeesBox.Text);
                if (fees > 20000 && fees < 1000000000)
                {
                    film.Fees = fees;
                }
                else
                {
                    MessageBox.Show("Сборы должен быть в диапазоне от 20000 до 1000000000");
                    return;
                }
            }                
            
            if (filmAvgPriceBox.Text != "")
            {
                int avgPrice = Convert.ToInt32(filmAvgPriceBox.Text);
                if (avgPrice > 120 && avgPrice < 500)
                {
                    film.AvgPrice = avgPrice;
                }
                else
                {
                    MessageBox.Show("Ср. цена должна быть в диапазоне от 120 до 500");
                    return;
                }
            }
            _admin.AddFilm(film);
            MessageBox.Show("Успешно выполнено");
        }

        private void deleteFilmBtn_Click(object sender, EventArgs e)
        {
            if (filmFilmIdBox.Text == "" || filmFilmNameBox.Text == "")
            {
                MessageBox.Show("Поля Film ID и Название должны быть заполнены");
                return;
            }

            _admin.DeleteFilmById(Convert.ToInt32(filmFilmIdBox.Text));
            MessageBox.Show("Успешно выполнено");
        }

        private void addActorBtn_Click(object sender, EventArgs e)
        {
            if (actorActorIdBox.Text == "" || actorNameBox.Text == "")
            {
                MessageBox.Show("Поля Actor ID и Имя и фам.должны быть заполнены");
                return;
            }

            Actor actor = new Actor
            {
                ActorId = Convert.ToInt32(actorActorIdBox.Text),
                ActorName = actorNameBox.Text,
            };

            if (actorFilmIdBox.Text != "")
                actor.FilmId = Convert.ToInt32(actorFilmIdBox.Text);

            if (actorAgeBox.Text != "")
            {
                int age = Convert.ToInt32(actorAgeBox.Text);
                if (age > 17 && age < 71)
                {
                    actor.Age = age;
                }
                else
                {
                    MessageBox.Show("Возраст должен быть в диапазоне от 17 до 71");
                    return;
                }
            }

            if (actorSexBox.Text != "")
                actor.Sex = actorSexBox.Text;

            if (actorNationalityBox.Text != "")
                actor.Nationality = actorNationalityBox.Text;

            if (actorFeeBox.Text != "")
            {
                int fee = Convert.ToInt32(actorFeeBox.Text);
                if (fee > 1000 && fee < 1000000)
                {
                    actor.Fee = fee;
                }
                else
                {
                    MessageBox.Show("Гонорар должен быть в диапазоне от 1000 до 1000000");
                    return;
                }
            }

            if (actorAwardBox.Text != "")
            {
                int awards = Convert.ToInt32(actorAwardBox.Text);
                if (awards >= 0 && awards < 6)
                {
                    actor.Awards = awards;
                }
                else
                {
                    MessageBox.Show("Количество наград должно быть в диапазоне от 0 до 6");
                    return;
                }
            }

            _admin.AddActor(actor);
            MessageBox.Show("Успешно выполнено");
        }

        private void deleteActorBtn_Click(object sender, EventArgs e)
        {
            if (actorActorIdBox.Text == "" || actorNameBox.Text == "")
            {
                MessageBox.Show("Поля Actor ID и Имя и фам.должны быть заполнены");
                return;
            }
            
            _admin.DeleteActorById(Convert.ToInt32(actorActorIdBox.Text));
            MessageBox.Show("Успешно выполнено");
        }

        private void addDirectorBtn_Click(object sender, EventArgs e)
        {
            if (directorDirectorIdBox.Text == "" || directorDirectorNameBox.Text == "")
            {
                MessageBox.Show("Поля Director ID и Имя и фам. должны быть заполнены");
                return;
            }

            Director director = new Director
            {
                DirectorId = Convert.ToInt32(directorDirectorIdBox.Text),
                DirectorName = directorDirectorNameBox.Text,
            };
                      
            if (directorAgeBox.Text != "")
            {
                int age = Convert.ToInt32(directorAgeBox.Text);
                if (age > 23 && age < 71)
                {
                    director.Age = age;
                }
                else
                {
                    MessageBox.Show("Возраст должен быть в диапазоне от 23 до 71");
                    return;
                }
            }

            if (directorSexBox.Text != "")
                director.Sex = directorSexBox.Text;

           
            if (directorFilmsAmountBox.Text != "")
            {
                int amount = Convert.ToInt32(directorFilmsAmountBox.Text);
                if (amount > 0 && amount < 10)
                {
                    director.FilmsAmount = amount;
                }
                else
                {
                    MessageBox.Show("Количество наград должно быть в диапазоне от 1 до 10");
                    return;
                }
            }

            _admin.AddDirector(director);
            MessageBox.Show("Успешно выполнено");
        }

        private void deleteDirectorBtn_Click(object sender, EventArgs e)
        {
            if (directorDirectorIdBox.Text == "" || directorDirectorNameBox.Text == "")
            {
                MessageBox.Show("Поля Director ID и Имя и фам. должны быть заполнены");
                return;
            }

            _admin.DeleteDirectorById(Convert.ToInt32(directorDirectorIdBox.Text));
            MessageBox.Show("Успешно выполнено");
        }

        private void addGenreBtn_Click(object sender, EventArgs e)
        {
            if (genreGenreIdBox.Text == "" || genreGenreNameBox.Text == "")
            {
                MessageBox.Show("Поля Genre ID и Название должны быть заполнены");
                return;
            }

            Genre genre = new Genre
            {
                GenreId = Convert.ToInt32(genreGenreIdBox.Text),
                GenreName = genreGenreNameBox.Text,
            };

            _admin.AddGenre(genre);
            MessageBox.Show("Успешно выполнено");
        }

        private void deleteGenreBtn_Click(object sender, EventArgs e)
        {
            if (genreGenreIdBox.Text == "" || genreGenreNameBox.Text == "")
            {
                MessageBox.Show("Поля Genre ID и Название должны быть заполнены");
                return;
            }

            _admin.DeleteGenreById(Convert.ToInt32(genreGenreIdBox.Text));
            MessageBox.Show("Успешно выполнено");
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            if (userUserIdBox.Text == "" || userLoginBox.Text == "" 
                || userPasswordBox.Text == "" || userPermissions.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            User user = new User
            {
                UserId = Convert.ToInt32(userUserIdBox.Text),
                Login = userLoginBox.Text,
                Password = userPasswordBox.Text,
                Permissions = Convert.ToInt32(userPermissions.Text)
            };

            _admin.AddUser(user);
            MessageBox.Show("Успешно выполнено");
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            if (userUserIdBox.Text == "" || userLoginBox.Text == ""
                || userPasswordBox.Text == "" || userPermissions.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            _admin.DeleteUserById(Convert.ToInt32(userUserIdBox.Text));
            MessageBox.Show("Успешно выполнено");
        }

        private void addStudioBtn_Click(object sender, EventArgs e)
        {
            if (studioStudioId.Text == "" || studioStudioNameBox.Text == "")
            {
                MessageBox.Show("Поля Studio ID и Название должны быть заполнены");
                return;
            }
                        
            Studio studio = new Studio
            {
                StudioId = Convert.ToInt32(studioStudioId.Text),
                StudioName = studioStudioNameBox.Text,
            };

            _admin.AddStudio(studio);
            MessageBox.Show("Успешно выполнено");
        }

        private void deleteStudioBtn_Click(object sender, EventArgs e)
        {
            if (studioStudioId.Text == "" || studioStudioNameBox.Text == "")
            {
                MessageBox.Show("Поля Studio ID и Название должны быть заполнены");
                return;
            }

            _admin.DeleteStudioById(Convert.ToInt32(studioStudioId.Text));
            MessageBox.Show("Успешно выполнено");
        }

        private void AddColumnsFilm()
        {
            viewTable.Rows.Clear();
            viewTable.Columns.Clear();
            viewTable.Columns.Add("FilmID", "ID фильма");
            viewTable.Columns.Add("StudioID", "ID студии");
            viewTable.Columns.Add("GenreID", "ID жанра");
            viewTable.Columns.Add("FilmName", "Название");
            viewTable.Columns.Add("ReleaseDate", "Дата выпуска");
            viewTable.Columns.Add("Budget", "Бюджет");
            viewTable.Columns.Add("Fees", "Доход");
            viewTable.Columns.Add("AvgPrice", "Средняя цена");
        }

        private void AddColumnsActors()
        {
            viewTable.Rows.Clear();
            viewTable.Columns.Clear();
            viewTable.Columns.Add("ActorID", "ID актера");
            viewTable.Columns.Add("FilmID", "ID фильма");
            viewTable.Columns.Add("ActorName", "Имя и фамилия");
            viewTable.Columns.Add("Age", "Возраст");
            viewTable.Columns.Add("Sex", "Пол");
            viewTable.Columns.Add("Nationality", "Национальность");
            viewTable.Columns.Add("Fee", "Гонорар");
            viewTable.Columns.Add("Awards", "Наград");
        }

        private void AddColumnsGenres()
        {
            viewTable.Rows.Clear();
            viewTable.Columns.Clear();
            viewTable.Columns.Add("GenreId", "ID жанра");
            viewTable.Columns.Add("GenreName", "Название");
        }

        private void AddColumnsDirectors()
        {
            viewTable.Rows.Clear();
            viewTable.Columns.Clear();
            viewTable.Columns.Add("DirectorId", "ID режиссера");
            viewTable.Columns.Add("DirectorName", "Имя и фамилия");
            viewTable.Columns.Add("Age", "Возраст");
            viewTable.Columns.Add("Sex", "Пол");
            viewTable.Columns.Add("FilmsAmount", "Кол-во фильмов");
        }

        private void AddColumnsStudios()
        {
            viewTable.Rows.Clear();
            viewTable.Columns.Clear();
            viewTable.Columns.Add("StudioId", "ID студии");
            viewTable.Columns.Add("StudioName", "Название");
        }

        private void AddColumnsUsers()
        {
            viewTable.Rows.Clear();
            viewTable.Columns.Clear();
            viewTable.Columns.Add("UserId", "ID пользователя");
            viewTable.Columns.Add("Login", "Логин");
            //viewTable.Columns.Add("Password", "Пароль");
            viewTable.Columns.Add("Permissons", "Права");
        }

        private void showFilmsBtn_Click(object sender, EventArgs e)
        {
            AddColumnsFilm();
            List<Film> films = _admin.GetAllFilms();
            if (films != null)
            {
                foreach (Film film in films)
                {
                    viewTable.Rows.Add(film.FilmId, film.StudioId, film.GenreId, film.DirectorId,
                        film.FilmName, film.ReleaseDate, film.Budget, film.Fees, film.AvgPrice);
                }
            }
            else
            {
                MessageBox.Show("Фильмы не найдены");
            }
        }

        private void showActorsBtn_Click(object sender, EventArgs e)
        {
            AddColumnsActors();
            List<Actor> actors = _admin.GetAllActors();
            if (actors != null)
            {
                foreach (Actor actor in actors)
                {
                    viewTable.Rows.Add(actor.ActorId, actor.FilmId, actor.ActorName, actor.Age,
                        actor.Sex, actor.Nationality, actor.Fee, actor.Awards);
                }
            }
            else
            {
                MessageBox.Show("Актеры не найдены");
            }
        }

        private void showGenresBtn_Click(object sender, EventArgs e)
        {
            AddColumnsGenres();
            List<Genre> genres = _admin.GetAllGenres();
            if (genres != null)
            {
                foreach (Genre genre in genres)
                {
                    viewTable.Rows.Add(genre.GenreId, genre.GenreName);
                }
            }
            else
            {
                MessageBox.Show("Жанры не найдены");
            }
        }

        private void showDirectorsBtn_Click(object sender, EventArgs e)
        {
            AddColumnsDirectors();
            List<Director> directors = _admin.GetAllDirectors();
            if (directors != null)
            {
                foreach (Director director in directors)
                {
                    viewTable.Rows.Add(director.DirectorId, director.DirectorName,
                        director.Age, director.Sex, director.FilmsAmount);
                }
            }
            else
            {
                MessageBox.Show("Режиссеры не найдены");
            }
        }

        private void showStudiosBtn_Click(object sender, EventArgs e)
        {
            AddColumnsStudios();
            List<Studio> studios = _admin.GetAllStudios();
            if (studios != null)
            {
                foreach (Studio studio in studios)
                {
                    viewTable.Rows.Add(studio.StudioId, studio.StudioName);
                }
            }
            else
            {
                MessageBox.Show("Студии не найдены");
            }
        }

        private void showUsersBtn_Click(object sender, EventArgs e)
        {
            AddColumnsUsers();
            List<User> users = _admin.GetAllUsers();
            if (users != null)
            {
                foreach (User user in users)
                {
                    viewTable.Rows.Add(user.UserId, user.Login,
                       user.Permissions);
                }
            }
            else
            {
                MessageBox.Show("Пользователи не найдены");
            }
        }
    }
}
