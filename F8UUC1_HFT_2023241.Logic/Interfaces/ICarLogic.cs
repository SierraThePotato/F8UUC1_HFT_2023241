using F8UUC1_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace F8UUC1_HFT_2023241.Logic.Interfaces
{
    public interface ICarLogic
    {
        IEnumerable<CarBrand> BiggestDisplacementByBrand();
        IEnumerable<CarBrand> CarBrandDisplacement();
        IEnumerable<CarBrand> CarBrandMinDisplacement(int minDisplacement);
        void Create(Car item);
        void Delete(int id);
        IEnumerable<CarBrand> NewestCarByBrand();
        IEnumerable<CarBrand> OldestCarByBrand();
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car item);
    }
}