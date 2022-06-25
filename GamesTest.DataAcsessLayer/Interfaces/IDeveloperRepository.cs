using GamesTest.DataAcsessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.DataAcsessLayer.Interfaces
{
    public interface IDeveloperRepository
    {
        public void Add(Developer newDeveloper);
        // public void Update(T newEntity);
        public IEnumerable<Developer> GetAll();
        public Developer GetOne(int developerId);
        public void Remove(Developer developer);
    }
}
