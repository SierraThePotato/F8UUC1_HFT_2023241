using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using F8UUC1_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace F8UUC1_HFT_2023241.Repository.Database
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public CarsDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("car");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(car => car
                .HasOne(car => car.Engine)
                .WithMany(engine => engine.Cars)
                .HasForeignKey(car => car.EngineId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Car>(car => car
                .HasOne(car => car.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new Car("1#1#Camry#1#2020"),
            new Car("2#2#Civic#2#2019"),
            new Car("3#3#F-150#3#2021"),
            new Car("4#4#Malibu#2#2020"),
            new Car("5#5#Altima#1#2018"),
            new Car("6#1#Corolla#2#2022"),
            new Car("7#2#Accord#1#2017"),
            new Car("8#3#Mustang#3#2019"),
            new Car("9#4#Cruze#2#2020"),
            new Car("10#5#Rogue#2#2021"),
            new Car("11#6#Mazda3#2#2022"),
            new Car("12#7#Passat#1#2021"),
            new Car("13#8#Outback#2#2020"),
            new Car("14#9#Elantra#2#2019"),
            new Car("15#10#Optima#2#2021"),
            new Car("16#11#C-Class#1#2018"),
            new Car("17#12#3 Series#2#2017"),
            new Car("18#13#A4#2#2016"),
            new Car("19#14#ES#1#2015"),
            new Car("20#15#S60#2#2020"),
            new Car("21#16#Model 3#4#2019"),
            new Car("22#17#XF#1#2018"),
            new Car("23#18#Discovery#3#2020"),
            new Car("24#19#Outlander#2#2019"),
            new Car("25#20#911#5#2021"),
            new Car("26#21#TLX#2#2020"),
            new Car("27#22#Q50#1#2017"),
            new Car("28#23#G80#1#2016"),
            new Car("29#24#Cooper#2#2015"),
            new Car("30#25#500#2#2014"),
            new Car("31#26#Wrangler#3#2022"),
            new Car("32#27#1500#3#2021"),
            new Car("33#28#Sierra#3#2020"),
            new Car("34#29#CTS#1#2019"),
            new Car("35#30#Regal#2#2018"),
            new Car("36#31#300#1#2021"),
            new Car("37#32#Charger#3#2020"),
            new Car("38#33#MKZ#2#2017"),
            new Car("39#34#Giulia#2#2016"),
            new Car("40#35#488 GTB#3#2015"),
            new Car("41#36#Aventador#6#2014"),
            new Car("42#37#Ghibli#1#2020"),
            new Car("43#38#720S#3#2019"),
            new Car("44#39#Chiron#7#2018"),
            new Car("45#40#Huayra#6#2017"),
            new Car("46#41#Jesko#3#2016"),
            new Car("47#42#Vantage#3#2020"),
            new Car("48#43#Continental GT#3#2019"),
            new Car("49#44#Phantom#6#2018"),
            new Car("50#45#Evora#2#201"),
            new Car("51#1#RAV4#1#2022"),
            new Car("52#2#Fit#2#2021"),
            new Car("53#3#Ranger#3#2022"),
            new Car("54#4#Equinox#2#2021"),
            new Car("55#5#Sentra#1#2020"),
            new Car("56#1#Highlander#1#2022"),
            new Car("57#2#Civic#2#2020"),
            new Car("58#3#Explorer#3#2021"),
            new Car("59#4#Traverse#2#2022"),
            new Car("60#5#Maxima#1#2021"),
            new Car("61#6#CX-5#2#2021"),
            new Car("62#7#Jetta#1#2022"),
            new Car("63#8#Forester#2#2021"),
            new Car("64#9#Sonata#2#2020"),
            new Car("65#10#K5#2#2022"),
            new Car("66#11#GLC#1#2022"),
            new Car("67#12#X5#2#2022"),
            new Car("68#13#Q5#2#2021"),
            new Car("69#14#RX#1#2022"),
            new Car("70#15#V60#2#2021"),
            new Car("71#16#Model Y#4#2021"),
            new Car("72#17#XE#1#2022"),
            new Car("73#18#Range Rover#3#2022"),
            new Car("74#19#Eclipse Cross#2#2021"),
            new Car("75#20#Cayman#3#2022"),
            new Car("76#21#ILX#2#2022"),
            new Car("77#22#QX60#1#2021"),
            new Car("78#23#GV80#1#2021"),
            new Car("79#24#Countryman#2#2020"),
            new Car("80#25#500X#2#2022"),

        });

            modelBuilder.Entity<Brand>().HasData(new Brand[] {
                new Brand("1#Toyota#Kiichiro Toyoda#Toyota Industries#Japan"),
                new Brand("2#Honda#Soichiro Honda#Honda Motor Co., Ltd.#Japan"),
                new Brand("3#Ford#Henry Ford#Ford Motor Company#USA"),
                new Brand("4#Chevrolet#Louis Chevrolet and William C. Durant#General Motors#USA"),
                new Brand("5#Nissan#Masujiro Hashimoto#Nissan Motor Co., Ltd.#Japan"),
                new Brand("6#Mazda#Jujiro Matsuda#Mazda Motor Corporation#Japan"),
                new Brand("7#Volkswagen#Ferdinand Porsche#Volkswagen Group#Germany"),
                new Brand("8#Subaru#Kenji Kita#Subaru Corporation#Japan"),
                new Brand("9#Hyundai#Chung Ju-yung#Hyundai Motor Company#South Korea"),
                new Brand("10#Kia#Chung Ju-yung#Kia Corporation#South Korea"),
                new Brand("11#Mercedes-Benz#Karl Benz and Gottlieb Daimler#Daimler AG#Germany"),
                new Brand("12#BMW#Karl Rapp and Gustav Otto#Bayerische Motoren Werke AG#Germany"),
                new Brand("13#Audi#August Horch#Volkswagen Group#Germany"),
                new Brand("14#Lexus#Toyota Group#Toyota Motor Corporation#Japan"),
                new Brand("15#Volvo#Assar Gabrielsson and Gustaf Larson#Volvo Group#Sweden"),
                new Brand("16#Tesla#Elon Musk#Tesla, Inc.#USA"),
                new Brand("17#Jaguar#Sir William Lyons and William Walmsley#Jaguar Land Rover#UK"),
                new Brand("18#Land Rover#Maurice Wilks and Spencer Wilks#Jaguar Land Rover#UK"),
                new Brand("19#Mitsubishi#Iwasaki Yataro#Mitsubishi Group#Japan"),
                new Brand("20#Porsche#Ferdinand Porsche#Volkswagen Group#Germany"),
                new Brand("21#Acura#Honda Motor Co., Ltd.#Honda Motor Co., Ltd.#Japan"),
                new Brand("22#Infiniti#Nissan Motor Co., Ltd.#Nissan Motor Co., Ltd.#Japan"),
                new Brand("23#Genesis#Hyundai Motor Company#Hyundai Motor Company#South Korea"),
                new Brand("24#Mini#Sir Alec Issigonis#BMW Group#UK"),
                new Brand("25#Fiat#Giovanni Agnelli#Stellantis#Italy"),
                new Brand("26#Jeep#Willys-Overland#Stellantis#USA"),
                new Brand("27#Ram#Dodge Brothers Company#Stellantis#USA"),
                new Brand("28#GMC#General Motors Company#General Motors#USA"),
                new Brand("29#Cadillac#Henry Leland#General Motors#USA"),
                new Brand("30#Buick#David Dunbar Buick#General Motors#USA"),
                new Brand("31#Chrysler#Walter Chrysler#Stellantis#USA"),
                new Brand("32#Dodge#Horace and John Dodge#Stellantis#USA"),
                new Brand("33#Lincoln#Henry Leland#Ford Motor Company#USA"),
                new Brand("34#Alfa Romeo#Nicola Romeo#Stellantis#Italy"),
                new Brand("35#Ferrari#Enzo Ferrari#Ferrari N.V.#Italy"),
                new Brand("36#Lamborghini#Ferruccio Lamborghini#Volkswagen Group#Italy"),
                new Brand("37#Maserati#Alfieri Maserati#Stellantis#Italy"),
                new Brand("38#McLaren#Bruce McLaren#McLaren Group#UK"),
                new Brand("39#Bugatti#Ettore Bugatti#Volkswagen Group#France"),
                new Brand("40#Pagani#Horacio Pagani#Horacio Pagani S.p.A.#Italy"),
                new Brand("41#Koenigsegg#Christian von Koenigsegg#Koenigsegg Automotive AB#Sweden"),
                new Brand("42#Aston Martin#Lionel Martin and Robert Bamford#Aston Martin Lagonda Global Holdings#UK"),
                new Brand("43#Bentley#W. O. Bentley#Volkswagen Group#UK"),
                new Brand("44#Rolls-Royce#Charles Rolls and Henry Royce#BMW Group#UK"),
                new Brand("45#Lotus#Colin Chapman#Geely#UK"),
                new Brand("46#Lancia#Vincenzo Lancia#Stellantis#Italy"),

            });

            modelBuilder.Entity<Engine>().HasData(new Engine[] {
                new Engine("1#V6#3500#220#Gasoline"),
                new Engine("2#I4#2000#150#Gasoline"),
                new Engine("3#V8#5000#300#Diesel"),
                new Engine("4#Electric#0#350#Electric"),
                new Engine("5#Flat-6#3800#294#Gasoline"),
                new Engine("6#V12#6000#470#Gasoline"),
                new Engine("7#W16#8000#1103#Gasoline"),

            });
        }
    }
            
}
