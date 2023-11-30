using System;
using ConsoleTools;
using F8UUC1_HFT_2023241.Logic;
using F8UUC1_HFT_2023241.Models;
using F8UUC1_HFT_2023241.Repository;
using F8UUC1_HFT_2023241.Repository.ModelRepositories;
using F8UUC1_HFT_2023241.Repository.Database;

namespace F8UUC1_HFT_2023241.Client
{
    internal class Program
    {
        static CarLogic carLogic;
        static EngineLogic engineLogic;
        static BrandLogic brandLogic;

        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }

        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }

        static void List(string entity)
        {
            if (entity == "Car")
            {
                var items = carLogic.ReadAll();
                Console.WriteLine("Model" + "\t" + "Year");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Model + "\t" + item.Year);
                }
            }
            else if (entity == "Engine")
            {
                var items = engineLogic.ReadAll();
                Console.WriteLine("Type" + "\t" + "Displacement");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Type + "\t" + item.Displacement);
                }
            }
            else if (entity == "Brand")
            {
                var items = brandLogic.ReadAll();
                Console.WriteLine("Name" + "\t" + "Country");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Name + "\t" + item.Country);
                }
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {

            var ctx = new CarsDbContext();

            var carRepo = new CarRepository(ctx);
            var engineRepo = new EngineRepository(ctx);
            var brandRepo = new BrandRepository(ctx);
            
            carLogic = new CarLogic(carRepo);
            engineLogic = new EngineLogic(engineRepo);
            brandLogic = new BrandLogic(brandRepo);

            var carSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Create", () => Create("Car"))
                .Add("List", () => List("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Create", () => Create("Brand"))
                .Add("List", () => List("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Exit", ConsoleMenu.Close);

            var engineSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Create", () => Create("Engine"))
                .Add("List", () => List("Engine"))
                .Add("Update", () => Update("Engine"))
                .Add("Delete", () => Delete("Engine"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Cars", () => carSubMenu.Show())
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Engines", () => engineSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
