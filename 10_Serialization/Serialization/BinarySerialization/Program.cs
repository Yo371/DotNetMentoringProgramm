using Serialization;
using Serialization.Models;

string filePath = @"..\..\..\Data\Department.data";

Department department = new Department()
{
    DepartmentName = "BinaryDepartment",
    Employees = new List<Employee>()
    {
        new ("Petr"),
        new ("Sidr"),
        new ("Innokentiy"),
    }
};

Console.WriteLine("Before bin serialization \n" + department);

var dataSerializer = new DataSerializer();

dataSerializer.BinarySerialize(department, filePath);

department = null;

department = (Department)dataSerializer.BinaryDesirialize(filePath);

Console.WriteLine("After bin deserialization \n" + department);

//deep clone
var department2 = department.Clone() as Department;

department2.Employees.Add(new Employee("department2Employee"));
department2.DepartmentName = "Department2";

Console.WriteLine("----------");
Console.WriteLine(department);
Console.WriteLine(department2);