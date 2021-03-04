using Business.Concrete;
using Core.Entities;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //UserTest();
            //CustomerTest();
            Rental rental1 = new Rental();

            bool cikis = true;
            string secim;
            while (cikis)
            {
                Console.WriteLine("-----------------------Araç Kirala Sistemi---------------");
                Console.WriteLine("1- Araçları Listele");
                Console.WriteLine("2- Araç Ekle");
                Console.WriteLine("3- Araç Sil");
                Console.WriteLine("4- Araç Güncelle");
                Console.WriteLine("5- Marka Ekle");
                Console.WriteLine("6- Marka Sil");
                Console.WriteLine("7- Marka Güncelle");
                Console.WriteLine("8- Araba Kirala");
                Console.WriteLine("9- Araba Teslim");
                Console.WriteLine("10- Çıkış");
                Console.Write("Seçim yapınız: ");
                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Clear();
                        var resultCarListed = carManager.GetCarDetails();
                        if (resultCarListed.Success)
                        {
                            Console.WriteLine(resultCarListed.Messages);
                            foreach (var car in resultCarListed.Data)
                            {
                                Console.WriteLine("Marka: " + car.BrandName + " - Model: " + car.CarName + " - Renk: " + car.ColorName + " - Günlük Fiyat: " + car.DailyPrice);
                            }
                        }
                        else
                        {
                            Console.WriteLine(resultCarListed.Messages);
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Car car1 = new Car();

                        Console.Write("Araç id: ");
                        car1.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç Marka id: ");
                        car1.BrandId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç Renk id: ");
                        car1.ColorId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç model yılı: ");
                        car1.ModelYear = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç fiyatı: ");
                        car1.DailyPrice = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç model: ");
                        car1.Description = Console.ReadLine();

                        var resultCarAdd = carManager.Add(car1);
                        Console.WriteLine(resultCarAdd.Messages);
                        break;

                    case "3":
                        Console.Clear();
                        int id;
                        Console.Write("Silmek istediğiniz Araç id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        var resultCarDelete = carManager.Delete(id);
                        Console.WriteLine(resultCarDelete.Messages);
                        break;

                    case "4":
                        Console.Clear();
                        Car car2 = new Car();

                        Console.Write("Araç id: ");
                        car2.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç Marka id: ");
                        car2.BrandId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç Renk id: ");
                        car2.ColorId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç model yılı: ");
                        car2.ModelYear = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç fiyatı: ");
                        car2.DailyPrice = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araç model: ");
                        car2.Description = Console.ReadLine();

                        var resultCarUpdate = carManager.Update(car2);
                        Console.WriteLine(resultCarUpdate.Messages);
                        break;

                    case "5":
                        Console.Clear();
                        Brand brand1 = new Brand();

                        Console.Write("Marka id: ");
                        brand1.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Marka ismi: ");
                        brand1.BrandName = Console.ReadLine();

                        var resultBrandAdd = brandManager.Add(brand1);
                        Console.WriteLine(resultBrandAdd.Messages);
                        break;

                    case "6":
                        Console.Clear();
                        int idBrand;
                        Console.Write("Silmek istediğiniz Marka id: ");
                        idBrand = Convert.ToInt32(Console.ReadLine());
                        var resultBrandDelete = brandManager.Delete(idBrand);
                        Console.WriteLine(resultBrandDelete.Messages);
                        break;

                    case "7":
                        Console.Clear();
                        Brand brand2 = new Brand();

                        Console.Write("Marka id: ");
                        brand2.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Marka ismi: ");
                        brand2.BrandName = Console.ReadLine();

                        var resultBrandUpdate = brandManager.Update(brand2);
                        Console.WriteLine(resultBrandUpdate.Messages);
                        break;

                    case "8":
                        Console.Clear();

                        var result = rentalManager.CarAvailab();
                        Console.WriteLine(result.Messages);
                        foreach (var rental in result.Data)
                        {
                            var car = carManager.GetCarDetail(rental.Id);
                            Console.WriteLine(car.Data.CarId + " " + car.Data.BrandName + " " + car.Data.CarName + " " + car.Data.ColorName + " " + car.Data.DailyPrice);
                        }

                        
                        Console.WriteLine("Id Yazınız: ");
                        rental1.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Seçim yapınız(Numara): ");
                        rental1.CarId = Convert.ToInt32( Console.ReadLine());
                        Console.WriteLine("Müşteri Id giriniz: ");
                        rental1.CustomerId = Convert.ToInt32(Console.ReadLine());
                        rental1.RentDate = DateTime.Now;
                        var carRental = rentalManager.Add(rental1);

                        Console.WriteLine(carRental.Messages);
                        break;

                    case "9":
                        Console.Clear();
                        Console.Write("Id giriniz: ");
                        int rentalId = Convert.ToInt32(Console.ReadLine());
                        var resultRental = rentalManager.GetById(rentalId);
                        resultRental.Data.ReturnDate = DateTime.Now;
                        var sonuc = rentalManager.Update(resultRental.Data);
                        Console.WriteLine(sonuc.Messages);
                        break;

                    case "10":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer();
            customer.UserId = 10;
            customer.CompanyName = "KONAMI";


            var result = customerManager.Update(customer);
            Console.WriteLine(result.Messages);
            //foreach (var customer in result.Data)
            //{
            //    Console.WriteLine(customer.CompanyName);
            //}
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //User user1 = new User();
            //user1.Id = 10;
            //user1.FirstName = "Hakkıcan";
            //user1.LastName = "Deli";
            //user1.Password = "asdqwe";
            //user1.Email = "Deneme1@gmail.com";
            //var result = userManager.GetAll();
            //Console.WriteLine(result.Messages);
            //foreach(var user in result.Data)
            //{
            //    Console.WriteLine(user.FirstName.Length+user.LastName);
            //}
        }
    }
}
