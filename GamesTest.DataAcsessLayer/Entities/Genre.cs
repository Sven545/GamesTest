using System.Collections.Generic;

namespace GamesTest.DataAcsessLayer.Entities
{

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameGenre> GameGenres { get; set; }
    }
}
