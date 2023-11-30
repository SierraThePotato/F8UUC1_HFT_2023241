using F8UUC1_HFT_2023241.Logic.Interfaces;
using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8UUC1_HFT_2023241.Logic
{
    internal class EngineLogic : IEngineLogic
    {
        IRepository<Engine> repo;

        public void Create(Engine item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Engine Read(int id)
        {
            var movie = this.repo.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("Engine does not exist.");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Engine> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Engine item)
        {
            this.repo.Update(item);
        }
    }
}
