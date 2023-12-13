using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using F8UUC1_HFT_2023241.Logic.Interfaces;
using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.VisualBasic;

namespace F8UUC1_HFT_2023241.Logic
{
    public class CarLogic : ICarLogic
    {

        IRepository<Car> repo;
        IRepository<Brand> brandRepo;
        IRepository<Engine> engineRepo;

        public CarLogic(IRepository<Car> carRepo, IRepository<Brand> brandRepo, IRepository<Engine> engineRepo)
        {
            this.repo = carRepo;
            this.brandRepo = brandRepo;
            this.engineRepo = engineRepo;
        }

        public void Create(Car item)
        {
            if (item.Year < 1886)
            {
                throw new ArgumentException("Invalid year.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Car Read(int id)
        {
            var car = this.repo.Read(id);
            if (car == null)
            {
                throw new ArgumentException("Car does not exist.");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Car> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Car item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<CarBrand> BiggestDisplacementByBrand()
        {
            var biggestDisplacementCars = repo.ReadAll()
                                            .Join(engineRepo.ReadAll(), car => car.EngineId, engine => engine.EngineId, (car, engine) => new { Car = car, Engine = engine })
                                            .Join(brandRepo.ReadAll(), ce => ce.Car.BrandId, brand => brand.BrandId, (ce, brand) => new CarBrand
                                            {
                                                BrandName = brand.Name,
                                                Model = ce.Car.Model,
                                                Displacement = ce.Engine.Displacement,
                                                Year = ce.Car.Year
                                            })
                                            .AsEnumerable()
                                            .GroupBy(cb => cb.BrandName)
                                            .Select(group => group.OrderByDescending(cb => cb.Displacement).First());

            return biggestDisplacementCars;
        }


        public IEnumerable<CarBrand> NewestCarByBrand()
        {
            var newestCarForEachBrand = repo.ReadAll()
                                            .Join(engineRepo.ReadAll(), car => car.EngineId, engine => engine.EngineId, (car, engine) => new { Car = car, Engine = engine })
                                            .Join(brandRepo.ReadAll(), ce => ce.Car.BrandId, brand => brand.BrandId, (ce, brand) => new CarBrand
                                            {
                                                BrandName = brand.Name,
                                                Model = ce.Car.Model,
                                                Displacement = ce.Engine.Displacement,
                                                Year = ce.Car.Year
                                            })
                                            .AsEnumerable()
                                            .GroupBy(cb => cb.BrandName)
                                            .Select(group => group.OrderByDescending(cb => cb.Year).First());
            return newestCarForEachBrand;
        }

        public IEnumerable<CarBrand> OldestCarByBrand()
        {
            var oldestCarForEachBrand = repo.ReadAll()
                                            .Join(engineRepo.ReadAll(), car => car.EngineId, engine => engine.EngineId, (car, engine) => new { Car = car, Engine = engine })
                                            .Join(brandRepo.ReadAll(), ce => ce.Car.BrandId, brand => brand.BrandId, (ce, brand) => new CarBrand
                                            {
                                                BrandName = brand.Name,
                                                Model = ce.Car.Model,
                                                Displacement = ce.Engine.Displacement,
                                                Year = ce.Car.Year
                                            })
                                            .AsEnumerable()
                                            .GroupBy(cb => cb.BrandName)
                                            .Select(group => group.OrderBy(cb => cb.Year).First());
            return oldestCarForEachBrand;
        }

        public IEnumerable<CarBrand> CarBrandDisplacement()
        {
            var carDetails = from car in repo.ReadAll()
                             join engine in engineRepo.ReadAll() on car.EngineId equals engine.EngineId
                             join brand in brandRepo.ReadAll() on car.BrandId equals brand.BrandId
                             select new CarBrand
                             {
                                 BrandName = brand.Name,
                                 Model = car.Model,
                                 Displacement = engine.Displacement,
                                 Year = car.Year
                             };
            return carDetails.AsEnumerable();
        }

        public IEnumerable<CarBrand> CarBrandMinDisplacement(int minDisplacement)
        {
            var carDetails = from car in repo.ReadAll()
                             join engine in engineRepo.ReadAll() on car.EngineId equals engine.EngineId
                             join brand in brandRepo.ReadAll() on car.BrandId equals brand.BrandId
                             where engine.Displacement >= minDisplacement
                             select new CarBrand
                             {
                                 BrandName = brand.Name,
                                 Model = car.Model,
                                 Displacement = engine.Displacement,
                                 Year = car.Year
                             };
            return carDetails.AsEnumerable();
        }


    }

    public class CarBrand
    {
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int Displacement { get; set; }
        public int Year { get; set; }

        public override bool Equals(object obj)
        {
            CarBrand b = obj as CarBrand;
            if (b == null)
            {
                return false;
            }
            return this.BrandName == b.BrandName
                && this.Model == b.Model
                && this.Displacement == b.Displacement
                && this.Year == b.Year;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.BrandName, this.Model, this.Displacement, this.Year);
        }
    }

}
