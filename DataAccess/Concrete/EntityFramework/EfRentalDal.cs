using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Context>, IRentalDal
    {
        public List<CarAvailable> CarAvailab()
        {
            using (Context context = new Context())
            {
                var result = from ca in context.Cars
                             select new CarAvailable { Id = ca.Id };

                var result1 = from re in context.Rentals
                              where re.ReturnDate == null
                              select new CarAvailable { Id = re.CarId };

                //var sonucResult = from r in result
                //                  from r1 in result1
                //                  where r.Id - r1.Id 
                //                  select new CarAvailable { Id = r.Id  };
                var Sonuc = result.Where(p => !result1.Select(i => i.Id).Contains(p.Id));



                return Sonuc.ToList();

            }
        }
        public List<RentalDetailDto> RentalDetails()
        {
            using (Context context = new Context())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.Id
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             join cu in context.Customers
                             on re.CustomerId equals cu.UserId
                             join us in context.Users
                             on cu.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 BrandName = br.BrandName,
                                 CustomerId = us.FirstName + " " + us.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
