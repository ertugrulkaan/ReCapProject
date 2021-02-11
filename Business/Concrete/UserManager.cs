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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            try
            {
                //TODO:guncelle
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.UserCannotAdded + Environment.NewLine + ex.Message);
            }
        }
        public IResult Delete(User user)
        {
            try
            {
                //TODO:guncelle
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.UserCannotDeleted + Environment.NewLine + ex.Message);
            }
        }
        public IResult Update(User user)
        {
            try
            {
                //TODO:guncelle
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.UserCannotUpdated + Environment.NewLine + ex.Message);
            }
        }
        public IDataResult<List<User>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll()); 
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<User>>(ex.Message);
            }
        }
        public IDataResult<User> GetById(int userID)
        {
            try
            {
                return new SuccessDataResult<User>(_userDal.Get(u=>u.ID==userID));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(ex.Message);
            }
        }
        
    }
}
