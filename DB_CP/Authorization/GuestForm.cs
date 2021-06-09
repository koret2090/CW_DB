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
    public partial class GuestForm : Form
    {
        private readonly GuestController _guest;

        public GuestForm(GuestController guest)
        {
            _guest = guest;

            InitializeComponent();
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

        private void showFilmsBtn_Click(object sender, EventArgs e)
        {
            AddColumnsFilm();
            List<Film> films = _guest.GetAllFilms();
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
            List<Actor> actors = _guest.GetAllActors();
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
            List<Genre> genres = _guest.GetAllGenres();
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

        private void GuestForm_Load(object sender, EventArgs e)
        {
            
        }

        private void GuestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
