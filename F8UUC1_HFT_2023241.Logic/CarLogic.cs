using System;
using System.Collections.Generic;
using System.Linq;
using F8UUC1_HFT_2023241.Logic.Interfaces;
using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace F8UUC1_HFT_2023241.Logic
{
    public class CarLogic : ICarLogic
    {

        IRepository<Car> repo;
        IRepository<Brand> brandRepo;
        IRepository<Engine> engineRepo;

        public CarLogic(IRepository<Car> repo)
        {
            this.repo = repo;
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
            var movie = this.repo.Read(id);
            if (movie == null)
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

        public IEnumerable<BrandWithDisplacement> BiggestDisplacementByBrand()
        {
            var brandsByDisplacement = (from car in repo.ReadAll()
                                        join engine in engineRepo.ReadAll() on car.EngineId equals engine.EngineId
                                        join brand in brandRepo.ReadAll() on car.BrandId equals brand.BrandId
                                        group new { engine.Displacement, brand.Name } by brand.BrandId into grouped
                                        select new BrandWithDisplacement
                                        {
                                            BrandID = grouped.Key,
                                            MaxDisplacement = grouped.Max(e => e.Displacement),
                                            BrandName = grouped.First().Name
                                        });
            return brandsByDisplacement;
        }

        public IEnumerable<Car> NewestCarByBrand()
        {
            var newestCarForEachBrand = from car in repo.ReadAll()
                                        join brand in brandRepo.ReadAll() on car.BrandId equals brand.BrandId
                                        group car by brand.BrandId into grouped
                                        select grouped.OrderByDescending(c => c.Year).FirstOrDefault();
            return newestCarForEachBrand;
        }

        public IEnumerable<Car> OldestCarByBrand()
        {
            var oldestCarForEachBrand = from car in repo.ReadAll()
                                        join brand in brandRepo.ReadAll() on car.BrandId equals brand.BrandId
                                        group car by brand.BrandId into grouped
                                        select grouped.OrderBy(c => c.Year).FirstOrDefault();
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
                                 Displacement = engine.Displacement
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
                                 Displacement = engine.Displacement
                             };
            return carDetails.AsEnumerable();
        }


    }

    public class BrandWithDisplacement
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int MaxDisplacement { get; set; }
    }

    public class CarBrand
    {
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int Displacement { get; set; }
    }

    public override bool Equals(object obj)
    {

    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.CarId, )
    }
}
