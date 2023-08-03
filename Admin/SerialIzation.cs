using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Driver;
using System.Collections;
namespace SerializationHelper
{
    public static class SerializationHelper
    {
        public static void SerializeDriver(List<Driver.Driver> driver, string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Driver.Driver>));
                serializer.WriteObject(stream, driver);
            }
        }


        public static List<Driver.Driver> DeserializeDriver(string fileName)
        {

            if (new FileInfo(fileName).Length == 0)
            {
                Console.WriteLine("File is empty.");
                return new List<Driver.Driver>();
            }
            else
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Driver.Driver>));
                using (FileStream stream1 = File.OpenRead(fileName))
                {
                    return (List<Driver.Driver>)serializer.ReadObject(stream1);
                }
            }

            return new List<Driver.Driver>();
        }
    }
}


