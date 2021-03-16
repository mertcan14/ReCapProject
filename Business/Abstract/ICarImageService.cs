using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService : IEntityService<CarImage>
    {
        IDataResult<List<CarImage>> GetCarImage(int carId);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IResult Addd(IFormFile image, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile image, CarImage carImage);

    }
}
