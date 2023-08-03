using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Driver;
namespace DriverManager
{
    class DriverManager
    {
        string filename = "driver.txt";
        public void saveDriver(List<Driver.Driver> drivers)
        {
            SerializationHelper.SerializationHelper.SerializeDriver(drivers, filename);
        }
        public List<Driver.Driver> readDriver()
        {
            dynamic deserializedUsers = SerializationHelper.SerializationHelper.DeserializeDriver(filename);
            return deserializedUsers;
        }
        public int searchDriverByID(int ID)
        {
            List<Driver.Driver> deserializedUsers = SerializationHelper.SerializationHelper.DeserializeDriver(filename);
            if (deserializedUsers.Count == 0)
                return -1;
            int i = 0;
            foreach (Driver.Driver d in deserializedUsers)
            {
                if (d.MyID == ID)
                    return i;
                i++;
            }
            return -1;
        }

    }
}
