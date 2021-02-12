using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEntityService<T> where T: class, ICar, new()
    {
        List<T> GetAll();
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
    }
}
