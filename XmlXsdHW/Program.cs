using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XmlXsdHW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string xmlPath = @"C:\Users\anast\Desktop\XML\XmlAnimalsHW.xml";
            string xsdPath = @"C:\Users\anast\Desktop\XML\XsdAnimalsHW.xsd";

            bool isExit = false;
            while(isExit == false)
            {
                Console.WriteLine(@"Choose number:
                                1.Create New Zoo and serialize
                                2.Deserialize and add new animals
                                3.Validate
                                4.Exit
                                ");
                var input = Console.ReadLine();
                if ( input == "1")
                {
                    var zoo = new Zoo();
                    zoo = Operations.CreateZoo(zoo);
                    Console.WriteLine("Zoo is created");
                    Console.ReadLine();
                    Console.WriteLine("Serialization started");
                    Operations.XmlSerialization(zoo, xmlPath);
                    continue;
                }
                if (input == "2")
                {
                    var zoo = Operations.XmlDeserialization(xmlPath);
                    var UpdatedZoo = Operations.CreateZoo(zoo);
                    Console.WriteLine("Animals are added to the zoo");
                    Console.ReadLine();
                    Console.WriteLine("Serialization started");
                    Operations.XmlSerialization(UpdatedZoo, xmlPath);
                    continue;
                }
                if (input == "3")
                {
                    try
                    {
                        if (Operations.Validate(xmlPath, xsdPath))
                        {
                            Console.WriteLine("Valid");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Not valid schema. Exception caught: {ex}");
                    }

                    Console.ReadLine();
                    continue;
                }
                else
                {
                    isExit = true;
                }
            }
            Console.ReadLine();            
        }        
    }
}
