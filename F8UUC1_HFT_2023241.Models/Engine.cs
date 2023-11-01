using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8UUC1_HFT_2023241.Models
{
    internal class Engine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EngineId { get; set; }

        [Required]
        [StringLength(240)]
        public string Type { get; set; }

        [Required]
        [Range(0, 100000)]
        public int Displacement { get; set; }

        [Required]
        [StringLength(240)]
        public string Fuel { get; set; }

        public Engine()
        {

        }
        public Engine(string line)
        {
            string[] split = line.Split('#');
            EngineId = int.Parse(split[0]);
            Type = split[1];
            Displacement = int.Parse(split[2]);
            Fuel = split[3];
        }
    }
}
