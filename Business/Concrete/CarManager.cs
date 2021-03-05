using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ICarService.GetAll")]
        [CacheRemoveAspect("ICarService.GetAllByBrandId")]
        [CacheRemoveAspect("ICarService.GetAllByColorId")]
        [CacheRemoveAspect("ICarService.GetAllByDailyPrice")]
        [CacheRemoveAspect("ICarService.GetAllByModelYear")]
        [CacheRemoveAspect("ICarService.GetAllWithDetails")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            try
            {
                // iş kuralları bu yapı ile yazılmalıdır.
                //IResult result = BusinessRules.Run(CheckIfCarDailyPriceCorrect());
                ////yeni bir is kurali gelir ise uste virgul ile eklemek yeterli
                //if (result != null)
                //{
                //    return result;
                //}

                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.CarCannotAdded + Environment.NewLine + ex.Message);
            }
        }
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ICarService.GetAll")]
        [CacheRemoveAspect("ICarService.GetAllByBrandId")]
        [CacheRemoveAspect("ICarService.GetAllByColorId")]
        [CacheRemoveAspect("ICarService.GetAllByDailyPrice")]
        [CacheRemoveAspect("ICarService.GetAllByModelYear")]
        [CacheRemoveAspect("ICarService.GetAllWithDetails")]
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
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ICarService.GetAll")]
        [CacheRemoveAspect("ICarService.GetAllByBrandId")]
        [CacheRemoveAspect("ICarService.GetAllByColorId")]
        [CacheRemoveAspect("ICarService.GetAllByDailyPrice")]
        [CacheRemoveAspect("ICarService.GetAllByModelYear")]
        [CacheRemoveAspect("ICarService.GetAllWithDetails")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            try
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.CarCannotUpdated + Environment.NewLine + ex.Message);
            }
        }
        [CacheAspect]
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

        [CacheAspect]
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

        [CacheAspect]
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

        [CacheAspect]
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

        [CacheAspect]
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

        [CacheAspect]
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
        private IResult CheckIfCarDailyPriceCorrect()
        {
            // örnek olması için ekledim içi boş
            var result = _carDal.GetAll(p => p.DailyPrice == 0);
            if (result !=null)
            {
                return new ErrorResult(Messages.CarDailyPriceError);
            }
            return new SuccessResult();
        }
    }
}
