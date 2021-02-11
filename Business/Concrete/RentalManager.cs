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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            try
            {
                //O ARABAYA AIT TUM KIRALAMALARI DONER
                var result = _rentalDal.GetAll(r => r.CarID == rental.CarID);
                foreach (var rentals in result)
                {
                    if (rentals.ReturnDate==null || rentals.RentDate>rentals.ReturnDate)
                    {
                        return new ErrorResult(Messages.CarNotReturned);
                    }
                }

                //TODO:guncelle
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarRented);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.CarCannotRented + Environment.NewLine + ex.Message);
            }
        }
        public IResult Delete(Rental rental)
        {
            try
            {
                //TODO:guncelle
                _rentalDal.Delete(rental);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
        public IResult Update(Rental rental)
        {
            try
            {
                _rentalDal.Update(rental);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Rental>>(ex.Message);

            }
        }

        public IDataResult<List<RentalDetailDto>> GetAllWithDetails()
        {
            try
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllWithDetails());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(ex.Message);
            }
        }

        public IDataResult<Rental> GetById(int rentalID)
        {
            try
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.ID==rentalID));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Rental>(ex.Message);
            }
        }

    }
}
