using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8UUC1_HFT_2023241.Models
{
    internal class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        [Required]
        [StringLength(240)]
        public string Inventor { get; set; }

        [Required]
        [StringLength(240)]
        public string Owner { get; set; }

        [Required]
        [StringLength(240)]
        public string Country { get; set; }

        public Brand()
        {

        }
        public Brand(string line)
        {
            string[] split = line.Split('#');
            BrandId = int.Parse(split[0]);
            Inventor = split[1];
            Owner = split[2];
            Country = split[3];
        }
    }
}
