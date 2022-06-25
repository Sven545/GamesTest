using GamesTest.DataAcsessLayer.Entities;
using System.Collections.Generic;

namespace GamesTest.DataAcsessLayer.Interfaces
{
    public interface IGameRepository
    {
        public void Add(Game newGame);
        public IEnumerable<Game> GetAll();
        public IEnumerable<Game> GetAllGamesOfGenre(int genreId);
        public Game GetOne(int gameId);
        public void Remove(Game game);
    }
}
