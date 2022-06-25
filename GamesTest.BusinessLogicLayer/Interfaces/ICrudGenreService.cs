using GamesTest.BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.BusinessLogicLayer.Interfaces
{
    public interface ICrudGenreService
    {
        // public void Add(GameDTO newGame);
        // public void Update(GameDTO newGame);
        public IEnumerable<GenreDTO> GetAll();
        // public GameDTO GetOne(int id);
        // public void Remove(int id);
    }
}
