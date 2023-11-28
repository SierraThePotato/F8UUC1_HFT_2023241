using System;
using System.Linq;
using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository;

namespace F8UUC1_HFT_2023241.Logic
{
    public class CarLogic
    {

        IRepository<Car> repo;

        public CarLogic(IRepository<Car> repo)
        {
            this.repo = repo;
        }

        public void Create(Car item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Car Read(int id)
        {
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
    }
}
