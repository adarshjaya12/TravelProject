using APIClient.DTO;
using APIClient.Interface;
using SharedCode.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedCode.Implementation.Service
{
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class DistantBasedAlgorithm
    {
        private const double EARTH_RADIUS_NM = 3437.67001335;
        IGoogleService GoogleService { get; set; }
        public DistantBasedAlgorithm(IGoogleService googleAPI)
        {
            GoogleService = googleAPI;
        }

        public List<Coordinates>  PlotCordinates(double lat, double lon, double radius)
        {
            var Coordinates = new List<Coordinates>();
            lat = ConvertToRadians(lat);
            lon = ConvertToRadians(lon);
            double d = radius ;
            for (int x = 0; x <= 360; x++)
            {
                double brng = ConvertToRadians(x);
                var latRadians = (Math.Asin(Math.Sin(lat) * Math.Cos(d) + Math.Cos(lat) * Math.Sin(d) * Math.Cos(brng))) * 57.2958;
                var lngRadians = (lon + Math.Atan2(Math.Sin(brng) * Math.Sin(d) * Math.Cos(lat), Math.Cos(d) - Math.Sin(lat) * Math.Sin(latRadians)))*57.2958;

                Coordinates.Add(new Coordinates() { Latitude = latRadians, Longitude = lngRadians });
            }
            return Coordinates;
        }

        public Dictionary<string,string> GetStatesFromCordinates(List<Coordinates> coordinates)
        {
            var states = new Dictionary<string, string>();
            foreach(var co in coordinates)
            {
                var geoLocation = GoogleService.GetGeoLocation(co.Latitude, co.Longitude);
                var state= geoLocation.results.FirstOrDefault().address_components.FirstOrDefault(ac => ac.types.Any(ty => ty == "administrative_area_level_1"));
                if(state != null)
                {
                    var longstatename = state.long_name;
                    var shortstatename = state.short_name;
                    if(!states.ContainsKey(shortstatename))
                        states.Add(shortstatename, longstatename);
                }
            }
            return states;
        }

        public List<Coordinates> CircumferenceVertexes(double lat, double lon, double radius)
        {
            var r = radius / EARTH_RADIUS_NM;
            var Coordinates = new List<Coordinates>();
            for (int i = 0; i <= 360;  )
            {
                var radi = ConvertToRadians(i);
                Coordinates coordinates = new Coordinates();
                var latitude = r * Math.Cos(radi) + lat;
                var longitude = r * Math.Cos(radi) + lon;
                coordinates.Latitude = Math.Round(latitude, 5);
                coordinates.Longitude = Math.Round(longitude, 5);
                Coordinates.Add(coordinates);
                i += 2;
            }
            return Coordinates;
        }

        public List<Coordinates> PointOnCircle(double lat, double longi, float radius)
        {
            var r = radius / EARTH_RADIUS_NM;
            var list = new List<Coordinates>();
            for (int i = 0; i <= 360;)
            {
                Coordinates coordinates = new Coordinates();
                // Convert from degrees to radians via multiplication by PI/180        
                double x = (r * Math.Cos(i * Math.PI / 180F)) + lat;
                double y = (r * Math.Sin(i * Math.PI / 180F)) + longi;
                coordinates.Latitude = x;
                coordinates.Longitude = y;
                i += 5;
                list.Add(coordinates);
            }
            return list;
        }

        public double ConvertToRadians(double angle)
        {
            return (angle * Math.PI) / 180;
        }

        private const double latitudeDistance = 68.666; 

        private double GetLongitudeDistance(double latitude)
        {
            return (111.321*Math.Cos((Math.PI / 180) * latitude))*0.621;
        }
    }
}
