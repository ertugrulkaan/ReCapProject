using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        // BU Bir DAL interface'idir. CAR
        List<CarDetailDto> GetAllWithDetails();
        Car GetGetLastAddedCar();
    }
}
