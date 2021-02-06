using Business.Concrete;
using DataAccess.Concrete.EntityFramework.Repository;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 
            //// is sinifindan bir manager olusturduk ve ona hangi veritabaniyla calisacaksak onun nesnesini gonderdik.
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //// BUTUN ARABALAR
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("ID : " + car.CarId+ " Marka ID : " +car.BrandId + " Renk ID : "+car.ColorId +" Fiyat : " + car.DailyPrice + " Araba : " + car.Description +" Model Yili :  " + car.ModelYear);
            //}

            //Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            //Car car1 = new Car() { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 100000, Description = "Mercedes E200 AMG", ModelYear = 2004 };
            ////Yeni olusturulan nesne listeye eklendi.
            //carManager.Add(car1);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("ID : " + car.CarId + " Marka ID : " + car.BrandId + " Renk ID : " + car.ColorId + " Fiyat : " + car.DailyPrice + " Araba : " + car.Description + " Model Yili :  " + car.ModelYear);
            //}

            //Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            //// ID = 1 OLAN SILINDI
            //carManager.Delete(new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 50000, Description = "Mercedes E200", ModelYear = 2005 });
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("ID : " + car.CarId + " Marka ID : " + car.BrandId + " Renk ID : " + car.ColorId + " Fiyat : " + car.DailyPrice + " Araba : " + car.Description + " Model Yili :  " + car.ModelYear);
            //}

            //Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            //// ID = 2 OLAN LISTEDE BULUNDU. VE EKRANA NE OLDUGU YAZDIRILDI.
            //Console.WriteLine((carManager.GetById(2)).Description);

            //Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            //// ID = 3 OLANIN ICERIGI GUNCELLENDI. VE GUNCELLENEN FIYATI EKRANA YAZDIRILDI.

            //carManager.Update(new Car { CarId = 3, BrandId = 3, ColorId = 4, DailyPrice = 95000, Description = "Audi A4", ModelYear = 2008 });
            //Console.WriteLine((carManager.GetById(3)).DailyPrice);

            //Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            //// Brand ID si 1 olanlari listeleme
            //Car car2 = new Car() { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 100000, Description = "Mercedes C200", ModelYear = 2004 };
            ////Yeni olusturulan nesne listeye eklendi.
            //carManager.Add(car2);
            //foreach (var car in carManager.GetAllByBrandId(1))
            //{
            //    Console.WriteLine(car.Description);
            //}
            #endregion
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());



            Console.WriteLine("Araba Kiralama Programına Hoş Geldiniz");
            Console.WriteLine("Mevcut Arabalar");
            Console.WriteLine("ID\tRenk\t\tMarka\t\t\tModel Yılı\t\tGünlük Fiyat\t\tAçıklama");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.ID}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            Console.WriteLine("-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----");
            Console.WriteLine("\t\t\t\t\t\tMENÜ");
            Console.WriteLine("1-Renk Ekleme");
            Console.WriteLine("2-Renk Silme");
            Console.WriteLine("3-Renk Güncelleme");
            Console.WriteLine("Sadece sayı girin");
            string userInput = Console.ReadLine();
            switch (Convert.ToInt32(userInput))
            {
                case 1:
                    Console.WriteLine("Renk adı girin");
                    string ColorName = Console.ReadLine();
                    colorManager.Add(new Color { ColorName = ColorName });
                    break;
                case 2:
                    Console.WriteLine("Silmek istediginiz rengi nasil arayalim ? ID = 1 - Renk Adi != 1");
                    int userInputType = Convert.ToInt32(Console.ReadLine());
                    if (userInputType==1)
                    {
                        Console.WriteLine("ID yi giriniz");
                        colorManager.Delete(colorManager.GetById(Convert.ToInt32(Console.ReadLine())));
                        Console.WriteLine("Basarili");
                    }
                    else
                    {
                        Console.WriteLine("Adi giriniz");
                        colorManager.Delete(colorManager.GetByName(Console.ReadLine()));
                        Console.WriteLine("Basarili");
                    }
                    break;
                case 3:
                    Console.WriteLine("Guncellemek istediginiz rengi nasil arayalim ? ID = 1 - Renk Adi != 1");
                    int userInputType2 = Convert.ToInt32(Console.ReadLine());
                    if (userInputType2 == 1)
                    {
                        Console.WriteLine("ID yi giriniz");
                        int colorId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Güncellenmek istenen rengin adı : " + colorManager.GetById(colorId).ColorName + "\nGüncellemeye devam edilsin mi? (E/H)");
                        bool yesorno = Console.ReadLine() == "E" ? true:false;
                        if (yesorno)
                        {
                            Console.WriteLine("Yeni adı giriniz");
                            
                            colorManager.Update(new Color { ID = colorId, ColorName = Console.ReadLine() });
                            Console.WriteLine("Basarili");
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Adi giriniz");
                        string colorName = Console.ReadLine();
                        int ID = colorManager.GetByName(colorName).ID;
                        Console.WriteLine("Güncellenmek istenen rengin ID si : " + ID + "\nGüncellemeye devam edilsin mi? (E/H)");
                        bool yesorno = Console.ReadLine() == "E" ? true : false;
                        if (yesorno)
                        {
                            Console.WriteLine("Yeni adı giriniz");

                            colorManager.Update(new Color { ID=ID, ColorName = Console.ReadLine() });
                            Console.WriteLine("Basarili");
                        }

                        else
                        {
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
