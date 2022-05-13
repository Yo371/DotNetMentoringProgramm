using Serialization;
using Serialization.Models;
using XmlSerialization.Models;

string xmlFilePath = @"..\..\..\Data\Department.xml";

Department department = new Department()
{
    DepartmentName = "XmlDepartment",
    Employees = new List<Employee>()
    {
        new ("Petr"),
        new ("Sidr"),
        new ("Innokentiy"),

    }
};

Console.WriteLine("Before xml serialization \n" + department);

var dataSerializer = new DataSerializer();

dataSerializer.XmlSerialize(typeof(Department), department, xmlFilePath);

department = null;

department = dataSerializer.XmlDeserialize(typeof(Department), xmlFilePath) as Department;

Console.WriteLine("After xml deserialization \n" + department);