using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic constraint
    // class : referans tip olabilir
    // IEntity yada onu implement eden bir nesne olabilir
    // newlenebilir olmali
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        // Getall ve get methodlarina fonksiyon ekliyecegiz
        //GETALL methodu hem expression olmadan hemde varken calisir liste dondurur.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        // GET Methodu tek nesne dondurur ve filtre ister.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
