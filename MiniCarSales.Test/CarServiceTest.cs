using Microsoft.EntityFrameworkCore;
using MiniCarSales.Model;
using MiniCarSales.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniCarSales.Test
{
    [TestFixture]
    public class CarServiceTest
    {
        private Boolean isSeeded = false;
        private CarService carService;
        private DbContextOptions<MyContext> dbContextOptions = new DbContextOptionsBuilder<MyContext>()
               .UseInMemoryDatabase(databaseName: "TestDb")
               .Options;

        [SetUp]
        public void Setup()
        {
            if (!isSeeded)
            {
                isSeeded = true;
                SeedDb();
            }
            carService = new CarService(new MyContext(dbContextOptions));
        }

        [Test]
        public void TestInitialDbHasThreeCarsAndAddNewCar()
        {
            using (var context = new MyContext(dbContextOptions))
            {
                var result = carService.GetAll();
                Assert.AreEqual(result.ToList().Count, 3);
                Assert.AreEqual(result.ToList()[0].BodyType, CarBodyType.Hatchback);
                Assert.AreEqual(result.ToList()[1].Id, 2);
                Assert.AreEqual(result.ToList()[2].Make, "Honda");

                Car newCar = new Car
                {
                    Id = 6,
                    BodyType = CarBodyType.Hatchback,
                    CreatedDate = DateTime.UtcNow.AddDays(-20),
                    Engine = "XXYY",
                    Make = "BMW",
                    Model = "X1",
                    NumberOfDoor = 4,
                    NumberOfWheels = 4
                };
                carService.Create(newCar);

                result = carService.GetAll();
                Assert.AreEqual(result.ToList().Count, 4);

            }
        }

        private void SeedDb()
        {
            using (var context = new MyContext(dbContextOptions))
            {
                var cars = new List<Car>
                {
                    new Car { Id = 1,BodyType=CarBodyType.Hatchback,CreatedDate=DateTime.UtcNow.AddDays(-20),Engine="XXYY",Make="Toyota",Model="RAV 4",NumberOfDoor=4,NumberOfWheels=4},
                    new Car { Id = 2,BodyType=CarBodyType.Hatchback,CreatedDate=DateTime.UtcNow.AddDays(-10),Engine="X123",Make="Ford",Model="Focus",NumberOfDoor=4,NumberOfWheels=4}, 
                    new Car { Id = 3,BodyType=CarBodyType.Sedan,CreatedDate=DateTime.UtcNow.AddDays(-30),Engine="1234",Make="Honda",Model="CRV",NumberOfDoor=4,NumberOfWheels=4}
                };
                context.AddRange(cars);
                context.SaveChanges();
            }
          
        }
    }
}