using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IEntityService<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        IDataResult<CarDetailDto> GetCarDetail(int id);
        IDataResult<List<CarDetailDto>> GetCarByBrand(string brandName);
        IDataResult<List<CarDetailDto>> GetCarByColor(string colorName);
    }
}
