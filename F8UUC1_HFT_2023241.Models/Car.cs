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
    public class Car
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

        public virtual Engine Engine { get; private set; }
        public virtual Brand Brand { get; private set; }

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

        public override bool Equals(object obj)
        {
            Car b = obj as Car;
            if (b == null) return false;
            return this.Year == b.Year 
                && this.BrandId == b.BrandId 
                && this.Model == b.Model 
                && this.EngineId == b.EngineId 
                && this.Year == b.Year;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.CarId, this.BrandId, this.Model, this.EngineId, this.Year);
        }
    }
}
