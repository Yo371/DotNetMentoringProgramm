using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerialization
{
    [Serializable]
    public class Cat : ISerializable
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }

        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Cat()
        {
        }

        public Cat(SerializationInfo info, StreamingContext context)
        {
            Name = (string) info.GetValue("Name", typeof(string));
            Age = (int) info.GetValue("Age", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Age", Age);
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
