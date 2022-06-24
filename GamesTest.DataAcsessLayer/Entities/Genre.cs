using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.DataAcsessLayer.Entities
{

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Game> Games { get; set; }
        public List<GameGenre> GameGenres { get; set; }

        //public List<IntermediateTableGameGenre> IntermediateTableGamesGenres { get; set; }
    }
}
