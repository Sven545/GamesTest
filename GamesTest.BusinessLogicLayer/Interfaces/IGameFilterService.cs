using GamesTest.BusinessLogicLayer.DataTransferObjects;
using System.Collections.Generic;

namespace GamesTest.BusinessLogicLayer.Interfaces
{
    public interface IGameFilterService
    {
        public IEnumerable<GameDTO> GetAllGamesOfGenre(int genreId);
    }
}
