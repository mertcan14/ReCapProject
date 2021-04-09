using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IHomePageCarDal : IEntityRepository<HomePageCar>
    {
        List<CarDetailWithImage> GetCarsDetail();
        List<HomePageCarManagerDto> GetHomeCarsManager();
    }
}
