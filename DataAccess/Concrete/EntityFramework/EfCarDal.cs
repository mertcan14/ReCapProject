using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public CarDetailDto GetCarDetail(int id)
        {
            using (Context context = new Context())
            {
                var result = from ca in context.Cars
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             where ca.Id == id
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 CarName = ca.Description,
                                 ColorName = co.ColorName,
                                 BrandName = br.BrandName,
                                 DailyPrice = ca.DailyPrice,
                             };
                return result.First();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from ca in context.Cars
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 CarName = ca.Description,
                                 ColorName = co.ColorName,
                                 BrandName = br.BrandName,
                                 DailyPrice = ca.DailyPrice,
                             };
                return result.ToList();
            }
            
        }
    }
}
