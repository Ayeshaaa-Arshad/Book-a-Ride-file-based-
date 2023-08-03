using System;
using Driver;
using Admin;

namespace hw_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin.Admin admin = new Admin.Admin();
            admin.ClearFile();
            Console.WriteLine("------------------------------------------------------\n\t\tWelcome to MyRide\n------------------------------------------------------");
            do
            {
                Driver.Driver d = new Driver.Driver();
                Console.WriteLine("1. Book a ride\n2. Enter as driver\n3. Enter as admin\n\nPress 1 to 3 to select an option");
                int choice = System.Convert.ToInt32(Console.ReadLine());
                while (choice > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nWrong Input…!\n\nEnter 1 or 3 only:  ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    choice = System.Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                }
                if (choice == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t\tBOOK A RIDE\n");
                    Console.ResetColor();

                    Console.Write("Enter Name:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();
                    while (name == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nWrong Input…!\n\nEnter name again:  ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        name = Console.ReadLine();
                        Console.ResetColor();
                    }


                    Console.Write("Enter Phone no:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string phone = Console.ReadLine();
                    Console.ResetColor();
                    int res;
                    bool isnumeric = int.TryParse(phone, out res);

                    while (phone == "" || !isnumeric)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nWrong Input…!\n\nEnter phone no again:  ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        phone = Console.ReadLine();
                        Console.ResetColor();
                        isnumeric = int.TryParse(phone, out res);
                    }

                    Console.Write("Enter Start Location comma seperated :");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string loc = Console.ReadLine();
                    string[] location = loc.Split(',');

                    float start_loc_1 = float.Parse(location[0]);
                    float start_loc_2 = float.Parse(location[1]);
                    Console.ResetColor();

                    Console.Write("Enter End Location comma seperated :");
                    Console.ForegroundColor = ConsoleColor.Green;
                    loc = Console.ReadLine();
                    location = loc.Split(',');
                    float end_loc_1 = float.Parse(location[0]);
                    float end_loc_2 = float.Parse(location[1]);
                    Console.ResetColor();

                    Console.Write("Enter Ride Type:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    dynamic type = Console.ReadLine();
                    Console.ResetColor();
                    while (type == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nWrong Input…!\n\nEnter type again:  ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        type = Console.ReadLine();
                        Console.ResetColor();
                    }

                    Console.WriteLine("\n---------Thank You----------\n");

                    Ride.Ride r = new Ride.Ride();
                    Passenger.Passenger p = new Passenger.Passenger(name, phone);
                    r.assignPassenger(p);

                    location.Location Start = new location.Location();
                    Start.setLocation(start_loc_1, start_loc_2);

                    location.Location End = new location.Location();
                    End.setLocation(end_loc_1, end_loc_2);

                    r.getLocations(Start, End);

                    bool flag = r.assignDriver(admin, Start, p, r, type);
                    if (flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Price for this ride is: " + r.calculatePrice(type));
                        Console.ResetColor();

                        Console.Write("\nEnter ‘Y’ if you want to Book the ride, enter ‘N’ if you want to cancel operation:");
                        Console.ForegroundColor = ConsoleColor.Green;
                        var ch = Console.ReadLine();
                        Console.ResetColor();

                        if (ch != "N" && ch != "Y")
                        {
                            while (ch != "N" && ch != "Y")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\nWrong Input…!\n\nEnter Y or N only:  ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                ch = Console.ReadLine();
                                Console.ResetColor();
                            }
                        }
                        if (ch == "Y")
                        {
                            Console.Write("\nHappy Travel…!\n\nGive rating out of 5:  ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string rating = Console.ReadLine();
                            Console.ResetColor();
                            int result;
                            isnumeric = int.TryParse(rating, out result);

                            while (rating == "" || !isnumeric || result > 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\nWrong Input…!\n\nEnter Rating again out of 5:  ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                rating = Console.ReadLine();
                                Console.ResetColor();
                                isnumeric = int.TryParse(rating, out result);
                            }
                            int Rating = result;

                            r.giveRating(Rating);
                            admin.updateFile();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You can't book any ride as we don't have any driver available as per your need ;)\n");
                        Console.ResetColor();
                    }
                }
                else if (choice == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\t\tENTER AS DRIVER\n");
                    Console.ResetColor();

                    Console.WriteLine("Enter ID");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string Id = Console.ReadLine();
                    Console.ResetColor();
                    int res;
                    bool isnumeric = int.TryParse(Id, out res);

                    while (Id == "" || !isnumeric)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nWrong Input…!\n\nEnter phone no again:  ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Id = Console.ReadLine();
                        Console.ResetColor();
                        isnumeric = int.TryParse(Id, out res);
                    }
                    int id = res;

                    Console.WriteLine("Enter Name");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();
                    while (name == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nWrong Input…!\n\nEnter name again:  ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        name = Console.ReadLine();
                        Console.ResetColor();
                    }

                    bool flag = false;
                    int driver_no = -1;
                    for (int i = 0; i < admin.listOfDrivers.Count; i++)
                    {
                        d = (Driver.Driver)admin.listOfDrivers[i];
                        if (id == d.MyID && name == d.Myname)
                        {
                            flag = true;
                            driver_no = i;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("Hello " + name + "!\nEnter our current latitude");
                        Console.ForegroundColor = ConsoleColor.Green;
                        float a = float.Parse(Console.ReadLine());
                        Console.ResetColor();

                        Console.WriteLine("Enter our current longitude");
                        Console.ForegroundColor = ConsoleColor.Green;
                        float b = float.Parse(Console.ReadLine());
                        Console.ResetColor();

                        Console.WriteLine("1. Change availabilty\n2. Update Location\n3. Exit as driver\n\nPress 1 to 3 to select an option");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int ch = System.Convert.ToInt32(Console.ReadLine());
                        while (ch > 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nWrong Input…!\n\nEnter 1 to 3 only:  ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            ch = System.Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();
                        }

                        Console.ResetColor();
                        if (ch == 1)
                        {
                            Console.WriteLine("You may change your availabilty true/false !!!\n");
                            string status = Console.ReadLine();
                            while (status != "true" && status != "false")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\nWrong Input…!\n\nEnter true or false only:  ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                status = Console.ReadLine();
                                Console.ResetColor();
                            }
                            d = (Driver.Driver)admin.listOfDrivers[driver_no];
                            bool Status = System.Convert.ToBoolean(status);
                            d.updateAvailability(Status);
                            Console.ResetColor();
                            admin.updateFile();
                        }
                        else if (ch == 2)
                        {
                            d = (Driver.Driver)admin.listOfDrivers[driver_no];
                            d.updateLocation();
                            admin.updateFile();
                        }
                        else if (ch == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n---____---_____---_____---____----____----____---\n");
                            Console.ResetColor();
                            continue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter Again Wrong Input !!!\n");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You are not registered  !!!\n");
                        Console.ResetColor();
                    }
                }
                else if (choice == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\t\tENTER AS ADMIN\n");
                    Console.ResetColor();

                    Console.WriteLine("1. Add Driver\n2. Remove Driver\n3. Update Driver\n4. Search Driver\n5. Exit as Admin\n\nPress 1 to 5 to select an option");

                    int Choice = System.Convert.ToInt32(Console.ReadLine());
                    while (Choice > 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nWrong Input…!\n\nEnter 1 to 3 only:  ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Choice = System.Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                    }
                    if (Choice == 1)
                    {

                        bool flag = true;
                        int res = 0;
                        bool isnumeric = false;
                        while (flag)
                        {
                            Console.WriteLine("Enter ID");
                            Console.ForegroundColor = ConsoleColor.Green;
                            var Id = Console.ReadLine();
                            Console.ResetColor();
                            isnumeric = int.TryParse(Id, out res);

                            while (Id == "" || !isnumeric)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\nWrong Input…!\n\nEnter Id again:  ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Id = Console.ReadLine();
                                Console.ResetColor();
                                isnumeric = int.TryParse(Id, out res);
                            }
                            if (admin.checkID(res) == -1)
                                flag = false;
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Wrong Input…!  Enter again!!!\n");
                                Console.ResetColor();
                            }
                        }
                        int id = res;

                        Console.WriteLine("Enter Name");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string name = Console.ReadLine();
                        Console.ResetColor();
                        while (name == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nWrong Input…!\n\nEnter name again:  ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            name = Console.ReadLine();
                            Console.ResetColor();
                        }

                        Console.WriteLine("Enter Age");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string Age = Console.ReadLine();
                        Console.ResetColor();

                        isnumeric = int.TryParse(Age, out res);

                        while (Age == "" || !isnumeric)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nWrong Input…!\n\nEnter Age again:  ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Age = Console.ReadLine();
                            Console.ResetColor();
                            isnumeric = int.TryParse(Age, out res);
                        }
                        int age = res;

                        Console.WriteLine("Enter Gender");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string gender = Console.ReadLine();
                        Console.ResetColor();

                        Console.WriteLine("Enter Address");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string address = Console.ReadLine();
                        Console.ResetColor();

                        Console.WriteLine("Enter Vehicle Type car/rickshaw/bike");
                        Console.ForegroundColor = ConsoleColor.Green;
                        dynamic type = Console.ReadLine();
                        Console.ResetColor();
                        while (type == "" || (type != "car" && type != "rickshaw" && type != "bike" && type != "Car" && type != "Rickshaw" && type != "Bike"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nWrong Input…!\n\nEnter type again car/rickshaw/bike:  ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            type = Console.ReadLine();
                            Console.ResetColor();
                        }

                        Console.WriteLine("Enter Vehicle Model");
                        Console.ForegroundColor = ConsoleColor.Green;
                        dynamic model = Console.ReadLine();
                        Console.ResetColor();

                        Console.WriteLine("Enter Vehicle License Plate");
                        Console.ForegroundColor = ConsoleColor.Green;
                        dynamic license = Console.ReadLine();
                        Console.ResetColor();

                        Console.WriteLine("Enter the value for latitude");
                        Console.ForegroundColor = ConsoleColor.Green;
                        float latitude = float.Parse(Console.ReadLine());
                        Console.ResetColor();

                        Console.WriteLine("Enter the value for longitude");
                        Console.ForegroundColor = ConsoleColor.Green;
                        float longitude = float.Parse(Console.ReadLine());
                        Console.ResetColor();

                        Vehicle.Vehicle v = new Vehicle.Vehicle(type, model, license);
                        Driver.Driver driver = new Driver.Driver(name, age, gender, address, v, id, latitude, longitude);

                        admin.addDriver(driver);
                    }
                    else if (Choice == 2)
                    {
                        Console.WriteLine("Enter ID of the driver you want to remove\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string Id = Console.ReadLine();
                        Console.ResetColor();
                        int res;
                        bool isnumeric = int.TryParse(Id, out res);

                        while (Id == "" || !isnumeric)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Wrong Input…!\n\nEnter ID again:  ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Id = Console.ReadLine();
                            Console.ResetColor();
                            isnumeric = int.TryParse(Id, out res);
                        }
                        int id = res;

                        admin.removeDriver(id);
                    }
                    else if (Choice == 3)
                    {
                        Console.WriteLine("Enter ID of the driver you want to update\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string Id = Console.ReadLine();
                        Console.ResetColor();
                        int res;
                        bool isnumeric = int.TryParse(Id, out res);

                        while (Id == "" || !isnumeric)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Wrong Input…!\n\nEnter ID again:  ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Id = Console.ReadLine();
                            Console.ResetColor();
                            isnumeric = int.TryParse(Id, out res);
                        }
                        int id = res;

                        var driver_index = admin.searchDriver(id);
                        if (driver_index == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Driver Not found !!!\n");
                            Console.ResetColor();

                        }
                        else if (driver_index >= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-----------Driver with this ID exists-------------");
                            Console.ResetColor();

                            Console.WriteLine("Enter Name");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string name = Console.ReadLine();
                            Console.ResetColor();

                            Console.WriteLine("Enter Age");
                            Console.ForegroundColor = ConsoleColor.Green;
                            int age = System.Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();

                            Console.WriteLine("Enter Gender");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string gender = Console.ReadLine();
                            Console.ResetColor();

                            Console.WriteLine("Enter Address");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string address = Console.ReadLine();
                            Console.ResetColor();

                            Console.WriteLine("Enter Vehicle Type");
                            Console.ForegroundColor = ConsoleColor.Green;
                            dynamic type = Console.ReadLine();
                            Console.ResetColor();

                            Console.WriteLine("Enter Vehicle Model");
                            Console.ForegroundColor = ConsoleColor.Green;
                            dynamic model = Console.ReadLine();
                            Console.ResetColor();

                            Console.WriteLine("Enter Vehicle License Plate");
                            Console.ForegroundColor = ConsoleColor.Green;
                            dynamic license = Console.ReadLine();
                            Console.ResetColor();

                            Vehicle.Vehicle v = new Vehicle.Vehicle(type, model, license);
                            Driver.Driver driver = new Driver.Driver(name, age, gender, address, v, id);

                            admin.updateDriver(driver_index, driver);
                        }
                    }
                    else if (Choice == 4)
                    {
                        Console.WriteLine("Enter ID of the driver you want to search\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string Id = Console.ReadLine();
                        Console.ResetColor();
                        int res;
                        bool isnumeric = int.TryParse(Id, out res);

                        while (Id == "" || !isnumeric)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nWrong Input…!\n\nEnter ID again:  ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Id = Console.ReadLine();
                            Console.ResetColor();
                            isnumeric = int.TryParse(Id, out res);
                        }
                        int id = res;

                        var driver_indx = admin.searchDriver(id);
                        if (driver_indx >= 0)
                        {
                            d = (Driver.Driver)admin.listOfDrivers[driver_indx];

                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------\n\n");
                            Console.WriteLine("Name\t\t\tAge\t\t\tGender\t\t\tV.Type\t\t\tV.Model\t\t\tV.License\n\n");
                            Console.WriteLine($"{d.Myname}\t\t\t{d.MyAge}\t\t\t{d.MyGender}\t\t\t{d.Vehicle.MyType}\t\t\t{d.Vehicle.MyModel}\t\t\t{d.Vehicle.MyLicense}\n\n");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------\n\n");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Driver Not found !!!\n");
                            Console.ResetColor();
                        }
                    }
                    else if (Choice == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n---____---_____---_____---____----____----____---\n");
                        Console.ResetColor();
                        continue;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n---____---_____---_____---____----____----____---\n");
                Console.ResetColor();
            } while (true);

        }
    }
}
