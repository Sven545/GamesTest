using GamesTest.DataAcsessLayer.Entities;
using GamesTest.DataAcsessLayer.EntityFramework;
using GamesTest.DataAcsessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GamesTest.DataAcsessLayer.Repositories
{
    public class GameRepository : IGameRepository
    {
        private DataBaseContext dbContext;
        public GameRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Game newGame)
        {
            dbContext.Games.Add(newGame);
            dbContext.SaveChanges();
        }

        public IEnumerable<Game> GetAll()
        {
            return dbContext.Games.Include(p => p.Developer).Include(p => p.GameGenres).ThenInclude(p => p.Genre).ToList().OrderBy(p => p.Id);
        }

        public IEnumerable<Game> GetAllGamesOfGenre(int genreId)
        {
            return dbContext.Games.Where(p => p.GameGenres.Any(p => p.GenreId == genreId)).Include(p => p.Developer).Include(p => p.GameGenres).ThenInclude(p => p.Genre).ToList();
        }

        public Game GetOne(int gameId)
        {
            return dbContext.Games.Include(p => p.Developer).Include(p => p.GameGenres).ThenInclude(p => p.Genre).FirstOrDefault(x => x.Id == gameId);
        }

        public void Remove(Game game)
        {
            dbContext.Games.Remove(game);
            dbContext.SaveChanges();
        }

    }
}
