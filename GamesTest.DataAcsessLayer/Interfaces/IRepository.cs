using System.Collections.Generic;

namespace GamesTest.DataAcsessLayer.Interfaces
{
    public interface IRepository<T>
    {
        public void Add(T newEntity);
        public IEnumerable<T> GetAll();
        public T GetOne(int id);
        public void Remove(T entity);

    }
}
