using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CashedItem<T>
    {
        public T Item { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
