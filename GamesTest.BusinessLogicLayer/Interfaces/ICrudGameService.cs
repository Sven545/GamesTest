using System.Collections.Generic;
using GamesTest.BusinessLogicLayer.DataTransferObjects;

namespace GamesTest.BusinessLogicLayer.Interfaces
{
    public interface ICrudGameService
    {
        public void Add(GameDTO newGame);
        public void Update(GameDTO newGame);
        public IEnumerable<GameDTO> GetAll();
        public GameDTO GetOne(int id);
        public void Remove(int id);
    }
}
