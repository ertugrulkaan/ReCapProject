using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                // 1 gonderilen nesnenin referansini al
                // 2 yontemi belirt
                // 3 ekle.
                var addedEntity = reCapProjectContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapProjectContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                // 1 gonderilen nesnenin referansini al
                // 2 yontemi belirt
                // 3 sil.
                var deletedEntity = reCapProjectContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapProjectContext.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                // 1 gonderilen nesnenin referansini al
                // 2 yontemi belirt
                // 3 güncelle.
                var updatedEntity = reCapProjectContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapProjectContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                return reCapProjectContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                // return filtre != null ? Filtre null degil ise : Filtre = null ise ;
                return filter != null ? reCapProjectContext.Set<Car>().Where(filter).ToList() : reCapProjectContext.Set<Car>().ToList();
            }
        }

    }
}
