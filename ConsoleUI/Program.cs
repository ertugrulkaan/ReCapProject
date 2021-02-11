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
            //SUBAT7ODEVONCESI();
            //SUBAT11ONCESI();

            //#region USERCRUDOPS
            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Ali", LastName = "Ozdemir", Email = "test@test.com", Password = "12345" });
            //userManager.Delete(new User { ID = 2 });
            //var user = userManager.GetById(3).Data;
            //user.Email = "asdasd@test.com";
            //userManager.Update(user);
            //#endregion

            //#region CUSTOMERCRUDOPS
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { UserID = 3, CompanyName = "TEST SIRKETI" });
            //customerManager.Add(new Customer { UserID = 1, CompanyName = "TEST SIRKETI" });
            //customerManager.Add(new Customer { UserID = 1, CompanyName = "TEST2 SIRKETI" });
            //customerManager.Delete(new Customer { ID = 2 });
            //var customer = customerManager.GetById(3).Data;
            //customer.CompanyName = "ALI SIRKETI";
            ////HATA ALMALI --- BASARILI
            //customerManager.Update(customer);
            //customerManager.Add(new Customer { UserID = 5, CompanyName = "TEST2 SIRKETI" });
            //#endregion

            #region RENTALCRUDOPS

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental { CarID = 1, CustomerID = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(2) });
            //rentalManager.Add(new Rental { CarID = 2, CustomerID = 3, RentDate = DateTime.Now });
            //rentalManager.Add(new Rental { CarID = 3, CustomerID = 1, RentDate = DateTime.Now});
            //rentalManager.Add(new Rental { CarID = 4, CustomerID = 3, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(2) });
            //// bu eklenmemeli
            //rentalManager.Add(new Rental { CarID = 21, CustomerID = 5, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(2) });
            //bunu kiralayamamali
            //rentalManager.Add(new Rental { CarID = 2, CustomerID = 1, RentDate = DateTime.Now });
            //ARABA TESLIM EDILIYOR
            //var rent = rentalManager.GetById(13).Data;
            //rent.ReturnDate = DateTime.Now.AddDays(1);
            //rentalManager.Update(rent);
            //// teslim edilen bir daha kiralandi ve yeniden teslim edildi.
            //rentalManager.Add(new Rental { CarID = 2, CustomerID = 3, RentDate = DateTime.Now.AddDays(5), ReturnDate = DateTime.Now.AddDays(15)});
            //foreach (var item in rentalManager.GetAllWithDetails().Data)
            //{
            //    Console.WriteLine($"{item.RentalID} {item.CustomerEmail} {item.CarName} {item.ColorName} {item.CustomerFirstName} {item.CarModelYear} ");
            //}
            #endregion



        }

        private static void SUBAT11ONCESI()
        {
            //#region CAR CRUD OPERATIONS
            //// CAR CRUD OPERATIONS 
            //CarManager carManager = new CarManager(new EfCarDal());
            //// CARDTO LIST ALL
            //foreach (var car in carManager.GetAllWithDetails())
            //{
            //    Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
            //}
            //Console.WriteLine("---------------------------------------------------------------------------------------------");
            //Console.WriteLine("---------------------------------------------------------------------------------------------");
            //Console.WriteLine("---------------------------------------------------------------------------------------------");
            //Car car1 = new Car()
            //{
            //    BrandId = 10,
            //    ColorId = 2,
            //    DailyPrice = 195,
            //    ModelYear = 2019,
            //    Description = "Az yakar cok kacar",
            //    CarName = "Citroen C5 "
            //};

            //// ADD AND LIST LAST ADDED CAR
            ////carManager.Add(car1);
            //Console.WriteLine(carManager.GetLastAddedCar().CarName + " - " + carManager.GetLastAddedCar().ID);
            //// DELETE CAR WITH ID = 8
            ////carManager.Delete(new Car { ID = 8 });
            //// UPDATE CAR WITH ID = 11 
            //Car car2 = new Car()
            //{
            //    ID = 11,
            //    BrandId = 10,
            //    ColorId = 2,
            //    DailyPrice = 195,
            //    ModelYear = 2019,
            //    Description = "Otomatik vites dizel ekonomik",
            //    CarName = "Citroen C3 "
            //};
            ////carManager.Update(car2);
            //Console.WriteLine(carManager.GetById(11).Description + " - " + carManager.GetById(11).CarName);
            //#endregion
            //#region COLOR CRUD OPERATIONS
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ID + " - " + color.ColorName);
            //}
            //foreach (var color in colorManager.GetAll())
            //{
            //    if (color.ColorName == "test")
            //    {
            //        //colorManager.Delete(color);
            //    }
            //}
            //Color color1 = new Color()
            //{
            //    ColorName = "asddsa"
            //};
            ////colorManager.Add(color1);
            ////colorManager.Update(new Color { ID = 16, ColorName = "Yesil" });
            //#endregion
            //#region BRAND CRUD OPERATIONS
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.ID + " - " + brand.BrandName);
            //}
            ////brandManager.Add(new Brand { BrandName = "Ferrari" });
            ////brandManager.Update(new Brand { ID = 11, BrandName = "Pagani" });
            ////brandManager.Delete(new Brand { ID = 11});
            //#endregion
        }

        private static void SUBAT7ODEVONCESI()
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());



            //Console.WriteLine("Araba Kiralama Programına Hoş Geldiniz");
            //Console.WriteLine("Mevcut Arabalar");
            //Console.WriteLine("ID\tRenk\t\tMarka\t\t\tModel Yılı\t\tGünlük Fiyat\t\tAçıklama");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"{car.ID}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //}
            //Console.WriteLine("-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----\t-----");
            //Console.WriteLine("\t\t\t\t\t\tMENÜ");
            //Console.WriteLine("1-Renk Ekleme");
            //Console.WriteLine("2-Renk Silme");
            //Console.WriteLine("3-Renk Güncelleme");
            //Console.WriteLine("Sadece sayı girin");
            //string userInput = Console.ReadLine();
            //switch (Convert.ToInt32(userInput))
            //{
            //    case 1:
            //        Console.WriteLine("Renk adı girin");
            //        string ColorName = Console.ReadLine();
            //        colorManager.Add(new Color { ColorName = ColorName });
            //        break;
            //    case 2:
            //        Console.WriteLine("Silmek istediginiz rengi nasil arayalim ? ID = 1 - Renk Adi != 1");
            //        int userInputType = Convert.ToInt32(Console.ReadLine());
            //        if (userInputType == 1)
            //        {
            //            Console.WriteLine("ID yi giriniz");
            //            colorManager.Delete(colorManager.GetById(Convert.ToInt32(Console.ReadLine())));
            //            Console.WriteLine("Basarili");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Adi giriniz");
            //            colorManager.Delete(colorManager.GetByName(Console.ReadLine()));
            //            Console.WriteLine("Basarili");
            //        }
            //        break;
            //    case 3:
            //        Console.WriteLine("Guncellemek istediginiz rengi nasil arayalim ? ID = 1 - Renk Adi != 1");
            //        int userInputType2 = Convert.ToInt32(Console.ReadLine());
            //        if (userInputType2 == 1)
            //        {
            //            Console.WriteLine("ID yi giriniz");
            //            int colorId = Convert.ToInt32(Console.ReadLine());
            //            Console.WriteLine("Güncellenmek istenen rengin adı : " + colorManager.GetById(colorId).ColorName + "\nGüncellemeye devam edilsin mi? (E/H)");
            //            bool yesorno = Console.ReadLine() == "E" ? true : false;
            //            if (yesorno)
            //            {
            //                Console.WriteLine("Yeni adı giriniz");

            //                colorManager.Update(new Color { ID = colorId, ColorName = Console.ReadLine() });
            //                Console.WriteLine("Basarili");
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("Adi giriniz");
            //            string colorName = Console.ReadLine();
            //            int ID = colorManager.GetByName(colorName).ID;
            //            Console.WriteLine("Güncellenmek istenen rengin ID si : " + ID + "\nGüncellemeye devam edilsin mi? (E/H)");
            //            bool yesorno = Console.ReadLine() == "E" ? true : false;
            //            if (yesorno)
            //            {
            //                Console.WriteLine("Yeni adı giriniz");

            //                colorManager.Update(new Color { ID = ID, ColorName = Console.ReadLine() });
            //                Console.WriteLine("Basarili");
            //            }

            //            else
            //            {
            //                break;
            //            }
            //        }
            //        break;
            //    default:
            //        break;
            }
    }
}