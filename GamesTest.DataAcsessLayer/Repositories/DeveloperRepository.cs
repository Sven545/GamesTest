using GamesTest.DataAcsessLayer.Entities;
using GamesTest.DataAcsessLayer.EntityFramework;
using GamesTest.DataAcsessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GamesTest.DataAcsessLayer.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private DataBaseContext dbContext;
        public DeveloperRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Developer newDeveloper)
        {
            dbContext.Developers.Add(newDeveloper);
            dbContext.SaveChanges();
        }

        public IEnumerable<Developer> GetAll()
        {
            return dbContext.Developers.Include(p=>p.Games).ThenInclude(p=>p.GameGenres).ToList();
        }

        public Developer GetOne(int developerId)
        {
           return dbContext.Developers.FirstOrDefault(p=>p.Id == developerId);
        }

        public void Remove(Developer developer)
        {
            dbContext.Developers.Remove(developer);
            dbContext.SaveChanges();
        }
       
    }
}
