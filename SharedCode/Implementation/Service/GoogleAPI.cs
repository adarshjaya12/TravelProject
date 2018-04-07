using SharedCode.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode.Implementation.Service
{
    public class GoogleAPI :IGoogleAPI
    {
        public string DistanceMatrix
        {
            get { return "distancematrix/json?units={0}&origins={1}&destinations={2}&key=AIzaSyAJcN9JoeTZj4ZgkNcmwxkQr3kh65PBuRQ"; }
        }
        public string AutoComplete
        {
            get { return "place/autocomplete/json?input={0}&key=AIzaSyCBSvM5VkXIPQ8qATe-DewVCnOPAg1LfzQ&types=(cities)"; }
        }

        public string ReverseGeoCoding
        {
            get { return "geocode/json?latlng={0},{1}&key=AIzaSyB_kjjeVFyxXQE_IL6K1j33AwWWxtk1Y9E"; }
        }

        public string GeoCoding
        {
            get { return "geocode/json?address={0}&key=AIzaSyB_kjjeVFyxXQE_IL6K1j33AwWWxtk1Y9E"; }
        }


    }
}
