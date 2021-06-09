using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessComponent;
using System.Collections.Generic;

namespace ModulesTesting
{
    [TestClass]
    public class AccsessDbTests
    {
        [TestMethod]
        public void TestUsersRepository()
        {
            IUsersRepository rep = new UsersRepository(new Context());
            //rep.DeleteAll();

            User item = new User { Login = "123", Password = "321"};
            rep.Add(item);
            User checkItem = rep.FindByName("123");
            Assert.IsNotNull(checkItem, "user is not added");
            Assert.AreEqual("123", checkItem.Login, "Incorrect adding");

            int userId = checkItem.UserId;
            item.UserId = userId;
            checkItem.Login = "1337";
            rep.Update(checkItem);
            User checkItem2 = rep.ReadById(userId);
            Assert.IsNotNull(checkItem2, "Can't find such user");
            Assert.AreEqual(checkItem2.Login, "1337", "Update login fail");

            List<User> users = rep.ReadAll();
            Assert.IsNotNull(users, "There is no any users");

            rep.DeleteById(checkItem2.UserId);
            Assert.IsNull(rep.FindByName(checkItem2.Login), "user isn't deleted");       
        }
        
        [TestMethod]
        public void TestActorsRepository()
        {
            IActorsRepository rep = new ActorsRepository(new Context());
            //rep.DeleteAll();

            Actor item = new Actor { ActorName = "Aboba Amogus"};
            rep.Add(item);
            Actor checkItem = rep.FindByName("Aboba Amogus");
            Assert.IsNotNull(checkItem, "Actor is not added");
            Assert.AreEqual("Aboba Amogus", checkItem.ActorName, "Incorrect adding");

            int actorId = checkItem.ActorId;
            item.ActorId = actorId;
            checkItem.ActorName = "Zhmishenko Valeriy";
            rep.Update(checkItem);
            Actor checkItem2 = rep.ReadById(actorId);
            Assert.IsNotNull(checkItem2, "Can't find such actor");
            Assert.AreEqual(checkItem2.ActorName, "Zhmishenko Valeriy", "Update name fail");

            List<Actor> actors = rep.ReadAll();
            Assert.IsNotNull(actors, "There is no any actors");

            rep.DeleteById(checkItem2.ActorId);
            Assert.IsNull(rep.FindByName(checkItem2.ActorName), "Actor isn't deleted");
        }

        [TestMethod]
        public void TestDirectorsRepository()
        {
            IDirectorsRepository rep = new DirectorsRepository(new Context());
            //rep.DeleteAll();

            Director item = new Director { DirectorName = "Aboba Amogus" };
            rep.Add(item);
            Director checkItem = rep.FindByName("Aboba Amogus");
            Assert.IsNotNull(checkItem, "Director is not added");
            Assert.AreEqual("Aboba Amogus", checkItem.DirectorName, "Incorrect adding");

            int directorId = checkItem.DirectorId;
            item.DirectorId = directorId;
            checkItem.DirectorName = "Zhmishenko Valeriy";
            rep.Update(checkItem);
            Director checkItem2 = rep.ReadById(directorId);
            Assert.IsNotNull(checkItem2, "Can't find such director");
            Assert.AreEqual(checkItem2.DirectorName, "Zhmishenko Valeriy", "Update name fail");

            List<Director> directors = rep.ReadAll();
            Assert.IsNotNull(directors, "There is no any directors");

            rep.DeleteById(checkItem2.DirectorId);
            Assert.IsNull(rep.FindByName(checkItem2.DirectorName), "Directors isn't deleted");
        }

        [TestMethod]
        public void TestFilmsRepository()
        {
            IFilmsRepository rep = new FilmsRepository(new Context());
            //rep.DeleteAll();

            Film item = new Film { FilmName = "The best film 2" };
            rep.Add(item);
            Film checkItem = rep.FindByName("The best film 2");
            Assert.IsNotNull(checkItem, "Film is not added");
            Assert.AreEqual("The best film 2", checkItem.FilmName, "Incorrect adding");

            int filmId = checkItem.FilmId;
            item.FilmId = filmId;
            checkItem.FilmName = "The best film 3";
            rep.Update(checkItem);
            Film checkItem2 = rep.ReadById(filmId);
            Assert.IsNotNull(checkItem2, "Can't find such film");
            Assert.AreEqual(checkItem2.FilmName, "The best film 3", "Update name fail");

            List<Film> films = rep.ReadAll();
            Assert.IsNotNull(films, "There is no any films");

            rep.DeleteById(checkItem2.FilmId);
            Assert.IsNull(rep.FindByName(checkItem2.FilmName), "Film isn't deleted");
        }

        [TestMethod]
        public void TestGenresRepository()
        {
            IGenresRepository rep = new GenresRepository(new Context());
            //rep.DeleteAll();

            Genre item = new Genre { GenreName = "Anime" };
            rep.Add(item);
            Genre checkItem = rep.FindByName("Anime");
            Assert.IsNotNull(checkItem, "Genre is not added");
            Assert.AreEqual("Anime", checkItem.GenreName, "Incorrect adding");

            int genreId = checkItem.GenreId;
            item.GenreId = genreId;
            checkItem.GenreName = "Anime";
            rep.Update(checkItem);
            Genre checkItem2 = rep.ReadById(genreId);
            Assert.IsNotNull(checkItem2, "Can't find such genre");
            Assert.AreEqual(checkItem2.GenreName, "Anime", "Update name fail");

            List<Genre> genres = rep.ReadAll();
            Assert.IsNotNull(genres, "There is no any genres");

            rep.DeleteById(checkItem2.GenreId);
            Assert.IsNull(rep.FindByName(checkItem2.GenreName), "Genre isn't deleted");
        }

        [TestMethod]
        public void TestStudiosRepository()
        {
            IStudiosRepository rep = new StudiosRepository(new Context());
            //rep.DeleteAll();

            Studio item = new Studio { StudioName = "Bandai Namco" };
            rep.Add(item);
            Studio checkItem = rep.FindByName("Bandai Namco");
            Assert.IsNotNull(checkItem, "Studio is not added");
            Assert.AreEqual("Bandai Namco", checkItem.StudioName, "Incorrect adding");

            int studioId = checkItem.StudioId;
            item.StudioId = studioId;
            checkItem.StudioName = "Bandai Namco";
            rep.Update(checkItem);
            Studio checkItem2 = rep.ReadById(studioId);
            Assert.IsNotNull(checkItem2, "Can't find such studio");
            Assert.AreEqual(checkItem2.StudioName, "Bandai Namco", "Update name fail");

            List<Studio> studios = rep.ReadAll();
            Assert.IsNotNull(studios, "There is no any studios");

            rep.DeleteById(checkItem2.StudioId);
            Assert.IsNull(rep.FindByName(checkItem2.StudioName), "Studio isn't deleted");
        }
    }
}
