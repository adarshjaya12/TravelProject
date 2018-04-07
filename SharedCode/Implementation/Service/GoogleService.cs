using APIClient.DTO;
using APIClient.Interface;
using SharedCode.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedCode.Implementation.Service
{
    public class GoogleService : IGoogleService
    {
        IGoogleAPI  GoogleAPI { get; set; }
        IAPIService APIService { get; set; }

        public GoogleService(IGoogleAPI googleAPI, IAPIService aPIService)
        {
            GoogleAPI = googleAPI;
            APIService = aPIService;
        }

        public AutoComplete GetAutoComplete(string text)
        {
            var autoUrl = string.Format(GoogleAPI.AutoComplete, text);
            var result = APIService.GetItemAsync<AutoComplete>(autoUrl).Result;
            return result;
        }

        public DistanceMatrix GetDistance(string origin, string destination,string unit="Imperial")
        {
            var distanceUrl = string.Format(GoogleAPI.DistanceMatrix, unit,origin, destination);
            var result = APIService.GetItemAsync<DistanceMatrix>(distanceUrl).Result;
            return result;
        }

        public GeoCoding GetLatAndLong(string address)
        {
            var url = string.Format(GoogleAPI.GeoCoding,address);
            return APIService.GetItemAsync<GeoCoding>(url).Result;
        }
        
        public GeoCoding GetGeoLocation(double lat, double longi)
        {
            var url = string.Format(GoogleAPI.ReverseGeoCoding, lat,longi);
            var result =  APIService.GetItemAsync<GeoCoding>(url).Result;
            return result;
        }


    }
}
