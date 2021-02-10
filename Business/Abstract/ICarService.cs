using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Delete(int id);
        void Update(Car car);
        Car GetById(int id);
        Color GetColorId(int id);
        Brand GetBrandId(int id);
        void Print(Car car);
    }
}
