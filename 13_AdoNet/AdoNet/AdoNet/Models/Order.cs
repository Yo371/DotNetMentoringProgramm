using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Models
{
    public enum OrderStatus
    {
        NotStarted, Loading, InProgress, Arrived, Unloading, Cancelled, Done
    }

    public class Order
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public int ProductId { get; set; }

        public override string ToString()
        {
            return Id + " " + Status + " " + CreatedDate + " " + UpdatedTime;
        }
    }
}
