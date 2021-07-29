using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal: IEntityRepository<Brand>
    {
        //operasyonları sildik yukarda IEntityRepository<T> burdan alıyoruz
        /* List<Brand> GetAll();
         List<Brand> GetById(int id);
         void Add(Brand brand);
         void Deleted(Brand brand);
         void Update(Brand brand);*/
    }
}
