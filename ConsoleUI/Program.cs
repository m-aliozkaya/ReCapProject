using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //BrandTest();
            //ColorTest();
            //DtoTest();
            //RentalTest();
            //CustomerTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(item.Description);
            }

        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }

            brandManager.Add(new Brand { Name = "Tesla"});
            Console.WriteLine("After operation \n\n");


            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }

            colorManager.Delete(new Color { Name = "ıııı", Id=4});
            Console.WriteLine("After operation \n\n");

            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }
        }
        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{item.CarName} | {item.ColorName} |{item.BrandName} | {item.DailyPrice}");
            }
        }
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental = new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null };

            rentalManager.Add(rental);

            Console.ReadLine();
        }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer {UserId = 1, CompanyName= "Krai Unlimited"});

            Console.ReadLine();
        }
    }
}
