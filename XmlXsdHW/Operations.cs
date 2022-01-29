using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XmlXsdHW
{
    public class Operations
    {
        public static readonly XmlSerializer serializer = new XmlSerializer(typeof(Zoo));
        public static bool Validate(string xmlPath, string xsdPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            xmlDoc.Schemas.Add(null, xsdPath);
            xmlDoc.Validate(null);
            return true;
        }
        public static void XmlSerialization(Zoo zoo, string xmlPath)
        {
            try
            {
                using (var fs = new FileStream(xmlPath, FileMode.Create))
                {
                    serializer.Serialize(fs, zoo);
                }
                Console.WriteLine($"Object zoo with {zoo.animals.Count} animals added to XML file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Not able to serialize an object. Exception caught: {ex}");
            }     
        }
        public static Zoo XmlDeserialization(string xmlPath)
        {
            var zoo = new Zoo();
            try
            {
                using (var fs = new FileStream(xmlPath, FileMode.OpenOrCreate))
                {
                    zoo = (Zoo)serializer.Deserialize(fs);
                }
                Console.WriteLine($"Object zoo with {zoo.animals.Count} animals deserialized from XML file.");
                foreach (var animal in zoo.animals)
                {
                    Console.WriteLine($"Animals name: {animal.Name}");
                }
                return zoo;                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Not able to deserialize an object. Exception caught: {ex}");
                return null;
            }
        }
        public static Zoo CreateZoo(Zoo zoo)
        {
            bool wantToContinue = true;
            while (wantToContinue) 
            {
                var animal = CreateValidatedAnimal();
                zoo.animals.Add(animal);

                Console.WriteLine("Do you want to continue? Yes/No");
                var answer = Console.ReadLine();
                if (answer.ToLower() == "no")
                {
                    wantToContinue = false;
                }
                else
                {
                    continue;
                }
            }
            return zoo;
        }
        public static int CheckIfIntIsValid()
        {
            bool isValid = false;
            int number = 0;
            while (isValid == false)
            {
                var result = Console.ReadLine();
                if(result == "")
                {
                    Console.WriteLine("Please enter integer");
                    continue;
                }
                if (!int.TryParse(result, out number))
                {
                    Console.WriteLine("Please enter valid integer");
                    continue;
                }
                if (number < 0)
                {
                    Console.WriteLine("Please enter positive integer");
                    continue;
                }
                isValid = true;                
            }
            return number;
        }
        public static int CheckIfSpeedIsValid()
        {
            bool isValid = false;
            int number = 0;
            while (isValid == false)
            {
                var result = Console.ReadLine();
                if (result == "")
                {
                    Console.WriteLine("Please enter integer");
                    continue;
                }
                if (!int.TryParse(result, out number))
                {
                    Console.WriteLine("Please enter valid integer");
                    continue;
                }
                if (number < 0)
                {
                    Console.WriteLine("Please enter positive integer");
                    continue;
                }
                if (!(number >= 50 && number <= 100))
                {
                    Console.WriteLine("Please enter valid speed from 50 to 100");
                    continue;
                }
                isValid = true;
            }
            return number;
        }
        public static string CheckIfTextIsValid()
        {
            bool isValid = false;
            string result = "";
            while (isValid == false)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter text");
                    continue;
                }
                result = input;
                isValid = true;
            }
            return result;
        }
        public static string CheckIfDescriptionIsValid()
        {
            bool isValid = false;
            string result = "";
            while (isValid == false)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter text");
                    continue;
                }
                if(!(input.Length <= 50))
                {
                    Console.WriteLine("Maximum 50 characters. Try Again");
                    continue;
                }
                result = input;
                isValid = true;
            }
            return result;
        }       
        public static Animals CreateValidatedAnimal()
        {
            Console.WriteLine("Create an animal");

            Console.WriteLine("Please input id");
            var id = CheckIfIntIsValid();

            Console.WriteLine("Please input name");
            var name = CheckIfTextIsValid();

            Console.WriteLine("Please input description");
            var description = CheckIfDescriptionIsValid();

            Console.WriteLine("Please input age");
            var age = CheckIfIntIsValid();

            Console.WriteLine("Please input speed");
            var speed = CheckIfSpeedIsValid();

            Console.WriteLine("Please input type");
            var type = CheckIfTextIsValid();

            var animal = new Animals(id, name, description, age, speed, type);

            return animal;
        }
    }
}
