using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            bool cikis = true;
            string secim;
            while (cikis)
            {
                Console.WriteLine("-----------------------Araç Kirala Sistemi---------------");
                Console.WriteLine("1- Araçları Listele");
                Console.WriteLine("2- Araç Ekle");
                Console.WriteLine("3- Araç Sil");
                Console.WriteLine("4- Araç Güncelle");
                Console.WriteLine("9- Çıkış");
                Console.Write("Seçim yapınız: ");
                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Clear();
                        foreach(Car car in carManager.GetAll())
                        {
                            carManager.Print(car);
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

                        carManager.Add(car1);
                        break;

                    case "3":
                        Console.Clear();
                        int id;
                        Console.Write("Silmek istediğiniz Araç id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        carManager.Delete(id);
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

                        carManager.Update(car2);
                        break;

                    case "9":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
