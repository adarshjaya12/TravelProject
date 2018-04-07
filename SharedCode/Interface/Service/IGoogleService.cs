using APIClient.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode.Interface.Service
{
    public interface IGoogleService
    {
        DistanceMatrix GetDistance(string origin, string destination, string unit);
        AutoComplete GetAutoComplete(string text);
        GeoCoding GetLatAndLong(string address);
        GeoCoding GetGeoLocation(double lat, double longi);
    }
}
