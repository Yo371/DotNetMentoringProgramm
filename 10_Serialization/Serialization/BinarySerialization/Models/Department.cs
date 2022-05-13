using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Serialization.Models;

namespace BinarySerialization.Models
{
    [Serializable]
    public class Department : ICloneable
    {
        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }

        public Department(string departmentName, List<Employee> employees)
        {
            DepartmentName = departmentName;
            Employees = employees;
        }


        public Department()
        {
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Department - {DepartmentName}, with Employees");
            Employees.ForEach(e => stringBuilder.Append(" | ").Append(e.EmployeeName).Append(" | "));
            return stringBuilder.ToString();
        }

        public object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }
    }
}
