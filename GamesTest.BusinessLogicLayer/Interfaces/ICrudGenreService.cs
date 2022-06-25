using GamesTest.BusinessLogicLayer.DataTransferObjects;
using System.Collections.Generic;

namespace GamesTest.BusinessLogicLayer.Interfaces
{
    public interface ICrudGenreService
    {
        public IEnumerable<GenreDTO> GetAll();
    }
}
