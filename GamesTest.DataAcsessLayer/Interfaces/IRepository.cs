﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.DataAcsessLayer.Interfaces
{
    public interface IRepository<T>
    {
        public void Add(T newEntity);
        public void Update(T newEntity);
        public IEnumerable<T> GetAll();
        public T GetOne(int id);
        public void Remove(int id);

    }
}
