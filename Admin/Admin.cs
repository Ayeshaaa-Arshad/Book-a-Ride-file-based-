using System;
using System.Collections;
using System.Collections.Generic;
using Driver;
using Vehicle;
using System.IO;
using DriverManager;

namespace Admin
{
    public class Admin
    {
        public List<Driver.Driver> listOfDrivers = new List<Driver.Driver>();
        public void addDriver(Driver.Driver driver)
        {
            listOfDrivers.Add(driver);
            DriverManager.DriverManager dm = new DriverManager.DriverManager();
            dm.saveDriver(listOfDrivers);
        }
        public void updateFile()
        {
            DriverManager.DriverManager dm = new DriverManager.DriverManager();
            dm.saveDriver(listOfDrivers);
        }
        public void removeDriver(int ID)
        {
            Driver.Driver d = new Driver.Driver();
            for (int i = 0; i < listOfDrivers.Count; i++)
            {
                d = (Driver.Driver)listOfDrivers[i];
                if (ID == d.MyID)
                {
                    listOfDrivers.RemoveAt(i);
                    break;
                }
            }
            DriverManager.DriverManager dm = new DriverManager.DriverManager();
            dm.saveDriver(listOfDrivers);

        }
        public int searchDriver(int id)
        {
            DriverManager.DriverManager dm = new DriverManager.DriverManager();
            return dm.searchDriverByID(id);
        }
        public void updateDriver(int Index, Driver.Driver d)
        {
            Driver.Driver driver = (Driver.Driver)listOfDrivers[Index];
            if (d.Myname != "")
                driver.Myname = d.Myname;
            if (d.MyAddress != "")
                driver.MyAddress = d.MyAddress;
            if (d.MyGender != "")
                driver.MyGender = d.MyGender;
            if (d.MyAddress != "")
                driver.MyAddress = d.MyAddress;
            if (d.Vehicle.Type != "")
                driver.Vehicle.MyType = d.Vehicle.MyType;
            if (d.Vehicle.MyModel != "")
                driver.Vehicle.MyModel = d.Vehicle.MyModel;
            if (d.Vehicle.MyLicense != "")
                driver.Vehicle.MyLicense = d.Vehicle.MyLicense;
            DriverManager.DriverManager dm = new DriverManager.DriverManager();
            listOfDrivers.RemoveAt(Index);
            addDriver(driver);
            dm.saveDriver(listOfDrivers);
        }
        public int checkID(int ID)
        {
            DriverManager.DriverManager dm = new DriverManager.DriverManager();
            if (listOfDrivers.Count > 0)
                return dm.searchDriverByID(ID);
            return -1;
        }
        public void ClearFile()
        {
            StreamWriter writer = new StreamWriter("driver.txt");
            writer.Write("");
            writer.Close();
            
        }
    }

}
