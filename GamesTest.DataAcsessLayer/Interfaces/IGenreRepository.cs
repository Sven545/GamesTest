using GamesTest.DataAcsessLayer.Entities;
using System.Collections.Generic;

namespace GamesTest.DataAcsessLayer.Interfaces
{
    public interface IGenreRepository
    {
        public void Add(Genre newGenre);
        public IEnumerable<Genre> GetAll();
        public Genre GetOne(int genreId);
        public void Remove(Genre genre);
    }
}
