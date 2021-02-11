using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            try
            {
                if (brand.BrandName.Length > 2)
                {
                    _brandDal.Add(brand);
                    return new SuccessResult(Messages.BrandAdded);
                }
                    return new SuccessResult(Messages.BrandCannotAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.BrandCannotAdded + Environment.NewLine + ex.Message);
            }
        }
        public IResult Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand); 
                return new SuccessResult(Messages.BrandDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.BrandCannotDeleted + Environment.NewLine + ex.Message);
            }
        }
        public IResult Update(Brand brand)
        {
            try
            {
                if (brand.BrandName.Length > 2)
                {
                    _brandDal.Update(brand);
                    return new SuccessResult(Messages.BrandUpdated);
                }
                return new SuccessResult(Messages.BrandCannotUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.BrandCannotUpdated + Environment.NewLine + ex.Message);

            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Brand>>(ex.Message);
            }
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            try
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(b => b.ID == brandId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Brand>(ex.Message);
            }
        }

        public IDataResult<List<Brand>> GetByName(string brandName)
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandName.ToLower().Contains(brandName)));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Brand>>(ex.Message);
            }
        }

    }
}
