using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length > 2 &&  car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba model ismi 3 karakterden küçük veya araba günlük fiyatı 0 dan büyük değil");
            }
            
        }

        public void Delete(int id)
        {
            _carDal.Delete(_carDal.Get(c => c.Id == id));
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public string Print(Car car)
        {
            return _carDal.Print(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
