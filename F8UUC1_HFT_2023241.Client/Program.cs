using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using ConsoleTools;
using F8UUC1_HFT_2023241.Logic;
using F8UUC1_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace F8UUC1_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Car")
            {
                Car car = new Car();

                foreach (var prop in typeof(Car).GetProperties())
                {
                    if (prop.GetCustomAttributes(false)[0].ToString().Equals("System.ComponentModel.DataAnnotations.RequiredAttribute"))
                    {
                        Console.Write("Enter car " + prop.Name + ": ");
                        string value = Console.ReadLine();
                        if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(car, value);
                        }
                        else
                        {
                            Type proptype = prop.PropertyType;
                            var parseMethod = proptype.GetMethods().First(t => t.Name.Contains("Parse"));
                            var converted = parseMethod.Invoke(null, new object[] { value });
                            prop.SetValue(car, converted);
                        }
                    }
                }

                rest.Post(car, "car");
            }
            else if (entity == "Engine")
            {
                Engine engine = new Engine();

                foreach (var prop in typeof(Engine).GetProperties())
                {
                    if (prop.GetCustomAttributes(false)[0].ToString().Equals("System.ComponentModel.DataAnnotations.RequiredAttribute"))
                    {
                        Console.Write("Enter engine " + prop.Name + ": ");
                        string value = Console.ReadLine();
                        if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(engine, value);
                        }
                        else
                        {
                            Type proptype = prop.PropertyType;
                            var parseMethod = proptype.GetMethods().First(t => t.Name.Contains("Parse"));
                            var converted = parseMethod.Invoke(null, new object[] { value });
                            prop.SetValue(engine, converted);
                        }
                    }
                }

                rest.Post(engine, "engine");
            }
            else if (entity == "Brand")
            {
                Brand brand = new Brand();

                foreach (var prop in typeof(Brand).GetProperties())
                {
                    if (prop.GetCustomAttributes(false)[0].ToString().Equals("System.ComponentModel.DataAnnotations.RequiredAttribute"))
                    {
                        Console.Write("Enter brand " + prop.Name + ": ");
                        string value = Console.ReadLine();
                        if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(brand, value);
                        }
                        else
                        {
                            Type proptype = prop.PropertyType;
                            var parseMethod = proptype.GetMethods().First(t => t.Name.Contains("Parse"));
                            var converted = parseMethod.Invoke(null, new object[] { value });
                            prop.SetValue(brand, converted);
                        }
                    }
                }

                rest.Post(brand, "brand");
            }
        }

        static void Update(string entity)
        {
            string[] args = new string[0];
            if (entity == "Car")
            {
                Console.Write("Enter CarID to update: ");
                int id = int.Parse(Console.ReadLine());
                Car toUpdate = rest.Get<Car>(id, "car");

                foreach (var prop in typeof(Car).GetProperties())
                {
                    if (prop.GetCustomAttributes(false)[0].ToString().Equals("System.ComponentModel.DataAnnotations.RequiredAttribute"))
                    {
                        Console.Write("Enter new value for: " + prop.Name + "(press enter to keep original): ");
                        string value = Console.ReadLine();
                        if (value.Equals(""))
                        {

                        }
                        else if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(toUpdate, value);
                        }
                        else
                        {
                            Type proptype = prop.PropertyType;
                            var parseMethod = proptype.GetMethods().First(t => t.Name.Contains("Parse"));
                            var converted = parseMethod.Invoke(null, new object[] { value });
                            prop.SetValue(toUpdate, converted);
                        }
                    }
                }

                rest.Put(toUpdate, "car");
            }
            else if (entity == "Engine")
            {
                Console.Write("Enter EngineID to update: ");
                int id = int.Parse(Console.ReadLine());
                Engine toUpdate = rest.Get<Engine>(id, "engine");

                foreach (var prop in typeof(Engine).GetProperties())
                {
                    if (prop.GetCustomAttributes(false)[0].ToString().Equals("System.ComponentModel.DataAnnotations.RequiredAttribute"))
                    {
                        Console.Write("Enter new value for: " + prop.Name + "(press enter to keep original): ");
                        string value = Console.ReadLine();
                        if (value.Equals(""))
                        {

                        }
                        else if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(toUpdate, value);
                        }
                        else
                        {
                            Type proptype = prop.PropertyType;
                            var parseMethod = proptype.GetMethods().First(t => t.Name.Contains("Parse"));
                            var converted = parseMethod.Invoke(null, new object[] { value });
                            prop.SetValue(toUpdate, converted);
                        }
                    }
                }

                rest.Put(toUpdate, "engine");
            }
            else if (entity == "Brand")
            {
                Console.Write("Enter BrandID to update: ");
                int id = int.Parse(Console.ReadLine());
                Brand toUpdate = rest.Get<Brand>(id, "brand");

                foreach (var prop in typeof(Brand).GetProperties())
                {
                    if (prop.GetCustomAttributes(false)[0].ToString().Equals("System.ComponentModel.DataAnnotations.RequiredAttribute"))
                    {
                        Console.Write("Enter new value for: " + prop.Name + "(press enter to keep original): ");
                        string value = Console.ReadLine();
                        if (value.Equals(""))
                        {

                        }
                        else if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(toUpdate, value);
                        }
                        else
                        {
                            Type proptype = prop.PropertyType;
                            var parseMethod = proptype.GetMethods().First(t => t.Name.Contains("Parse"));
                            var converted = parseMethod.Invoke(null, new object[] { value });
                            prop.SetValue(toUpdate, converted);
                        }
                    }
                }

                rest.Put(toUpdate, "brand");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Car")
            {
                Console.Write("Enter CarID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "car");
            }
            else if (entity == "Engine")
            {
                Console.Write("Enter EngineID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "engine");
            }
            else if (entity == "Brand")
            {
                Console.Write("Enter BrandID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "brand");
            }
        }

        static void List(string entity)
        {
            if (entity == "Car")
            {
                List<Car> cars = rest.Get<Car>("car");
                foreach (Car car in cars)
                {
                    Console.WriteLine($"{car.CarId}: {car.Model}");
                }
;
            }
            else if (entity == "Engine")
            {
                List<Engine> engines = rest.Get<Engine>("engine");
                foreach (Engine engine in engines)
                {
                    Console.WriteLine($"{engine.EngineId}: {engine.Type}");
                }
            }
            else if (entity == "Brand")
            {
                List<Brand> brands = rest.Get<Brand>("brand");
                foreach (Brand brand in brands)
                {
                    Console.WriteLine($"{brand.BrandId}: {brand.Name}");
                }
            }
            Console.ReadLine();
        }

        static void DisplacementByBrand()
        {
            var result = rest.Get<CarBrand>("NonCrud/BiggestDisplacementByBrand");
            foreach (CarBrand car in result)
            {
                Console.WriteLine($"{car.BrandName}: {car.Model} {car.Displacement}");
            }
            Console.ReadLine();
        }
        static void NewestCarByBrand()
        {
            var result = rest.Get<CarBrand>("NonCrud/NewestCarByBrand");
            foreach (CarBrand car in result)
            {
                Console.WriteLine($"{car.BrandName}: {car.Model} {car.Year}");
            }
            Console.ReadLine();
        }
        static void OldestCarByBrand()
        {
            var result = rest.Get<CarBrand>("NonCrud/OldestCarByBrand");
            foreach (CarBrand car in result)
            {
                Console.WriteLine($"{car.BrandName}: {car.Model} {car.Year}");
            }
            Console.ReadLine();
        }
        static void CarBrandDisplacement()
        {
            var result = rest.Get<CarBrand>("NonCrud/CarBrandDisplacement");
            foreach (CarBrand car in result)
            {
                Console.WriteLine($"{car.BrandName} {car.Model}: {car.Displacement}");
            }
            Console.ReadLine();
        }
        static void CarBrandMinDisplacement()
        {
            int mindispalcement = 0;
            bool success = false;
            do
            {
                Console.Write("Minimum displacement: ");
                success = int.TryParse(Console.ReadLine(), out mindispalcement);
            } while (!success);
            var result = rest.Get<CarBrand>("NonCrud/CarBrandMinDisplacement/" + mindispalcement);
            foreach (CarBrand car in result)
            {
                Console.WriteLine($"{car.BrandName} {car.Model}: {car.Displacement}");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:62002/", "car");


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

            var noncrudMenu = new ConsoleMenu(args, level: 1)
                .Add("Biggest displacement by brand", () => DisplacementByBrand())
                .Add("Newest car by brand", () => NewestCarByBrand())
                .Add("Oldest car by brand", () => OldestCarByBrand())
                .Add("Cars with displacement", () => CarBrandDisplacement())
                .Add("Cars with minimum displacement", () => CarBrandMinDisplacement())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Cars", () => carSubMenu.Show())
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Engines", () => engineSubMenu.Show())
                .Add("Non-CRUD", () => noncrudMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
