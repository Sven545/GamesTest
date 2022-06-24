using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.BusinessLogicLayer.DataTransferObjects
{
    public class DeveloperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameDTO> Games { get; set; }
    }
}
