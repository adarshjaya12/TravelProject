using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode.Interface.Service
{
    public interface IGoogleAPI
    {
        string DistanceMatrix { get; }
        string AutoComplete { get; }
        string ReverseGeoCoding { get; }
        string GeoCoding { get; }
    }
}
