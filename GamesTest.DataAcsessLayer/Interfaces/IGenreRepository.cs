using GamesTest.DataAcsessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.DataAcsessLayer.Interfaces
{
    public interface IGenreRepository
    {
        public void Add(Genre newGenre);
        // public void Update(T newEntity);
        public IEnumerable<Genre> GetAll();
        public Genre GetOne(int genreId);
        public void Remove(Genre genre);
    }
}
