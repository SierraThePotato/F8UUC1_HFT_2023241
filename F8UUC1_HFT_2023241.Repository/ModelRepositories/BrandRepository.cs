using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8UUC1_HFT_2023241.Repository.ModelRepositories
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(CarsDbContext ctx) : base(ctx)
        {
        }

        public override Brand Read(int id)
        {
            return this.ctx.Brands.First(t => t.BrandId == id);
        }

        public override void Update(Brand item)
        {
            var old = Read(item.BrandId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
