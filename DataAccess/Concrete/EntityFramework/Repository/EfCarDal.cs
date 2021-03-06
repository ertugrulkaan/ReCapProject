﻿using Core.DataAccess.EntityFramework;
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
                                 CarId = c.ID,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };
                return result.ToList();

            }

        }

        public List<CarDetailWithImageDto> GetAllWithDetailsForNG(Expression<Func<CarDetailWithImageDto, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.ID
                             join cl in context.Colors on c.ColorId equals cl.ID
                             join im in context.CarImages on c.ID equals im.CarId
                             select new CarDetailWithImageDto
                             {
                                 CarId = c.ID,
                                 ImagePath = im.ImagePath,
                                 Description = c.Description,
                                 BrandId = b.ID,
                                 BrandName = b.BrandName,
                                 CarImageDate = im.Date,
                                 ColorId = cl.ID,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

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
