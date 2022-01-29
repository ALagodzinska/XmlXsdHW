using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlXsdHW
{
    [Serializable]
    public class Animals
    {
        public Animals(int id, string name, string description, int age, int speed, string type)
        {
            Id = id;
            Name = name;
            Description = description;
            Age = age;
            Speed = speed;
            Type = type;
        }

        public Animals() { }

        //Only positive integers +
        public int Id { get; set; }
        public string Name { get; set; }
        //Max lenght 50
        public string Description { get; set; }
        //Only positive integers +
        public int Age { get; set; }
        //Range 50 - 100
        public int Speed { get; set; }
        public string Type { get; set; }        
    }
}
