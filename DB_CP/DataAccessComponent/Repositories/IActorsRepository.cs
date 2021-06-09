using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessComponent
{
    public interface IActorsRepository: CrudRepository<Actor>
    {
        List<Actor> GetActorsByGenre(string genre);
        List<Actor> GetActorsByFilm(string name); 
    }
}
