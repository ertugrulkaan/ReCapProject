using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        // DTO OLARAK DONDERECEGIMIZ VERIYI DONDERMEK ICIN ICARDAL A OZEL BIR METHOD OLUSTURDUK.
        // BU METHODA CONTEXTINI VERDIK
        // DONDURECEGI NESNEYI LINQ YARDIMIYLA JOIN ETTIK

        public List<CarDetailDto> GetAllWithDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.ID
                             join cl in context.Colors on c.ColorId equals cl.ID
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();

            }

        }

        public Car GetGetLastAddedCar()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             orderby c.ID descending
                             select new Car
                             {
                                 ID = c.ID,
                                 CarName = c.CarName
                             };
                return result.FirstOrDefault();

            }
        }
    }
}
