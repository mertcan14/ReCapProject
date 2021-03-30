using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental entity);
        IResult Delete(int id);
        IResult Update(Rental entity);
        IDataResult<Rental> GetById(int id);
        IDataResult<List<CarAvailable>> GetCarAvailab();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult CheckRental(Rental entity);
    }
}
