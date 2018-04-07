using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APIClient.DTO;
using Microsoft.AspNetCore.Mvc;
using SharedCode.Interface.Service;
using Travel.Models;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        IGoogleService GoogleService { get; set; }
        public HomeController(IGoogleService googleService)
        {
            GoogleService = googleService;
        }
        [HttpGet]
        public JsonResult GetAutoFillCities(string input)
        {
            var AutoCompleteresult= GoogleService.GetAutoComplete(input);
            List<AutoCompleteJson> jsonList = new List<AutoCompleteJson>();
            foreach (var item in AutoCompleteresult.predictions)
            {
                AutoCompleteJson result = new AutoCompleteJson();
                result.description = item.description;
                result.place_id = item.place_id;
                jsonList.Add(result);
            }
            return new JsonResult(jsonList);
        }
        [HttpGet]
        public JsonResult GetGeoLocation(double latitude, double longitude)
        {
            var geoCoding = GoogleService.GetGeoLocation(latitude, longitude);
            var city = geoCoding.results.FirstOrDefault().address_components.FirstOrDefault(ac => ac.types.Any(ty => ty == "sublocality" || ty == "sublocality_level_1" || ty=="locality"));
            var state = geoCoding.results.FirstOrDefault().address_components.FirstOrDefault(ac => ac.types.Any(ty => ty == "administrative_area_level_1"));
            var country = geoCoding.results.FirstOrDefault().address_components.FirstOrDefault(ac => ac.types.Any(ty => ty == "country"));
            var placeId = geoCoding.results.FirstOrDefault().place_id;
            var cityName = string.Format("{0},{1},{2}", city.long_name, state.short_name, country.short_name);
            Dictionary<string, string> json = new Dictionary<string, string>();
            json.Add("placeId", placeId);
            json.Add("city", cityName);
            return new JsonResult(json);
        }
        [HttpGet]
        public ActionResult CalculateMapping(string placeId,string milesSelected)
        {
            return null;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
