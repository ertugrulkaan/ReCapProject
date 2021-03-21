using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        // isimizi yapacak siniflarin parent i
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult<List<Car>> GetAllByDailyPrice(decimal minPrice, decimal maxPrice);
        IDataResult<List<Car>> GetAllByModelYear(int year);
        IDataResult<List<CarDetailDto>> GetAllWithDetails();
        IDataResult<List<CarDetailWithImageDto>> GetAllCarDetailsByBrandId(int id);
        IDataResult<List<CarDetailWithImageDto>> GetAllCarDetailsByColorId(int id);
        IDataResult<Car> GetLastAddedCar();

    }
}
