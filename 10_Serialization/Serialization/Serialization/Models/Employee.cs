using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Models
{
    [Serializable]
    public class Employee : ISerializable
    {
        string EmployeeName { get; set; }

        public Employee(string employeeName)
        {
            EmployeeName = employeeName;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
