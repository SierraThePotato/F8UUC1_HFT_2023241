using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8UUC1_HFT_2023241.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        [Required]
        [StringLength(240)]
        public string Inventor { get; set; }

        [Required]
        [StringLength(240)]
        public string Owner { get; set; }

        [Required]
        [StringLength(240)]
        public string Country { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public Brand()
        {

        }
        public Brand(string line)
        {
            string[] split = line.Split('#');
            BrandId = int.Parse(split[0]);
            Name = split[1];
            Inventor = split[2];
            Owner = split[3];
            Country = split[4];
        }
    }
}
