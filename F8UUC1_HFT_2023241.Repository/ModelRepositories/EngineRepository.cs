using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8UUC1_HFT_2023241.Repository.ModelRepositories
{
    public class EngineRepository : Repository<Engine>, IRepository<Engine>
    {
        public EngineRepository(CarsDbContext ctx) : base(ctx)
        {
        }

        public override Engine Read(int id)
        {
            return this.ctx.Engines.First(t => t.EngineId == id);
        }

        public override void Update(Engine item)
        {
            var old = Read(item.EngineId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
