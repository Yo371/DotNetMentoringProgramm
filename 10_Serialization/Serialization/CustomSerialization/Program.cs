using System.Runtime.Serialization.Formatters.Binary;
using CustomSerialization;

string filePath = @"..\..\..\CatData.dat";


var cat = new Cat("George", 13);

Console.WriteLine("Before serialization");
Console.WriteLine(cat);

var stream = File.Open(filePath, FileMode.Create);

var bf = new BinaryFormatter();

bf.Serialize(stream, cat);

cat = null;
stream.Close();

stream = File.Open(filePath, FileMode.Open);

bf = new BinaryFormatter();

cat = (Cat)bf.Deserialize(stream);

stream.Close();

Console.WriteLine("After deserialization");
Console.WriteLine(cat);
