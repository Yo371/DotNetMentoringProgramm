using Serialization;
using Serialization.Models;

string jsonFilePath = @"..\..\..\Data\Department.json";

Department department = new Department()
{
    DepartmentName = "JsonDepartment",
    Employees = new List<Employee>()
    {
        new ("Petr"),
        new ("Sidr"),
        new ("Innokentiy"),

    }
};

Console.WriteLine("Before json serialization \n" + department);

var dataSerializer = new DataSerializer();

dataSerializer.JsonSerialize(department, jsonFilePath);

department = null;

department = dataSerializer.JsonDeserialize(typeof(Department), jsonFilePath) as Department;

Console.WriteLine("After json deserialization \n" + department);