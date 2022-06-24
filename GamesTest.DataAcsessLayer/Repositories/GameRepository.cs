using GamesTest.DataAcsessLayer.Entities;
using GamesTest.DataAcsessLayer.EntityFramework;
using GamesTest.DataAcsessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.DataAcsessLayer.Repositories
{
    public class GameRepository<T> : IRepository<T> where T : class, new()
    {
        private DataBaseContext dbContext;
        public GameRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;


        }

        public void Add(T newEntity)
        {
            var newGame = newEntity as Game;
            if(DbContainsGame(newGame.Id)==false)
            {
                if (GameModelIsValid(newGame))
                {
                    dbContext.Games.Add(newGame);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                throw new ArgumentException($"Game with id:{newGame.Id} added earlier");
            }
    
        }

        public void Update(T newEntity)
        {
            var newGame = newEntity as Game;
            if (DbContainsGame(newGame.Id) == true)
            {
                if (GameModelIsValid(newGame))
                {
                    dbContext.Games.Remove(dbContext.Games.Include(p=>p.GameGenres).First(p=>p.Id==newGame.Id));
                    dbContext.Games.Add(newGame);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                throw new ArgumentException($"Game with id:{newGame.Id} not found");
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Games.Include(p => p.Developer).Include(p => p.GameGenres).ThenInclude(p => p.Genre).ToList().OrderBy(p => p.Id) as IEnumerable<T>;
        }

        public T GetOne(int id)
        {
            var gameFromDb = dbContext.Games.Include(p => p.Developer).Include(p => p.GameGenres).ThenInclude(p => p.Genre).FirstOrDefault(x => x.Id == id);
            if (gameFromDb != null)
            {
                return gameFromDb as T;
            }
            else
            {
                throw new NullReferenceException($"Game with id:{id} not found");
            }

        }

        public void Remove(int id)
        {
            if(DbContainsGame(id)==false)
            {
                throw new NullReferenceException($"Game with id:{id} not found");
            }
            else
            {
                
                dbContext.Remove(dbContext.Games.FirstOrDefault(x => x.Id == id));
                dbContext.SaveChanges();
            }
           
        }

        private bool GameModelIsValid(Game game)
        {
            if (DeveloperValidation(game.DeveloperId) == false)
            {
                throw new ArgumentException($"No developer with id:{game.DeveloperId}");
            }
            if (GenresValidation(ConvertGameGenresListToGenreIdsList(game.GameGenres)) == false)
            {
                throw new ArgumentException($"Bad genres list");
            }
            return true;
        }
        private List<int> ConvertGameGenresListToGenreIdsList(List<GameGenre> gameGenres)
        {
            var genreIds = from gameGenre in gameGenres
                           select gameGenre.GenreId;
            return genreIds.ToList();
        }
        private bool DeveloperValidation(int developerId)
        {
            var developerFromDb = dbContext.Developers.FirstOrDefault(x => x.Id == developerId);
            if (developerFromDb == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool GenresValidation(IEnumerable<int> genreIds)
        {
            var genreIdsFromRequestNotContainedInDb = genreIds.Except(from genre in dbContext.Genres
                                                                      select genre.Id).ToList();
            if (genreIdsFromRequestNotContainedInDb.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool DbContainsGame(int gameId)
        {
            var gameFromDb = dbContext.Games.FirstOrDefault(x => x.Id == gameId);
            if (gameFromDb != null)
            {
                return true;
            }
            else return false;
        }

       
    }
}
