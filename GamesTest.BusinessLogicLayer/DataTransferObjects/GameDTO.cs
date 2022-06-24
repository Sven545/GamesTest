using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.BusinessLogicLayer.DataTransferObjects
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DeveloperId { get; set; }
        public DeveloperDTO Developer { get; set; }

        public List<GameGenreDTO> GameGenres { get; set; }=new List<GameGenreDTO>();
    }
}
