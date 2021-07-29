using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        //List<Brand> GetAll();
        //Brand GetById(int id);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);

        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
    }
}
