using GamesTest.BusinessLogicLayer.DataTransferObjects;
using System.Collections.Generic;

namespace GamesTest.BusinessLogicLayer.Interfaces
{
    public interface ICrudDeveloperService
    {
        public IEnumerable<DeveloperDTO> GetAll();
    }
}
