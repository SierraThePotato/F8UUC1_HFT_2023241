using F8UUC1_HFT_2023241.Models;
using System.Linq;

namespace F8UUC1_HFT_2023241.Logic.Interfaces
{
    internal interface IBrandLogic
    {
        void Create(Brand item);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand item);
    }
}