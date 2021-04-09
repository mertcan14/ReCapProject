using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class HomePageCarManager : IHomePageCarService
    {
        IHomePageCarDal _homePageCarDal;

        public HomePageCarManager(IHomePageCarDal homePageCarDal)
        {
            _homePageCarDal = homePageCarDal;
        }

        public IDataResult<List<CarDetailWithImage>> GetAllCarDetailDto()
        {
            var result = _homePageCarDal.GetCarsDetail();
            foreach (var item in result)
            {
                if (item.ImagePath.Count == 0)
                {
                    item.ImagePath.Add("/images/defaultCar.png");
                }
            }
            return new SuccessDataResults<List<CarDetailWithImage>>(result, Messages.ListedSuccess);
        }

        public IResult Add(HomePageCar entity)
        {
            entity.AddedDate = DateTime.Now;
            _homePageCarDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(int id)
        {
            var result = _homePageCarDal.Get(h => h.CarId == id);
            _homePageCarDal.Delete(result);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<HomePageCar>> GetAll()
        {
            return new SuccessDataResults<List<HomePageCar>>(_homePageCarDal.GetAll(), Messages.ListedSuccess) ;
        }

        public IDataResult<List<HomePageCarManagerDto>> GetAllManager()
        {
            return new SuccessDataResults<List<HomePageCarManagerDto>>(_homePageCarDal.GetHomeCarsManager(), Messages.ListedSuccess);
        }

        public IDataResult<HomePageCar> GetById(int id)
        {
            return new SuccessDataResults<HomePageCar>(_homePageCarDal.Get(h => h.Id == id), Messages.ListedSuccess);
        }

        public IResult Update(HomePageCar entity)
        {
            _homePageCarDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
