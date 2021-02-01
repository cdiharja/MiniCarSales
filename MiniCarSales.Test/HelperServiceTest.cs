using Microsoft.EntityFrameworkCore;
using MiniCarSales.Model;
using MiniCarSales.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MiniCarSales.Test
{
    class HelperServiceTest
    {
        private HelperService helperService;

        [SetUp]
        public void Setup()
        {
            helperService = new HelperService();

        }

        [Test]
        public void TestGetHomeData()
        {  
            var result = helperService.GenerateHomeData<VehicleTypeMock>(VehicleTypeMock.Car);
            Assert.AreEqual(result.vehiclesMetaData.Count,1);
            Assert.AreEqual(result.vehiclesMetaData[0].PropertiesData.Count, 6);
            Assert.AreEqual(result.vehiclesMetaData[0].PropertiesData[0].PropertyName, "Engine");
            Assert.AreEqual(result.vehiclesMetaData[0].PropertiesData[1].PropertyName, "NumberOfDoor");
            Assert.AreEqual(result.vehiclesMetaData[0].PropertiesData[2].PropertyName, "NumberOfWheels");
            Assert.AreEqual(result.vehiclesMetaData[0].PropertiesData[3].PropertyName, "BodyType");


            result = helperService.GenerateHomeData<VehicleTypeMock2>(VehicleTypeMock2.Car);
            Assert.AreEqual(result.vehiclesMetaData.Count,2);
            Assert.AreEqual(result.vehiclesMetaData[0].PropertiesData.Count, 6);
            Assert.AreEqual(result.vehiclesMetaData[1].PropertiesData.Count, 2);


            result = helperService.GenerateHomeData<VehicleTypeNotExistMock>(VehicleTypeNotExistMock.Bike);
            Assert.AreEqual(result.vehiclesMetaData.Count, 1);
            Assert.AreEqual(result.vehiclesMetaData[0].PropertiesData.Count, 0);

        }
        enum VehicleTypeMock
        {
            Car
        }
        enum VehicleTypeMock2
        {
            Car,
            Boat
        }
        enum VehicleTypeNotExistMock
        {
            Bike
        }
    }

}
