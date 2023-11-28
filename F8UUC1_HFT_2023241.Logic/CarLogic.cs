using System;
using System.Collections.Generic;
using System.Linq;
using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace F8UUC1_HFT_2023241.Logic
{
    public class CarLogic
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

    }

    public class BrandWithDisplacement
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int MaxDisplacement { get; set; }
    }
}
