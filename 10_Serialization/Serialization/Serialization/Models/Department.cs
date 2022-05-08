using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Models
{
    [Serializable]
    public class Department //: ISerializable
    {
        public string DepartmentName { get; set; }

        public Department(string departmentName)
        {
            DepartmentName = departmentName;
        }

        public Department()
        {
        }

        /*public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }*/
    }
}
