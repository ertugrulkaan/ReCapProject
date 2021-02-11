using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext: DbContext,new()
    {
        // BUTUN ISLEMLER GENERIC OLARAK YURUYECEK
        public void Add(TEntity entity)
        {
            //GC nin bu nesneyi isi bitince silmesi icin yaptik
            using (TContext context = new TContext())
            {
                // 1 gonderilen nesnenin referansini al
                // 2 yontemi belirt
                // 3 ekle.
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                // 1 gonderilen nesnenin referansini al
                // 2 yontemi belirt
                // 3 ekle.
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                // ?  dbsetteki product a yerles butun verileri bana gonder : degil ise filtreyi uygula
                // parametre olarak bir lambda olacak filtre ne olursa o olacak
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                // 1 gonderilen nesnenin referansini al
                // 2 yontemi belirt
                // 3 ekle.
                var updateddEntity = context.Entry(entity);
                updateddEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}