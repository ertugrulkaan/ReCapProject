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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
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

        public void Delete(Color entity)
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
        public void Update(Color entity)
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

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                return reCapProjectContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                // return filtre != null ? Filtre null degil ise : Filtre = null ise ;
                return filter != null ? reCapProjectContext.Set<Color>().Where(filter).ToList() : reCapProjectContext.Set<Color>().ToList();
            }
        }
    }
}
