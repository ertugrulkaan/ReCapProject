using Business.Abstract;
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
        public void Add(Brand brand)
        {
            try
            {
                if (brand.BrandName.Length > 2)
                {
                    _brandDal.Add(brand);
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

        public void Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
                Console.WriteLine("Nesne Silindi");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(b => b.ID == brandId);
        }

        public List<Brand> GetByName(string brandName)
        {
            return _brandDal.GetAll(b => b.BrandName.ToLower().Contains(brandName));
        }

        public void Update(Brand brand)
        {
            try
            {
                if (brand.BrandName.Length > 2)
                {
                    _brandDal.Update(brand);
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
