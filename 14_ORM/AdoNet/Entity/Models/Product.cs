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

        [Required] public int Weight { get; set; }

        [Required] public int Height { get; set; }

        [Required] public int Width { get; set; }

        [Required] public int Length { get; set; }

        [Required] [MaxLength(40)] public string Name { get; set; }

        [Required] [MaxLength(100)] public string Description { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Description;
        }
    }
}