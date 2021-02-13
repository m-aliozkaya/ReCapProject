using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {Id = 1, ColorId = 1, BrandId=1, DailyPrice=25, Description= "Çok güzel bir araba", ModelYear= 2000 }, 
                new Car {Id = 2, ColorId = 2, BrandId=4, DailyPrice=50, Description= "Güzel sayılır", ModelYear= 1980 }, 
                new Car {Id = 3, ColorId = 2, BrandId=4, DailyPrice=99, Description= "Kötü", ModelYear= 2006 }, 
                new Car {Id = 4, ColorId = 3, BrandId=3, DailyPrice=80, Description= "Falan filan", ModelYear= 2004 }, 
                new Car {Id = 5, ColorId = 4, BrandId=7, DailyPrice=44, Description= "Dimi ama", ModelYear= 1999 }, 
                new Car {Id = 6, ColorId = 4, BrandId=6, DailyPrice=21, Description= "Aaaaa", ModelYear= 2015 }, 
            
            } ;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c=> c.Id == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
