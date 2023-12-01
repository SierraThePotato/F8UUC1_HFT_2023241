using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8UUC1_HFT_2023241.Repository.ModelRepositories
{
    public class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(CarsDbContext ctx) : base(ctx)
        {
        }

        public override Car Read(int id)
        {
            return ctx.Cars.First(t => t.CarId == id);
        }

        public override void Update(Car item)
        {
            var old = Read(item.CarId);
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
