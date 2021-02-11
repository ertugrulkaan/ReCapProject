using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllWithDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarID equals c.ID
                             join cl in context.Colors on c.ColorId equals cl.ID
                             join br in context.Brands on c.BrandId equals br.ID
                             join u in context.Users on r.CustomerID equals u.ID
                             select new RentalDetailDto
                             {
                                 RentalID = r.ID,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarID = r.CarID,
                                 CarName = c.CarName,
                                 CarModelYear = c.ModelYear,
                                 BrandName = br.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 CustomerID = u.ID,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CustomerEmail = u.Email
                             };
                return result.ToList();
            }
            return new List<RentalDetailDto>();
        }
    }
}
