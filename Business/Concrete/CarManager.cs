using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
            // ORNEGIN EKLENEN ARABANIN GUNLUK FIYATI > 0 OLMALI
            try
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                    Console.WriteLine("Başarılı!");
                }
                else
                {
                    Console.WriteLine("Nesne hatalı üretilmiş alanları kontrol et!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Car> GetAll()
        {
            try
            {
                return _carDal.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return _carDal.GetAll();
            }
            // herhangi bir limitleme veya kosul olmadigindan direkt cardal daki methodu dondurduk.
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            // CarDal dakı getall methoduna linq u gonder
            return _carDal.GetAll(c=> c.BrandId==brandId);
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            // CarDal dakı getall methoduna linq u gonder
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetAllByDailyPrice(decimal minPrice, decimal maxPrice)
        {
            // CarDal dakı getall methoduna linq u gonder
            return _carDal.GetAll(c => c.DailyPrice>=minPrice && c.DailyPrice<=maxPrice);
        }

        public List<Car> GetAllByModelYear(int year)
        {
            // CarDal dakı getall methoduna linq u gonder
            return _carDal.GetAll(c => c.ModelYear==year);
        }

        public List<CarDetailDto> GetAllWithDetails()
        {
            return _carDal.GetAllWithDetails();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.ID == carId);
        }

        public Car GetLastAddedCar()
        {
            return _carDal.GetGetLastAddedCar();
        }

        public void Update(Car car)
        {
            try
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Update(car);
                    Console.WriteLine("Başarılı!");
                }
                else
                {
                    Console.WriteLine("Nesne guncelleme sartlarina uymuyor alanları kontrol et!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
