using GamesTest.BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.BusinessLogicLayer.Interfaces
{
    public interface ICrudDeveloperService
    {
        public IEnumerable<DeveloperDTO> GetAll();
    }
}
