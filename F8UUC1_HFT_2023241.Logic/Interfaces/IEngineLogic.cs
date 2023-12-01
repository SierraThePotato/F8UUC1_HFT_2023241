using F8UUC1_HFT_2023241.Models;
using System.Linq;

namespace F8UUC1_HFT_2023241.Logic.Interfaces
{
    public interface IEngineLogic
    {
        void Create(Engine item);
        void Delete(int id);
        Engine Read(int id);
        IQueryable<Engine> ReadAll();
        void Update(Engine item);
    }
}