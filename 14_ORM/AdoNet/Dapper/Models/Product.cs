using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        [Required]
        public int Length { get; set; }

        public string Name { get; set; }

        [MaxLength(30)]
        public string Description { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Description;
        }
    }
}
