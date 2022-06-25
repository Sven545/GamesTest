using GamesTest.DataAcsessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.DataAcsessLayer.Interfaces
{
    public interface IGameRepository
    {
        public void Add(Game newGame);
        // public void Update(T newEntity);
        public IEnumerable<Game> GetAll();
        public IEnumerable<Game> GetAllGamesOfGenre(int genreId);
        public Game GetOne(int gameId);
        public void Remove(Game game);
    }
}
