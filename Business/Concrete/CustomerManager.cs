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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            try
            {
                //TODO:guncelle
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.CustomerCannotAdded + Environment.NewLine + ex.Message);
            }
        }
        public IResult Delete(Customer customer)
        {
            try
            {
                //TODO:guncelle
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.CustomerCannotDeleted + Environment.NewLine + ex.Message);
            }
        }
        public IResult Update(Customer customer)
        {
            try
            {
                //TODO:guncelle
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.CustomerCannotUpdated + Environment.NewLine + ex.Message);
            }
        }
        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Customer>>(ex.Message);
            }
        }
        public IDataResult<Customer> GetById(int customerID)
        {
            try
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.ID==customerID));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Customer>(ex.Message);
            }
        }

        
    }
}
