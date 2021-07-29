using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;     //constructor injection bağımlılığı azaltmak için hamle  //bağımlılık DataAccess Abstract ile 

        public BrandManager(IBrandDal brandDal)       //interfaceler üzerinden refans üzerinden bağımlılık var 
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>( _brandDal.Get(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
