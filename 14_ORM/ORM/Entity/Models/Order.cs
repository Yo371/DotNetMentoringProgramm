using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperProject.Models
{
    public enum OrderStatus
    {
        NotStarted, Loading, InProgress, Arrived, Unloading, Cancelled, Done
    }

    public class Order
    {
        public int Id { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Required]
        public int ProductId { get; set; }

        public override string ToString()
        {
            return Id + " " + Status + " " + CreatedDate + " " + UpdatedDate;
        }
    }
}
