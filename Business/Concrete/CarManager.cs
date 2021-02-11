using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            // ORNEGIN EKLENEN ARABANIN GUNLUK FIYATI > 0 OLMALI
            try
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                    return new SuccessResult(Messages.CarAdded);
                }
                return new ErrorResult(Messages.CarCannotAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.CarCannotAdded + Environment.NewLine + ex.Message);
            }
        }
        public IResult Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);

            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.CarCannotDeleted + Environment.NewLine + ex.Message);
            }
        }
        public IResult Update(Car car)
        {
            try
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Update(car);
                    return new SuccessResult(Messages.CarUpdated);

                }
                    return new ErrorResult(Messages.CarCannotUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.CarCannotUpdated + Environment.NewLine + ex.Message);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Car>>(ex.Message);
            }
            // herhangi bir limitleme veya kosul olmadigindan direkt cardal daki methodu dondurduk.
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Car>>(ex.Message);
            }
            // CarDal dakı getall methoduna linq u gonder
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Car>>(ex.Message);
            }
            // CarDal dakı getall methoduna linq u gonder
        }

        public IDataResult<List<Car>> GetAllByDailyPrice(decimal minPrice, decimal maxPrice)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= minPrice && c.DailyPrice <= maxPrice));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Car>>(ex.Message);
            }
            // CarDal dakı getall methoduna linq u gonder
        }

        public IDataResult<List<Car>> GetAllByModelYear(int year)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == year));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Car>>(ex.Message);
            }
            // CarDal dakı getall methoduna linq u gonder
        }

        public IDataResult<List<CarDetailDto>> GetAllWithDetails()
        {
            try
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllWithDetails());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CarDetailDto>>(ex.Message);
            }
        }

        public IDataResult<Car> GetById(int carId)
        {
            try
            {
                return new SuccessDataResult<Car>(_carDal.Get(c => c.ID == carId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Car>(ex.Message);
            }
        }

        public IDataResult<Car> GetLastAddedCar()
        {
            try
            {
                return new SuccessDataResult<Car>(_carDal.GetGetLastAddedCar());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Car>(ex.Message);
            }
        }        
    }
}
