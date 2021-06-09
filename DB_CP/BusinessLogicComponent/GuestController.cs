using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent;

namespace BusinessLogicComponent 
{
    public class GuestController : AbstractController
    {
        public GuestController(IGenresRepository genres, IActorsRepository actors, IFilmsRepository films) :
            base(genres, actors, films)
        {

        }
    }
}
