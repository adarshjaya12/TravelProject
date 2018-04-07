using System;
using Xunit;
using APIClient.Interface;
using APIClient.Implementation;
using SharedCode.Interface.Service;
using SharedCode.Implementation.Service;

namespace UnitTest.API
{
    public class DistanceMatrix
    {
        IAPIService APIClient { get; set; }
        IGoogleAPI GoogleAPI { get; set; }
        IGoogleService GoogleService { get; set; }
        public DistanceMatrix()
        {
            APIClient = new APIService();
            GoogleAPI = new GoogleAPI();
            GoogleService = new GoogleService(GoogleAPI, APIClient);
        }


        [Fact]
        public void GetDistance()
        {
            var origin = "NewYork,NY";
            var destination = "Chicago,IL";
            var result = GoogleService.GetDistance(origin, destination, "");
            Assert.NotNull(result);
        }
    }
}
