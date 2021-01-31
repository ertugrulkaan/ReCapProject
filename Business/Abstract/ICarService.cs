using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        // isimizi yapacak siniflarin parent i
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetById(int carId);
        List<Car> GetAllByBrandId(int brandId);

    }
}
