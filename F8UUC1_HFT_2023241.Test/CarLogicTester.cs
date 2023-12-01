using F8UUC1_HFT_2023241.Logic;
using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace F8UUC1_HFT_2023241.Test
{

    [TestFixture]
    public class CarLogicTester
    {
        CarLogic carLogic;
        Mock<IRepository<Car>> mockCarRepo;

        BrandLogic Brandlogic;
        Mock<IRepository<Brand>> mockBrandRepo;

        EngineLogic Enginelogic;
        Mock<IRepository<Engine>> mockEnginedRepo;

        [SetUp]
        public void Init()
        {
            mockCarRepo = new Mock<IRepository<Car>>();
            mockCarRepo.Setup(m => m.ReadAll()).Returns(new List<Car>()
            {
                new Car("1#1#Camry#1#2020"),
                new Car("2#2#Civic#2#2019"),
                new Car("3#3#F-150#3#2021"),
                new Car("4#4#Malibu#2#2020"),
            }.AsQueryable());
            carLogic = new CarLogic(mockCarRepo.Object);

        }

        [Test]
        public void CarCreateTestValid()
        {
            var car = new Car() { Year = 1886 };
            carLogic.Create(car);
            mockCarRepo.Verify(r => r.Create(car), Times.Once);
        }

        [Test]
        public void CarCreateTestInvalid()
        {
            var car = new Car() { Year = 1885 };
            try
            { 
                carLogic.Create(car);
            }
            catch
            {

            }
            mockCarRepo.Verify(r => r.Create(car), Times.Never);
        }
    }
}
