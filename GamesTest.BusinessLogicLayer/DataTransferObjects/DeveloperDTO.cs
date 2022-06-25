using System.Collections.Generic;

namespace GamesTest.BusinessLogicLayer.DataTransferObjects
{
    public class DeveloperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameDTO> Games { get; set; }
    }
}
