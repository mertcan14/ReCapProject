using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car entity);
        IResult Delete(int id);
        IResult Update(Car entity);
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        IDataResult<CarDetailDto> GetCarDetail(int id);
        IDataResult<List<CarDetailDto>> GetCarByBrand(string brandName);
        IDataResult<List<CarDetailDto>> GetCarByColor(string colorName);
        IDataResult<List<CarDetailDto>> GetCarByBrandColor(string brandName,string colorName);
    }
}
