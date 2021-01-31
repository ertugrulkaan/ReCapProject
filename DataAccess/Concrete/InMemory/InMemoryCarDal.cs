using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //Global degiskenler
        List<Car> _cars;
        public InMemoryCarDal()
        {
            // InMemoryCarDal calistirildiginda bir araba listesi olusturulacak.
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=50000,Description="Mercedes E200",ModelYear=2005},
                new Car{CarId=2,BrandId=2,ColorId=1,DailyPrice=60000,Description="BMW 320i",ModelYear=2008},
                new Car{CarId=3,BrandId=3,ColorId=2,DailyPrice=40000,Description="Audi A3",ModelYear=2005},
                new Car{CarId=4,BrandId=4,ColorId=3,DailyPrice=70000,Description="Volvo XC60",ModelYear=2009},
                new Car{CarId=5,BrandId=5,ColorId=2,DailyPrice=80000,Description="Honda Civic TypeR",ModelYear=2011}
            };
        }
        public void Add(Car car)
        {
            // parametre olarak g onderilen nesne listeye eklenir.
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            // firstordefault ayda singleordefault kullanilabilir.
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            // parametre olarak gelen car nesnesini _cars da bulduk.
            if (carToDelete!=null)
            {
                _cars.Remove(carToDelete);
            }
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public Car GetById(int carId)
        {
            // carid ye gore aradigimizdan tek araba doneceginden liste dondurmeye gerek yok.
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
