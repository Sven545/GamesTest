using GamesTest.DataAcsessLayer.Entities;
using System.Collections.Generic;

namespace GamesTest.DataAcsessLayer.Interfaces
{
    public interface IDeveloperRepository
    {
        public void Add(Developer newDeveloper);
        public IEnumerable<Developer> GetAll();
        public Developer GetOne(int developerId);
        public void Remove(Developer developer);
    }
}
