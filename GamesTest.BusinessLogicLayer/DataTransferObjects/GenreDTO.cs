using System.Collections.Generic;

namespace GamesTest.BusinessLogicLayer.DataTransferObjects
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public List<GameGenreDTO> GameGenres { get; set; }
    }
}
