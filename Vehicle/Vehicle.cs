//using System;

//namespace Vehicle
//{
//    public class Vehicle
//    {
//        public string Type, model, license_plate;
//        public Vehicle(string t,string m,string l)
//        {
//            MyType = t; MyModel = m; MyLicense = l;
//        }
//        public string MyType
//        {
//            get 
//            {   
//                return Type;                    
//            }
//            set
//            {
//                Type = value;
//            }
//        }
//        public string MyModel
//        {
//            get
//            {
//                return model;
//            }
//            set
//            {
//                model = value;
//            }
//        }
//        public string MyLicense
//        {
//            get
//            {
//                return license_plate;
//            }
//            set
//            {
//                license_plate = value;
//            }
//        }
//    }
//}
using System;
using System.Runtime.Serialization;

namespace Vehicle
{
    [DataContract]
    public class Vehicle
    {
        public string Type,Model,license_plate;
        [DataMember]
        public string MyType
        {
            get
            {
                return Type;
            }
            set
            {
                Type = value;
            }
        }
        [DataMember]
        public string MyModel
        {
            get
            {
                return Model;
            }
            set
            {
                Model = value;
            }
        }
        [DataMember]
        public string MyLicense
        {
            get
            {
                return license_plate;
            }
            set
            {
                license_plate = value;
            }
        }

        public Vehicle(string type, string model, string licensePlate)
        {
            Type = type;
            Model = model;
            license_plate = licensePlate;
        }
        
       
      
    }
}
