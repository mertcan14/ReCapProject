using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand entity);
        IResult Delete(int id);
        IResult Update(Brand entity);
        IDataResult<Brand> GetById(int id);
    }
}
