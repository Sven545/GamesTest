using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.BusinessLogicLayer.DataTransferObjects
{
    public class GameGenreDTO
    {
        public int GameId { get; set; }
        public GameDTO Game { get; set; }

        public int GenreId { get; set; }
        public GenreDTO Genre { get; set; }
    }
}
