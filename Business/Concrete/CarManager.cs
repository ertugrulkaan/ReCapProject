using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        // is katmani oldugundan asla baska bir nesneyi newlemiyoruz.
        // cardal daki methodlari kullanmak icin onun referansini ekledik.
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            // newlemedik buraya gonderilen nesneden aldik herseyi
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            // ORNEGIN EKLENEN ARABANIN FIYATI MINIMUM 30BIN TL OLABILIR.
            if (car.DailyPrice>=30000)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Bu devirde o paraya sahin yok.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            // herhangi bir limitleme veya kosul olmadigindan direkt cardal daki methodu dondurduk.
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAllByBrandId(brandId);
        }

        public Car GetById(int carId)
        {
            return _carDal.GetById(carId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
