using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())     //using özel yapı işi bitince bellekten hemen atılır.IDisposable Pattern
            {
                var addedEntity = context.Entry(entity); //E.F ye özel kod
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)   //tek bir satır getircek bu yuzden singleordefault
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);  //filteri bulur
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext()) // Tolist ve where linq kodu Set E.F kodu
            {
                return filter == null
                     ? context.Set<TEntity>().ToList()     //filtre yoksa DbSetteki Car a yerleş diyoruz.Cars tablosula calışcam.Select*from Cars ı çalıştır.Ve listeye çevir
                     : context.Set<TEntity>().Where(filter).ToList();  //filtre varsa filtre yi şarta koy ve listele
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
