using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHomePageCarDal : EfEntityRepositoryBase<HomePageCar, Context>, IHomePageCarDal
    {
        public List<CarDetailWithImage> GetCarsDetail()
        {
            using (Context context = new Context())
            {
                var result = from hp in context.HomePageCars
                             join ca in context.Cars
                             on hp.CarId equals ca.Id
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             join cl in context.Colors
                             on ca.ColorId equals cl.Id
                             where hp.Status == true
                             orderby hp.Index
                             select new CarDetailWithImage
                             {
                                 CarId = ca.Id,
                                 CarName = ca.Description,
                                 BrandName = br.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 ImagePath = (from im in context.CarImages join car in context.Cars on im.CarId equals car.Id where car.Id == ca.Id select im.ImagePath).ToList()
                             };
                
                return result.ToList();
            }
        }
        public List<HomePageCarManagerDto> GetHomeCarsManager()
        {
            using (Context context = new Context())
            {
                var result = from hp in context.HomePageCars
                             join ca in context.Cars
                             on hp.CarId equals ca.Id
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             orderby hp.Index
                             select new HomePageCarManagerDto
                             {
                                 Id = hp.Id,
                                 Index = hp.Index,
                                 AddedDate = hp.AddedDate,
                                 Status = hp.Status,
                                 CarId = ca.Id,
                                 CarName = ca.Description,
                                 BrandName = br.BrandName,
                                 DailyPrice = ca.DailyPrice,
                             };

                return result.ToList();
            }
        }
    }

}
