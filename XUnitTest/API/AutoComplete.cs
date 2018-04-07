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
    public class AutoComplete
    {
        IAPIService APIClient { get; set; }
        IGoogleAPI GoogleAPI { get; set; }
        IGoogleService GoogleService { get; set; }
        DistantBasedAlgorithm Algorithm { get; set; }
        public AutoComplete()
        {
            APIClient = new APIService();
            GoogleAPI = new GoogleAPI();
            GoogleService = new GoogleService(GoogleAPI, APIClient);
            Algorithm = new DistantBasedAlgorithm(GoogleService);
        }
        [Fact]
        public void AutoCompleteAPI()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var userLocation = "Chi";
            var result = GoogleService.GetAutoComplete(userLocation);
            stopwatch.Stop();
            var timeTaken = stopwatch.Elapsed;
        }

    }
}
