// See https://aka.ms/new-console-template for more information
using Serialization;
using Serialization.Models;

Console.WriteLine("Hello, World!");

Department department = new Department() { DepartmentName = "Somename",
    Employees = new List<Employee>()
{
    new ("Petr"),
    new ("Sidr"),
    new ("Innokentiy"),

} };

Console.WriteLine(department);

string filePath = @"..\..\..\Data\Department.save";

string xmlFilePath = @"..\..\..\Data\Department.xml";

string jsonFilePath = @"..\..\..\Data\Department.json";

var dataSerializer = new DataSerializer();

dataSerializer.BinarySerialize(department, filePath);

department = null;

department = (Department)dataSerializer.BinaryDesirialize(filePath);

Console.WriteLine(department);

dataSerializer.XmlSerialize(typeof(Department), department, xmlFilePath);

department = null;

department = dataSerializer.XmlDeserialize(typeof(Department), xmlFilePath) as Department;

Console.WriteLine(department);

dataSerializer.JsonSerialize(department, jsonFilePath);

department = null;

department = dataSerializer.JsonDeserialize(typeof(Department), jsonFilePath) as Department;

Console.WriteLine(department);

var department2 = department.Clone() as Department;

department2.Employees.Add(new Employee("department2Employee"));
department2.DepartmentName = "Department2";

Console.WriteLine("----------");
Console.WriteLine(department);
Console.WriteLine(department2);
