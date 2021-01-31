using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // is sinifindan bir manager olusturduk ve ona hangi veritabaniyla calisacaksak onun nesnesini gonderdik.
            CarManager carManager = new CarManager(new InMemoryCarDal());
            // BUTUN ARABALAR
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID : " + car.CarId+ " Marka ID : " +car.BrandId + " Renk ID : "+car.ColorId +" Fiyat : " + car.DailyPrice + " Araba : " + car.Description +" Model Yili :  " + car.ModelYear);
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            Car car1 = new Car() { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 100000, Description = "Mercedes E200 AMG", ModelYear = 2004 };
            //Yeni olusturulan nesne listeye eklendi.
            carManager.Add(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID : " + car.CarId + " Marka ID : " + car.BrandId + " Renk ID : " + car.ColorId + " Fiyat : " + car.DailyPrice + " Araba : " + car.Description + " Model Yili :  " + car.ModelYear);
            }
            
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            // ID = 1 OLAN SILINDI
            carManager.Delete(new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 50000, Description = "Mercedes E200", ModelYear = 2005 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID : " + car.CarId + " Marka ID : " + car.BrandId + " Renk ID : " + car.ColorId + " Fiyat : " + car.DailyPrice + " Araba : " + car.Description + " Model Yili :  " + car.ModelYear);
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            // ID = 2 OLAN LISTEDE BULUNDU. VE EKRANA NE OLDUGU YAZDIRILDI.
            Console.WriteLine((carManager.GetById(2)).Description);
            
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            // ID = 3 OLANIN ICERIGI GUNCELLENDI. VE GUNCELLENEN FIYATI EKRANA YAZDIRILDI.

            carManager.Update(new Car { CarId = 3, BrandId = 3, ColorId = 4, DailyPrice = 95000, Description = "Audi A4", ModelYear = 2008 });
            Console.WriteLine((carManager.GetById(3)).DailyPrice);

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");


        }
    }
}
