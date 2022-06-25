using GamesTest.DataAcsessLayer.Entities;
using GamesTest.DataAcsessLayer.EntityFramework;
using GamesTest.DataAcsessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GamesTest.DataAcsessLayer.Repositories
{
    public class GenreRepository:IGenreRepository
    {
        private DataBaseContext dbContext;
        public GenreRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Genre newGenre)
        {
            dbContext.Genres.Add(newGenre);
            dbContext.SaveChanges();
        }

        public IEnumerable<Genre> GetAll()
        {
            return dbContext.Genres.Include(p=>p.GameGenres).ThenInclude(p=>p.Game).ToList();
        }

        public Genre GetOne(int genreId)
        {
           return dbContext.Genres.Include(p => p.GameGenres).ThenInclude(p => p.Game).FirstOrDefault(p=>p.Id == genreId);
        }

        public void Remove(Genre genre)
        {
            dbContext.Genres.Remove(genre);
            dbContext.SaveChanges();
        }
        
    }
}
