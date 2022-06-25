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
            var test= dbContext.Genres.Include(p => p.GameGenres).ThenInclude(p => p.Game).ToList();
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
        /*
        public void Update(T newEntity)
        {
            dbContext.Genres.Remove(newEntity as Genre);
            dbContext.Genres.Add(newEntity as Genre);
            dbContext.SaveChanges();
        }
        */
    }
}
