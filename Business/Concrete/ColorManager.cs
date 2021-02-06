using Business.Abstract;
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
        public void Add(Entities.Concrete.Color color)
        {
            try
            {
                if (color.ColorName.Length > 2)
                {
                    _colorDal.Add(color);
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

        public void Delete(Entities.Concrete.Color color)
        {
            try
            {
                _colorDal.Delete(color);
                Console.WriteLine("Nesne Silindi");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Entities.Concrete.Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Entities.Concrete.Color GetById(int colorId)
        {
            return _colorDal.Get(c=>c.ID==colorId);
        }

        public Entities.Concrete.Color GetByName(string colorName)
        {
            //TEST ET
            return _colorDal.Get(c => c.ColorName.ToLower().Contains(colorName));
        }

        public void Update(Entities.Concrete.Color color)
        {
            try
            {
                if (color.ColorName.Length > 2)
                {
                    _colorDal.Update(color);
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
    }
}
