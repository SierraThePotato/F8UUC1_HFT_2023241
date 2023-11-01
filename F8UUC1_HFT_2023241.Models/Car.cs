using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;

namespace F8UUC1_HFT_2023241.Models
{
    internal class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        [StringLength(240)]
        public string Model { get; set; }

        [Required]
        public int EngineId { get; set; }

        [Required]
        [Range(1800, 3000)]
        public int Year { get; set; }

        public Car()
        {

        }
        public Car(string line)
        {
            string[] split = line.Split('#');
            CarId = int.Parse(split[0]);
            BrandId = int.Parse(split[1]);
            Model = split[2];
            EngineId = int.Parse(split[3]);
            Year = int.Parse(split[4]);
        }
    }
}
