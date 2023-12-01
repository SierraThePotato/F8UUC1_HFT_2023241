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

        BrandLogic brandLogic;
        Mock<IRepository<Brand>> mockBrandRepo;

        EngineLogic engineLogic;
        Mock<IRepository<Engine>> mockEngineRepo;

        [SetUp]
        public void Init()
        {
            mockBrandRepo = new Mock<IRepository<Brand>>();
            mockBrandRepo.Setup(m => m.ReadAll()).Returns(new List<Brand>()
            {
                new Brand("1#Toyota#Kiichiro Toyoda#Toyota Industries#Japan"),
                new Brand("2#Honda#Soichiro Honda#Honda Motor Co., Ltd.#Japan"),
                new Brand("3#Ford#Henry Ford#Ford Motor Company#USA"),
                new Brand("4#Chevrolet#Louis Chevrolet and William C. Durant#General Motors#USA"),
            }.AsQueryable());
            brandLogic = new BrandLogic(mockBrandRepo.Object);

            mockEngineRepo = new Mock<IRepository<Engine>>();
            mockEngineRepo.Setup(m => m.ReadAll()).Returns(new List<Engine>()
            {
                new Engine("1#V6#3500#220#Gasoline"),
                new Engine("2#I4#2000#150#Gasoline"),
                new Engine("3#V8#5000#300#Diesel"),
                new Engine("4#Electric#0#350#Electric"),
            }.AsQueryable());
            engineLogic = new EngineLogic(mockEngineRepo.Object);

            mockCarRepo = new Mock<IRepository<Car>>();
            mockCarRepo.Setup(m => m.ReadAll()).Returns(new List<Car>()
            {
                new Car("1#1#Camry#1#2020"),
                new Car("2#2#Civic#2#2019"),
                new Car("3#3#F-150#3#2021"),
                new Car("4#4#Malibu#2#2020"),
                new Car("4#4#Volt#2#2021"),
            }.AsQueryable());
            carLogic = new CarLogic(mockCarRepo.Object, mockBrandRepo.Object, mockEngineRepo.Object);

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

        [Test]
        public void BrandCreateTestValid()
        {
            var brand = new Brand() { Name = "MG" };
            brandLogic.Create(brand);
            mockBrandRepo.Verify(r => r.Create(brand), Times.Once);
        }

        [Test]
        public void BrandCreateTestInvalid()
        {
            var brand = new Brand() { Name = "G" };
            try
            {
                brandLogic.Create(brand);
            }
            catch
            {

            }
            mockBrandRepo.Verify(r => r.Create(brand), Times.Never);
        }

        [Test]
        public void EngineCreateTestValid()
        {
            var engine = new Engine() { Displacement = 0 };
            engineLogic.Create(engine);
            mockEngineRepo.Verify(r => r.Create(engine), Times.Once);
        }

        [Test]
        public void EngineCreateTestInvalid()
        {
            var engine = new Engine() { Displacement = -1 };
            try
            {
                engineLogic.Create(engine);
            }
            catch
            {

            }
            mockEngineRepo.Verify(r => r.Create(engine), Times.Never);
        }

        [Test]
        public void NewestCarByBrandTest()
        {
            var actual = carLogic.NewestCarByBrand().ToList();
            var expected = new List<Car>
            {
                new Car("1#1#Camry#1#2020"),
                new Car("2#2#Civic#2#2019"),
                new Car("3#3#F-150#3#2021"),
                new Car("4#4#Volt#2#2021"),
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OldestCarByBrandTest()
        {
            var actual = carLogic.OldestCarByBrand().ToList();
            var expected = new List<Car>
            {
                new Car("1#1#Camry#1#2020"),
                new Car("2#2#Civic#2#2019"),
                new Car("3#3#F-150#3#2021"),
                new Car("4#4#Malibu#2#2020"),
            };
            Assert.AreEqual(expected, actual);
        }
    }
}
