using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccessComponent;
using BusinessLogicComponent;

namespace Authorization
{
    public partial class UserForm : Form
    {
        private readonly UserController _userController;
        private readonly User _curUser;
        public UserForm(UserController userController, User curUser)
        {
            _userController = userController;
            _curUser = curUser;

            InitializeComponent();
            FillGenreList();
        }

        private void FillGenreList()
        {
            List<Genre> genres = _userController.GetAllGenres();
            if (genres != null)
            {
                foreach (Genre genre in genres)
                {
                    genresListBox.Items.Add(genre.GenreName);
                }
            }
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

        private void AddColumnsRecommends()
        {
            viewTable.Rows.Clear();
            viewTable.Columns.Clear();
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

        private void showFilmsBtn_Click(object sender, EventArgs e)
        {
            AddColumnsFilm();
            List<Film> films = _userController.GetAllFilms();
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

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void showActorsBtn_Click(object sender, EventArgs e)
        {
            AddColumnsActors();
            List<Actor> actors = _userController.GetAllActors();
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
            List<Genre> genres = _userController.GetAllGenres();
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

        private void addGenreBtn_Click(object sender, EventArgs e)
        {
            foreach (object itemChecked in genresListBox.CheckedItems)
            {
                string name = itemChecked.ToString();
                Genre checkedGenre = _userController.GetGenreByName(name);
                _userController.AddFavouriteGenre(checkedGenre.GenreName, _curUser.UserId);

            }
            MessageBox.Show("Выбранные жанры успешно добавлены");
        }

        private void deleteGenreBtn_Click(object sender, EventArgs e)
        {
            foreach (object itemChecked in genresListBox.CheckedItems)
            {
                string name = itemChecked.ToString();
                Genre checkedGenre = _userController.GetGenreByName(name);
                _userController.DeleteFavouriteGenre(checkedGenre.GenreName, _curUser.UserId);

            }
            MessageBox.Show("Выбранные жанры успешно добавлены");
        }

        private void showFavouriteGenreBtn_Click(object sender, EventArgs e)
        {
            AddColumnsGenres();
            List<Genre> genres = _userController.GetFavouriteGenres(_curUser);
            if (genres != null)
            {
                foreach (Genre genre in genres)
                {
                    viewTable.Rows.Add(genre.GenreId, genre.GenreName);
                }
            }
            else
            {
                MessageBox.Show("Любимые жанры не найдены");
            }
        }

        private void addActorBtn_Click(object sender, EventArgs e)
        {
            string name = actorNameTxtBox.Text.ToString();

            if (name == "")
            {
                MessageBox.Show("Не введены имя и фамилия актера");
                return;
            }

            Actor actor = _userController.GetActorByName(name);
            if (actor == null)
            {
                MessageBox.Show("Такого актера нет в базе");
                return;
            }

            _userController.AddFavouriteActor(name, _curUser.UserId);
            MessageBox.Show("Выбранный актер успешно добавлен");
        }

        private void deleteActorBtn_Click(object sender, EventArgs e)
        {
            string name = actorNameTxtBox.Text.ToString();

            if (name == "")
            {
                MessageBox.Show("Не введены имя и фамилия актера");
                return;
            }

            Actor actor = _userController.GetActorByName(name);
            if (actor == null)
            {
                MessageBox.Show("Такого актера нет в базе");
                return;
            }

            _userController.DeleteFavouriteActor(name, _curUser.UserId);
            MessageBox.Show("Выбранный актер успешно удален");
        }

        private void showFavouriteActorBtn_Click(object sender, EventArgs e)
        {
            AddColumnsActors();
            List<Actor> actors = _userController.GetFavouriteActors(_curUser);
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
                MessageBox.Show("Люыбимые актеры не найдены");
            }
        }

        private void recommendBtn_Click(object sender, EventArgs e)
        {
            AddColumnsRecommends();
            List<Recommends> films = _userController.GetRecommendFilms(_curUser.UserId);
            if (films != null)
            {
                foreach (Recommends film in films)
                {                    
                    viewTable.Rows.Add(film.film_name, film.release_date, film.budget, film.fees, film.avg_price);
                }
            }
            else
            {
                MessageBox.Show("На данный момент рекомендации для вас нет");
            }
        }
    }
}
