using System;

namespace location
{
    public class Location
    {
        float latitude, longitude;
        public float Mylatitude
        {
            set
            {
                latitude = value;
            }
            get
            {
                return latitude;
            }
        }
        public float Mylongitude
        {
            set
            {
                longitude = value;
            }
            get
            {
                return longitude;
            }
        }

        public void setLocation(float Latitude, float Longitude)
        {
            Mylatitude = Latitude;
            Mylongitude = Longitude;
        }
    }
}
