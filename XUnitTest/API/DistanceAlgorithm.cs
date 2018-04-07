using System;
using Xunit;
using APIClient.Interface;
using APIClient.Implementation;
using SharedCode.Interface.Service;
using SharedCode.Implementation.Service;
using System.Linq;
using System.Diagnostics;

namespace UnitTest.API
{
    public class DistanceAlgorithm
    {
        IAPIService APIClient { get; set; }
        IGoogleAPI GoogleAPI { get; set; }
        IGoogleService GoogleService { get; set; }
        DistantBasedAlgorithm Algorithm { get; set; }
        public DistanceAlgorithm()
        {
            APIClient = new APIService();
            GoogleAPI = new GoogleAPI();
            GoogleService = new GoogleService(GoogleAPI, APIClient);
            Algorithm = new DistantBasedAlgorithm(GoogleService);
        }


        public void Get()
        {
            var userLocation = "Chicago,IL";
            var userGeoLocation = GoogleService.GetLatAndLong(userLocation);
            var userLat = userGeoLocation.results.FirstOrDefault().geometry.location.lat;
            var userLong = userGeoLocation.results.FirstOrDefault().geometry.location.lng ;
            var coordinates = Algorithm.PlotCordinates(userLat, userLong, 100);
            var states = Algorithm.GetStatesFromCordinates(coordinates);
            Assert.NotEmpty(states);
        }

        [Fact]
        public void GetVertexFromCircumference()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var userLocation = "Chicago,IL";
            var userGeoLocation = GoogleService.GetLatAndLong(userLocation);
            var userLat = userGeoLocation.results.FirstOrDefault().geometry.location.lat;
            var userLong = userGeoLocation.results.FirstOrDefault().geometry.location.lng;
            var coordinates = Algorithm.CircumferenceVertexes(userLat, userLong, 500);
            var states = Algorithm.GetStatesFromCordinates(coordinates);
            var cordinatesInCircle = Algorithm.PointOnCircle(userLat, userLong, 500);
            var foundStates = Algorithm.GetStatesFromCordinates(cordinatesInCircle);
            stopwatch.Stop();
            var timeTaken = stopwatch.Elapsed;
        }

    }
}
