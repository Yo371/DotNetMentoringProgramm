// See https://aka.ms/new-console-template for more information
using Serialization;
using Serialization.Models;

Console.WriteLine("Hello, World!");

Department department = new Department() { DepartmentName = "Somename" };

string filePath = @"..\..\..\Data\Department.save";

string xmlFilePath = @"..\..\..\Data\Department.xml";

string jsonFilePath = @"..\..\..\Data\Department.json";

var dataSerializer = new DataSerializer();

dataSerializer.BinarySerialize(department, filePath);

department = null;

department = (Department)dataSerializer.BinaryDesirialize(filePath);

Console.WriteLine(department.DepartmentName);

dataSerializer.XmlSerialize(typeof(Department), department, xmlFilePath);

department = null;

department = dataSerializer.XmlDeserialize(typeof(Department), xmlFilePath) as Department;

Console.WriteLine(department.DepartmentName);

dataSerializer.JsonSerialize(department, jsonFilePath);

department = null;

department = dataSerializer.JsonDeserialize(typeof(Department), jsonFilePath) as Department;

Console.WriteLine(department.DepartmentName);
