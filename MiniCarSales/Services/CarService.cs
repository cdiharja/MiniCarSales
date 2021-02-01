using Microsoft.EntityFrameworkCore;
using MiniCarSales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarSales.Services
{
    public class CarService:IRepositoryService<Car>
    {

        private readonly MyContext myContext;
        public CarService(MyContext myContext)
        {  
            this.myContext = myContext;
        }

        public IEnumerable<Car> GetAll()
        {
            return myContext.Cars.ToList<Car>();
        }

        public Car Create(Car car)
        {
            try
            {
                myContext.Cars.Add(car);
                myContext.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                return null;

            }
            catch (Exception ex)
            {
                return null;

            }
            return car;
        }
    }
}
