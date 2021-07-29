using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic Repository Design Pattern
    //buralar bir kez yazılır amaç altyapıyı oluşturmak
    //buranın amacı IProductDal ICustomerDal operasyonlar hep aynı değişen sadece nesneler onun yerine bir interface açılıp generic yapılır. 
    public interface IEntityRepository<T> where T:class,IEntity,new()   //sadece product customer gibi entity nesnesi yapmak için yapıldı
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //Eski yapı => List<Color> GetAll(); //filtre null ise belirtmessek bütün DByi getir
        T Get(Expression<Func<T, bool>> filter);  //filtre vermek zorunlu
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        

        //List<Color> GetById(int id); boyle yapmak zorunda değiliz artık.Filtreleme var.Filtre bu (p=>p.CategoryId==2)
    }
}



