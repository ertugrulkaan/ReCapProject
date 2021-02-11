using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Entities.Concrete.Color color)
        {
            try
            {
                if (color.ColorName.Length > 2)
                {
                    _colorDal.Add(color);
                    return new SuccessResult(Messages.ColorAdded);
                }
                return new ErrorResult(Messages.ColorCannotAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.ColorCannotAdded + Environment.NewLine + ex.Message);
            }
        }
        public IResult Delete(Entities.Concrete.Color color)
        {
            try
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);

            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.ColorCannotDeleted + Environment.NewLine + ex.Message);
            }
        }
        public IResult Update(Entities.Concrete.Color color)
        {
            try
            {
                if (color.ColorName.Length > 2)
                {
                    _colorDal.Update(color); 
                    return new SuccessResult(Messages.ColorUpdated);
                }
                return new ErrorResult(Messages.ColorCannotUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.ColorCannotUpdated + Environment.NewLine + ex.Message);
            }
        }

        public IDataResult<List<Entities.Concrete.Color>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Entities.Concrete.Color>>(_colorDal.GetAll());

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Entities.Concrete.Color>>(ex.Message);
            }
        }

        public IDataResult<Entities.Concrete.Color> GetById(int colorId)
        {
            try
            {
                return new SuccessDataResult<Entities.Concrete.Color>(_colorDal.Get(c => c.ID == colorId));

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Entities.Concrete.Color>(ex.Message);
            }
        }

        public IDataResult<Entities.Concrete.Color> GetByName(string colorName)
        {
            try
            {
                return new SuccessDataResult<Entities.Concrete.Color>(_colorDal.Get(c => c.ColorName.ToLower().Contains(colorName)));

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Entities.Concrete.Color>(ex.Message);
            }
            //TEST ET
        }        
    }
}
