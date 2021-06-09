using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessComponent
{
    public interface IFilmsRepository: CrudRepository<Film>
    {
        List<Film> GetFilmsByGenre(string genre);
    }
}
