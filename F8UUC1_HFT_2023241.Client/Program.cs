using System;
using ConsoleTools;
using F8UUC1_HFT_2023241.Models;

namespace F8UUC1_HFT_2023241.Client
{
    internal class Program
    {

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

            }
            else if (entity == "Engine")
            {

            }
            else if (entity == "Brand")
            {

            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
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
