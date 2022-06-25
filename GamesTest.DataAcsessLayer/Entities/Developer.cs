using System.Collections.Generic;

namespace GamesTest.DataAcsessLayer.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}
