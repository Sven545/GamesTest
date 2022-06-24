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
            var newGame=newEntity as Game;
            var gameFromDb=dbContext.Games.FirstOrDefault(x => x.Id == newGame.Id);
            if(gameFromDb!=null)
            {
                throw new ArgumentException($"Game with id:{newGame.Id} was added earlier");
               
            }
            else
            {
                var developerFromDb = dbContext.Developers.FirstOrDefault(x => x.Id == newGame.DeveloperId);
                if (developerFromDb == null)
                {
                    throw new ArgumentException($"No developer with id:{newGame.DeveloperId}");
                }
                dbContext.Games.Add(newGame);
                dbContext.SaveChanges();
            }
            
        }

        public IEnumerable<T> GetAll()
        {
           
            return dbContext.Games.Include(p=>p.Developer).Include(p => p.GameGenres).ThenInclude(p => p.Genre).ToList().OrderBy(p=>p.Id) as IEnumerable<T>;
        }

        public T GetOne(int id)
        {
            var gameFromDb = dbContext.Games.Include(p => p.Developer).Include(p => p.GameGenres).ThenInclude(p => p.Genre).FirstOrDefault(x => x.Id == id);
            if(gameFromDb!=null)
            {
                return gameFromDb as T;
            }
            else
            {
                throw new NullReferenceException($"Game with id:{id} not found") ;
            }
          
        }

        public void Remove(int id)
        {
            var gameFromDb=dbContext.Games.FirstOrDefault(x=>x.Id == id);
            if(gameFromDb!=null)
            {
                throw new NullReferenceException($"Game with id:{id} not found");
            }
            else
            {
                dbContext.Remove(id);
                dbContext.SaveChanges();
            }
            
        }
    }
}
