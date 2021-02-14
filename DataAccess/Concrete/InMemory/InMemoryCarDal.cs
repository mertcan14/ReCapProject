using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        public InMemoryCarDal()
        {
            _brands = new List<Brand>
            {
                new Brand {Id=1, BrandName="Mercedes"},
                new Brand {Id=2, BrandName="Honda"},
                new Brand {Id=3, BrandName="Peugeot"},
                new Brand {Id=4, BrandName="Jeep"},
            };

            _colors = new List<Color>
            {
                new Color {Id=1, ColorName="Siyah"},
                new Color {Id=2, ColorName="Kırmızı"},
                new Color {Id=3, ColorName="Beyaz"},
            };

            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 1, ColorId = 1,ModelYear = 2020, DailyPrice = 700, Description = "GLA Serisi 200 1.3 AMG"},
                new Car{Id = 2,BrandId = 1, ColorId = 1,ModelYear = 2020, DailyPrice = 600, Description = "A Serisi A180 1.4 Style"},
                new Car{Id = 3,BrandId = 2, ColorId = 2,ModelYear = 2012, DailyPrice = 500, Description = "Jazz 1.4 Joy"},
                new Car{Id = 4,BrandId = 2, ColorId = 1,ModelYear = 2021, DailyPrice = 400, Description = "Civic 1.5 Executive Plus CVT"},
                new Car{Id = 5,BrandId = 3, ColorId = 3,ModelYear = 2021, DailyPrice = 300, Description = "2008 1.2 GT-Line AT"},
                new Car{Id = 6,BrandId = 4, ColorId = 2,ModelYear = 2020, DailyPrice = 200, Description = "Renegade 1.6 Multijet Limited AT"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            Car carToDelete;
            carToDelete = _cars.FirstOrDefault(c => c.Id == id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public Color GetColorId(int id)
        {
            return _colors.FirstOrDefault(c => c.Id == id);
        }

        public Brand GetBrandId(int id)
        {
            return _brands.FirstOrDefault(b => b.Id == id);
        }

        public void Print(Car car)
        {
            Console.WriteLine("Marka:" + GetBrandId(car.BrandId).BrandName + " - model: " + car.Description + " - renk: " + GetColorId(car.ColorId).ColorName + " - Yılı: " + car.ModelYear + " - Fiyat: " + car.DailyPrice);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}
