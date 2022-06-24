using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.DataAcsessLayer.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        public List<GameGenre> GameGenres { get; set; }
        
    }
}
